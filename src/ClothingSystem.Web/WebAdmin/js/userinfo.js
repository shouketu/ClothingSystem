$(function () {
    var data = {
        "GroupId": null,
        "UserName": null,
        "PageIndex": 1,
        "PageSize": 10
    };

    var processSearch = function () {
        var templateStr = '<tr>\
                            <td>{UserName}</td>\
                            <td><span class="spanPwd" rel="{UserPwd}">**********</span></td>\
                            <td>{Mobile}</td>\
                            <td class="groupName" rel="{GroupId}">{GroupTitle}</td>\
                            <td><a href="javascript:;">普通<a></a></td>\
                            <td>\
                                <a class="businessModifyPwd" href="javascript:;" rel="{Id}">修改密码</a>\
                                <a class="businessModify" href="javascript:;" rel="{Id}">修改</a>\
                                <a class="businessDelete" href="javascript:;" rel="{Id}">删除</a>\
                            </td>\
                        </tr>';
        var url = "/api/UserInfo/SearchPage";
        $lsjPage.pageByTemplate(url, data, templateStr, true);

        $(".mask").addClass("hide");
        $(".businessFloat").addClass("hide");
        $(".businessUpdatePwdFloat").addClass("hide");
    };
    processSearch();

    (function () {
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
    $(".userSearch").on("submit", function () {
        data.UserName = $(".membertext").val();
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

    // 添加
    var submitProcess = function () {
        var model = $lsjTool.formToModel($(".formUser"));
        $lsjHttp.adminPost("/api/UserInfo/Add", model, function (res) {
            if (res.Data) {
                location.href = "userinfo.aspx";
            }
        });
    };
    $(".formUser").on("submit", function () {
        submitProcess();
        return false;
    });
    $(".formUser .surebtn").on("click", function () {
        submitProcess();
    });

    // 修改
    var submitEditProcess = function () {
        var model = $lsjTool.formToModel($(".formEditUser"));
        $lsjHttp.adminPost("/api/UserInfo/Edit", model, function (res) {
            if (res.Data) {
                processSearch();
            }
        });
    };
    $(".formEditUser").on("submit", function () {
        submitEditProcess();
        return false;
    });
    $(".formEditUser .surebtn").on("click", function () {
        submitEditProcess();
    });

    // 修改密码
    var submitEditPwdProcess = function () {
        var model = $lsjTool.formToModel($(".formEditUserPwd"));
        $lsjHttp.adminPost("/api/UserInfo/ModifyPassword", model, function (res) {
            if (res.Data) {
                processSearch();
            }
        });
    };
    $(".formEditUserPwd").on("submit", function () {
        submitEditPwdProcess();
        return false;
    });
    $(".formEditUserPwd .surebtn").on("click", function () {
        submitEditPwdProcess();
    });

    // 删除
    $(document).on("click", ".businessDelete", function () {
        var id = $(this).attr("rel");
        if (!id) {
            layer.msg("请选择删除项");
            return;
        }
        layer.confirm("是否确定要删除?", function () {
            $lsjHttp.adminPost("/api/UserInfo/Deletes", [id], function (data) {
                if (data.Data) {
                    layer.msg("删除成功");
                    processSearch();
                }
            });
        });
    });

    // 查看密码
    $(document).on("mouseover", ".spanPwd", function () {
        var $this = $(this);
        $lsjHttp.adminGet("/api/UserInfo/DecryptPwd?encryptPwd=" + $this.attr("rel"), function (data) {
            if (data.Data) {
                $this.text(data.Data);
            }
        });
    }).on("mouseout", ".spanPwd", function () {
        $(this).text("**********")
    });
});