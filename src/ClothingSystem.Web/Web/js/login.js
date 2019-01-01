$(function () {
    // 登录
    $("#btnLogin").on("click", function () {
        var $this = $(this);
        var data = {
            "UserName": $("#txtUser").val(),
            "UserPwd": $("#txtPwd").val(),
            "ImgCode": $("#txtCode").val()
        };
        $lsjHttp.userPost("/api/UserInfo/Login", data, function (res) {
            alert("成功");
            location.reload();
        }, false);
    });

    // 验证码刷新
    $("#imgCode").on("click", function () {
        var $this = $(this);
        $lsjHttp.userGet("/api/UserInfo/ImageCode", function (data) {
            $this.attr("src", data.Data);
        }, false);
    });
});
