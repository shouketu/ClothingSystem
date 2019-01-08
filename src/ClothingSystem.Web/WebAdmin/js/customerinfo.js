$(function () {
    var data = {
        "UserId": null,
        "GroupId": null,
        "Name": null,
        "PageIndex": 1,
        "PageSize": 10
    };

    var processSearch = function () {
        var templateStr = '<tr>\
						<td>{Name}</td>\
						<td>{Mobile}</td>\
						<td>{GroupTitle}</td>\
						<td class="groupName">{UserName}</td>\
						<td>{AuthAddress}</td>\
						<td>\
							<a class="customer" href="customerdetail.aspx?cid={Id}">详细</a>\
							<a class="projectModbtn" href="javascript:;" rel="{Id}">修改</a>\
							<a class="projectcalbtn" href="javascript:;" rel="{Id}">删除</a>\
						</td>\
					</tr>';
        var url = "/api/CustomerInfo/SearchPage";
        $lsjPage.pageByTemplate(url, data, templateStr, true);
    };
    processSearch();

    (function () {
        // 业务列表
        $lsjHttp.adminPost("/api/UserInfo/GetList", null, function (res) {
            if (res.Status) {
                // var html = '<option value="">全部</option>';
                var html = '';
                for (var i = 0; i < res.Data.length; i++) {
                    var item = res.Data[i];
                    html += '<option value="{Id}">{UserName}</option>'.replaceModel(item);
                }
                $(".selectUser").append(html);
            }
        });

        // 分组列表
        $lsjHttp.adminPost("/api/GroupInfo/GetList", null, function (res) {
            if (res.Status) {
                // var html = '<option value="">全部</option>';
                var html = '';
                for (var i = 0; i < res.Data.length; i++) {
                    var item = res.Data[i];
                    html += '<option value="{Id}">{Title}</option>'.replaceModel(item);
                }
                $(".selectGroup").append(html);
            }
        });
    })();

    // 搜索
    $(".customerSearch").on("submit", function () {
        data.Name = $(".membertext").val();
        data.PageIndex = 1;
        processSearch();
        return false;
    });
    $(".groupSearch").on("change", function () {
        data.GroupId = $(this).val();
        data.PageIndex = 1;
        processSearch();
        return false;
    });
    $(".userSearch").on("change", function () {
        data.UserId = $(this).val();
        data.PageIndex = 1;
        processSearch();
        return false;
    });

    // 添加
    var submitProcess = function () {
        var model = $lsjTool.formToModel($(".formCustomer"));
        $lsjHttp.adminPost("/api/CustomerInfo/Add", model, function (res) {
            if (res.Data) {
                location.href = "customerlist.aspx";
            }
        });
    };
    $(".formCustomer").on("submit", function () {
        submitProcess();
        return false;
    });
    $(".formCustomer .surebtn").on("click", function () {
        submitProcess();
    });

    // 修改
    $(document).on("click", ".projectModbtn", function () {
        var _this = $(this);
        var id = _this.attr("rel");
        $lsjHttp.adminPost("/api/CustomerInfo/Get/" + id, null, function (res) {
            if (res.Data) {
                $lsjTool.modelSetForm($(".formEditCustomer"), res.Data);

                $(".mask").removeClass("hide");
                $(".projectMod").removeClass("hide");
            }
        });
    });
    var submitEditProcess = function () {
        var model = $lsjTool.formToModel($(".formEditCustomer"));
        $lsjHttp.adminPost("/api/CustomerInfo/Edit", model, function (res) {
            if (res.Data) {
                processSearch();
            }
        });
    };
    $(".formEditCustomer").on("submit", function () {
        submitEditProcess();
        return false;
    });
    $(".formEditCustomer .surebtn").on("click", function () {
        submitEditProcess();
    });


    // 删除
    $(document).on("click", ".projectcalbtn", function () {
        var id = $(this).attr("rel");
        if (!id) {
            layer.msg("请选择删除项");
            return;
        }
        layer.confirm("是否确定要删除?", function () {
            $lsjHttp.adminPost("/api/CustomerInfo/Deletes", [id], function (data) {
                if (data.Data) {
                    layer.msg("删除成功");
                    processSearch();
                }
            });
        });
    });
});