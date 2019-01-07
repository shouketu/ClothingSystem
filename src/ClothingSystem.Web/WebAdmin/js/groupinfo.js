$(function () {
    // 搜索
    var processList = function () {
        var templateStr = '<tr>\
                        <td>{Id}</td>\
                        <td class="groupName">{Title}</td>\
                        <td class="projectName" rel="{ProjectId}">{ProjectTitle}</td>\
                        <td>\
                            <a class="modifyList" href="javascript:;" rel="{Id}">修改</a>\
                            <a class="deleteList" href="javascript:;" rel="{Id}">删除</a>\
                        </td>\
                    </tr>';
        var url = "/api/GroupInfo/GetList";
        $lsjHttp.adminPost(url, null, function (res) {
            if (res.Status) {
                var html = '';
                for (var i = 0; i < res.Data.length; i++) {
                    var item = res.Data[i];
                    html += templateStr.replaceModel(item);
                }
                $("#con").html(html);
            }
        });

        $(".mask").addClass("hide");
        $(".modofyFloat").addClass("hide");
    };
    processList();

    (function () {
        // 项目列表
        $lsjHttp.adminPost("/api/ProjectInfo/GetList", null, function (res) {
            if (res.Status) {
                var html = '';
                for (var i = 0; i < res.Data.length; i++) {
                    var item = res.Data[i];
                    html += '<option value="{Id}">{Title}</option>'.replaceModel(item);
                }
                $(".selectProject").append(html);
            }
        });
    })();

    // 添加
    var submitProcess = function () {
        var model = $lsjTool.formToModel($(".formGroup"));
        $lsjHttp.adminPost("/api/GroupInfo/Add", model, function (res) {
            if (res.Data) {
                location.href = "groupinfo.aspx";
            }
        });
    };
    $(".formGroup").on("submit", function () {
        submitProcess();
        return false;
    });
    $(".formGroup .surebtn").on("click", function () {
        submitProcess();
    });

    // 修改
    var submitEditProcess = function () {
        var model = $lsjTool.formToModel($(".formEditGroup"));
        $lsjHttp.adminPost("/api/GroupInfo/Edit", model, function (res) {
            if (res.Data) {
                processList();
            }
        });
    };
    $(".formEditGroup").on("submit", function () {
        submitEditProcess();
        return false;
    });
    $(".formEditGroup .surebtn").on("click", function () {
        submitEditProcess();
    });
    

    // 删除
    $(document).on("click", ".deleteList", function () {
        var id = $(this).attr("rel");
        if (!id) {
            layer.msg("请选择删除项");
            return;
        }
        layer.confirm("是否确定要删除?", function () {
            $lsjHttp.adminPost("/api/GroupInfo/Deletes", [id], function (data) {
                if (data.Data) {
                    layer.msg("删除成功");
                    processList();
                }
            });
        });
    });
});