﻿var $lsjTool = (function () {
    var res = {};
    res.getCookie = function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
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
                    alert(res.ErrorMessage);
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