$(function () {
    // 登录
    $("#btnLogin").on("click", function () {
        var $this = $(this);
        var data = {
            "UserName": $("#txtUser").val(),
            "UserPwd": $("#txtPwd").val(),
            "ImgCode": $("#txtCode").val()
        };
        $lsjHttp.adminPost("/api/Administrator/Login", data, function (res) {
            alert("成功");
            location.reload();
        }, false);
    });

    $lsjHttp.adminGet("/api/Administrator/ImageCode", function (data) {
        $("#imgCode").attr("src", data.Data);
    }, false);

    // 验证码刷新
    $("#imgCode").on("click", function () {
        var $this = $(this);
        $lsjHttp.adminGet("/api/Administrator/ImageCode", function (data) {
            $this.attr("src", data.Data);
        }, false);
    });
});
