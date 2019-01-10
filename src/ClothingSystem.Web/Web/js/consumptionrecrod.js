$(function () {
    var cid = $lsjTool.getQueryString("cid");
    var data = {
        "CustomerInfoId": cid,
        "PageIndex": 1,
        "PageSize": 10
    };

    var processSearch = function () {
        var templateStr = '<tr>\
                        <td>{AddTime}</td>\
                        <td>{Amount}</td>\
                        <td>{Remark}</td>\
                        <td>\
                            <a class="customerModify" href="javascript:;" rel="{Id}">修改</a>\
                            <a class="customerDelete" href="javascript:;" rel="{Id}">删除</a>\
                        </td>\
                    </tr>';
        var url = "/api/ConsumptionRecrod/SearchPage";

        $lsjPage.pageByTemplate(url, data, templateStr);    // 查询

        $(".mask").addClass("hide");
        $(".modiCoustomer").addClass("hide");
    };
    processSearch();

    // 添加或修改
    var submitSaveProcess = function () {
        var id = $("#customerId").val();
        var date = $("[lay=date]").val();
        var amount = $("#customerAmount").val();
        var remark = $("#customerRemark").val();

        if (!date) {
            layer.msg("请选择日期");
            return;
        } else if (!amount) {
            layer.msg("请填写金额");
            return;
        }

        var model = {};
        model.Id = id;
        model.CustomerInfoId = cid;
        model.AddTime = date;
        model.Amount = amount;
        model.Remark = remark;

        if (model.Id > 0) {
            $lsjHttp.userPost("/api/ConsumptionRecrod/Edit", model, function (data) {
                if (data.Data)
                    processSearch();
            });
        }
        else {
            $lsjHttp.userPost("/api/ConsumptionRecrod/Add", model, function (data) {
                if (data.Data) {
                    data.PageIndex = 1;
                    processSearch();
                }
            });
        }
    };
    $(".formCoustomer").on("submit", function () {
        submitSaveProcess();
        return false;
    });
    $(".sureCustomer").on("click", function () {
        submitSaveProcess();
    });

    // 删除
    $(document).on("click", ".customerDelete", function () {
        var id = $(this).attr("rel");
        if (!id) {
            layer.msg("请选择删除项");
            return;
        }
        layer.confirm("是否确定要删除?", function () {
            $lsjHttp.userPost("/api/ConsumptionRecrod/Deletes", [id], function (data) {
                if (data.Data) {
                    layer.msg("删除成功");
                    processSearch();
                }
            });
        });
    });
});