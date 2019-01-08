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

    res.formToModel = function ($form) {
        var model = {};
        $form.find("input").each(function () {
            var name = $(this).attr("name");
            if (!!name)
                model[name] = $(this).val();
        });
        $form.find("select").each(function () {
            var name = $(this).attr("name");
            if (!!name)
                model[name] = $(this).val();
        });
        $form.find("textarea").each(function () {
            var name = $(this).attr("name");
            if (!!name)
                model[name] = $(this).val();
        });
        return model;
    };

    res.checkDate = function (val) {
        return isNaN(val) && !isNaN(Date.parse(val));
    };

    res.modelSetForm = function ($form, model) {
        if (model == null)
            return;
        for (var key in model) {
            var val = model[key];
            if (res.checkDate(val)) {
                val = val.toFromat();
            }
            $form.find("[name=" + key + "]").val(val);
        }
    };

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
            error: function (res) {
                if(res.responseJSON)
                    layer.msg(res.responseJSON.Message);
            }
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

    res.pageByCallback = function (url, data, callback, isAdmin) {
        var process = $lsjHttp.userPost;
        if (isAdmin)
            process = $lsjHttp.adminPost;
        process(url, data, function (res) {
            var total = res.Data.Total;
            var ele = "page";
            if (total <= 0)
            {
                $("#con").html('<td colspan="7">没有数据</td>');
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
                        process(url, data, callback);
                        return false;
                    }
                });
            });
        });
    };

    res.pageByTemplate = function (url, data, template, isAdmin) {
        res.pageByCallback(url, data, function (res) {
            var html = '';
            var keyStr = template;
            for (var i = 0; i < res.Data.Items.length; i++) {
                var item = res.Data.Items[i];
                html += keyStr.replaceModel(item);
            }
            // 显示
            $("#con").html(html);
        }, isAdmin);
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
            if ($lsjTool.checkDate(val)) {
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

$(function () {
    if (!!window.layui && !!window.layui.laydate || window.laydate) {
        var layDate = window.laydate || window.layui.laydate;
        $("[lay=date]").each(function (i) {
            var id = "laydate_ele_" + i;
            $(this).attr("id", id);
            layDate.render({
                elem: '#' + id,
                type: 'datetime'
            });
        });
    }
});