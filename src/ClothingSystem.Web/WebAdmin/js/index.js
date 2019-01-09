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

    // 修改密码
    $(".editpwd").on("click", function () {
        var $this = $(this);
        var oldPwd = $("#oldPwd").val();
        var newPwd = $("#newPwd").val();
        var renewPwd = $("#renewPwd").val();
        var model = {
            OldPwd: oldPwd,
            NewPwd: newPwd,
            ReNewPwd: renewPwd,
        };
        $lsjHttp.adminPost("/api/Administrator/EditPassword", model, function (res) {
            if (res.Data) {
                layer.msg("修改成功，请重新登录");
                loginOut();
            }
        });
    });
});