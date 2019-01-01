$(function () {
    var data = {
        "Name": null,
        "PageIndex": 2,
        "PageSize": 20
    };
    $lsjHttp.userPost("/api/CustomerInfo/SearchPage", data, function (res) {
        var html = '';
        for (var i = 0; i < res.Data.Items.length; i++) {
            var item = res.Data.Items[i];
            html += '<p>' + item.Id + '，' + item.Name + '</p>';
        }
        // 显示
        $("#con").html(html);
    });


    // 登出
    $("#btnLogout").on("click", function () {
        var $this = $(this);
        $lsjHttp.userPost("/api/UserInfo/Logout", null, function (res) {
            alert("成功");
        });
    });
});