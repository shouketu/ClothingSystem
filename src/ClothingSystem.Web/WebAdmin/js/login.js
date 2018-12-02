$(function () {
    // 登录
    $("#btnLogin").on("click", function () {
        var $this = $(this);
        var data = {
            "UserName": $("#txtUser").val(),
            "UserPwd": $("#txtPwd").val(),
            "ImgCode": $("#txtCode").val()
        };
        $tool.request("post", "/api/Administrator/Login", data, function (res) {
            alert("成功");
            location.reload();
        }, false);
    });

    // 验证码刷新
    $("#imgCode").on("click", function () {
        var $this = $(this);
        $tool.request("get", "/api/Administrator/ImageCode", null, function (data) {
            $this.attr("src", data.Data);
        }, false);
    });
});
