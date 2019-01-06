$(function () {
    var loginOut = function () {
        $lsjHttp.adminPost("/api/UserInfo/Logout", null, function (res) {
            location.reload();
        });
    };

    // 登出
    $(".loginout").on("click", function () {
        var $this = $(this);
        layer.confirm("是否确定退出？", function (data) {
            loginOut();
        });
    });
});