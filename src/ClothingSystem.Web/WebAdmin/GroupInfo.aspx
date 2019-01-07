<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 项目列表</p>
            <div class="projectTable">
                <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="20%">分组ID</th>
                            <th width="20%">分组名称</th>
                            <th width="20%">所属项目</th>
                            <th width="20%">操作</th>
                        </tr>
                    </thead>
                    <tbody id="con">
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <!--遮罩-->
    <div class="mask hide"></div>

    <!-- 修改 -->
    <div class="maskfloat modofyFloat hide">
        <div class="title">修改</div>
        <form class="formEditGroup">
            <input type="hidden" name="Id" />
            <div class="modofyname">
                <div class="groupItem">
                    <span>项目名称：</span>
                    <input class="projectnameInp" name="Title" type="text" />
                </div>
                <div class="groupItem">
                    <span>所属项目：</span>
                    <select class="groupSelect selectProject" name="ProjectId">
                        <%--<option value="0">请选择</option>--%>
                    </select>
                </div>
                <div class="addProbtn">
                    <span class="surebtn fixedSureBtn" indexflag="">确定</span>
                    <span class="cancelbtn fixedcacBtn">取消</span>
                </div>
            </div>
        </form>
    </div>
    <script src="js/groupinfo.js"></script>
</asp:Content>
