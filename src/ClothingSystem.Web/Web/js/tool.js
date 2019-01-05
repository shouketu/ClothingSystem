var $lsjTool = (function () {
    var res = {};
    res.getCookie = function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
    };

    res.getQueryString = function (name) {
        var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
        var r = window.location.search.substr(1).match(reg);
        if (r != null) {
            return unescape(r[2]);
        }
        return null;
    }

    return res;
})();

var $lsjHttp = (function () {
    var res = {};
    var request = function (method, url, requestData, successBack, isAuth, isAdmin) {
        var heads = { "Content-Type": "application/json;charset=utf-8" };
        isAuth = isAuth == null ? true : isAuth;
        if (isAuth) {
            if (isAdmin)
                heads["Authorization"] = "Basic " + $lsjTool.getCookie("admintoken");
            else
                heads["Authorization"] = "Basic " + $lsjTool.getCookie("usertoken");
        }
        $.ajax({
            type: method,
            // contentType: 'application/json;charset=utf-8',
            headers: heads,
            dataType: "json",
            data: JSON.stringify(requestData),
            url: url,
            success: function (res) {
                if (!res.Status) {
                    // alert(res.ErrorMessage);
                    layer.msg(res.ErrorMessage);
                    return;
                }
                successBack(res);
            },
        });
    };
    res.userGet = function (url, successBack, isAuth) {
        request("get", url, null, successBack, isAuth, false);
    }

    res.userPost = function (url, requestData, successBack, isAuth) {
        request("post", url, requestData, successBack, isAuth, false);
    }

    res.adminGet = function (url, successBack, isAuth) {
        request("get", url, null, successBack, isAuth, true);
    }

    res.adminPost = function (url, requestData, successBack, isAuth) {
        request("post", url, requestData, successBack, isAuth, true);
    }
    return res;
})();

var $lsjPage = (function () {
    var res = {};

    res.pageByCallback = function (url, data, callback) {
        $lsjHttp.userPost(url, data, function (res) {
            var total = res.Data.Total;
            var ele = "page";
            if (total <= 0)
            {
                $("#" + ele).hide();
                return;
            }
            else
                $("#" + ele).show();

            layui.use('laypage', function () {
                var laypage = layui.laypage;

                laypage.render({
                    elem: ele,
                    count: total,
                    layout: ['count', 'prev', 'page', 'next', 'limit'/*, 'refresh', 'skip'*/],
                    jump: function (obj) {
                        data.PageSize = obj.limit;
                        data.PageIndex = obj.curr;
                        $lsjHttp.userPost(url, data, callback);
                        return false;
                    }
                });
            });
        });
    };

    res.pageByTemplate = function (url, data, template) {
        res.pageByCallback(url, data, function (res) {
            var html = '';
            var keyStr = template;
            for (var i = 0; i < res.Data.Items.length; i++) {
                var item = res.Data.Items[i];
                html += keyStr.replaceModel(item);
            }
            // 显示
            $("#con").html(html);
        });
    };

    return res;
})();

(function () {
    String.prototype.replaceModel = function (model) {
        var str = this;
        if (!model)
            return null;
        for (var key in model) {
            var val = model[key];
            if (isNaN(val) && !isNaN(Date.parse(val))) {
                val = val.toFromat();
            }
            // str = str.replace('{' + key + '}', val == null ? "" : val);
            str = str.replace(new RegExp('{' + key + '}',"gm"),val == null ? "" : val);
        }
        return str;
    };
    
    Date.prototype.toFromat = function () {
        var setNum = function (val) {
            if (val < 10)
                return "0" + val;
            return val;
        };

        var date = this;
        var dateStr = date.getFullYear() + "-" + setNum((date.getMonth() + 1)) + "-" + setNum(date.getDate());
        var timeStr = setNum(date.getHours()) + ":" + setNum(date.getMinutes()) + ":" + setNum(date.getSeconds());
        return dateStr + " " + timeStr;
    };

    String.prototype.toFromat = function () {
        var date = new Date(this);
        return date.toFromat();
    };
})();