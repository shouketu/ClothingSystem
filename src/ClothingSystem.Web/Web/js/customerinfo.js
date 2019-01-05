$(function () {
    var data = {
        "Name": null,
        "PageIndex": 1,
        "PageSize": 10
    };

    var templateStr = '<tr>\
                    <td>{Name}</td>\
                    <td>{JoinTime}</td>\
                    <td>{Mobile}</td>\
                    <td>{QQ}</td>\
                    <td>{AuthAddress}</td>\
                    <td>\
                        <a class="customer" href="customerdetail.aspx?cid={Id}">查看明细</a>\
                    </td>\
                </tr>';
    var url = "/api/CustomerInfo/SearchPage";
    $lsjPage.pageByTemplate(url, data, templateStr);

    $(".customerSearch").on("submit", function () {
        data.Name = $(".membertext").val();
        $lsjPage.pageByTemplate(url, data, templateStr);
        return false;
    });
});