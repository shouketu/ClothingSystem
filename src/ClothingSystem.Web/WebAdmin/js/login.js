$(function () {
    // 登录
    $(".loginForm").on("submit", function () {
        var $this = $(this);
        var data = {
            "UserName": $("#txtUser").val(),
            "UserPwd": $("#txtPwd").val(),
            "ImgCode": $("#txtCode").val()
        };
        $lsjHttp.adminPost("/api/Administrator/Login", data, function (res) {
            location.reload();
        }, false);

        return false;
    });
    $("#btnLogin").on("click", function () {
        $(".loginForm input[type=submit]").click();
        return false;
    });

    // 验证码刷新
    $("#imgCode").on("click", function () {
        var $this = $(this);
        $lsjHttp.adminGet("/api/Administrator/ImageCode", function (data) {
            $this.attr("src", data.Data);
        }, false);
    });

    $("#imgCode").click();
});
