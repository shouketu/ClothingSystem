$(function () {
    var data = {
        "Name": null,
        "PageIndex": 1,
        "PageSize": 20
    };
    $tool.request("post", "/api/UserInfo/SearchPage", data, function (res) {
        var html = '';
        for (var i = 0; i < res.Data.Items.length; i++) {
            var item = res.Data.Items[i];
            html += '<p>' + item.Id + '，' + item.UserName + '</p>';
        }
        // 显示
        $("#con").html(html);
    }, true,  true);


    // 登出
    $("#btnLogout").on("click", function () {
        var $this = $(this);
        $tool.request("post", "/api/UserInfo/Logout", null, function (res) {
            alert("成功");
        });
    });
});