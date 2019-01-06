<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 项目列表</p>
            <div class="projectTable">
                <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="20%">项目ID</th>
                            <th width="20%">项目名称</th>
                            <th width="20%">操作</th>
                        </tr>
                    </thead>
                    <tbody id="con">
                        <%--<tr>
                            <td>1</td>
                            <td class="projectName">小马嘟嘟</td>
                            <td>
                                <a class="modifyList" href="javascript:;">修改</a>
                                <a class="deleteList" href="javascript:;">删除</a>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
            </div>
            <%--<div class="fenye" id="page">
            </div>--%>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <!--遮罩-->
    <div class="mask hide"></div>

    <!-- 修改 -->
    <div class="maskfloat modofyFloat hide">
        <div class="title">修改</div>
        <form class="formEditProject">
            <input type="hidden" name="Id" />
            <div class="modofyname">
                <div>
                    <span>项目名称：</span>
                    <input class="projectnameInp" name="Title" type="text" />
                </div>
                <div class="addProbtn">
                    <span class="surebtn fixedSureBtn" indexflag="">确定</span>
                    <span class="cancelbtn fixedcacBtn">取消</span>
                </div>
            </div>
        </form>
    </div>
    <script src="js/projectinfo.js"></script>
</asp:Content>
