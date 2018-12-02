var $tool = (function () {
    var res = {};
    res.getCookie = function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");

        if (arr = document.cookie.match(reg))

            return unescape(arr[2]);
        else
            return null;
    };
    res.request = function (method, url, requestData, successBack, isAuth, isAdmin) {
        var heads = { "Content-Type": "application/json;charset=utf-8" };
        isAuth = isAuth == null ? true : isAuth;
        if (isAuth) {
            if (isAdmin)
                heads["Authorization"] = "Basic " + res.getCookie("admintoken");
            else
                heads["Authorization"] = "Basic " + res.getCookie("usertoken");
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

    return res;
})();