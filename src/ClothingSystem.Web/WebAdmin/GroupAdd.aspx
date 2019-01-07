<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 分组添加</p>
            <form class="formGroup">
                <div class="addProject">
                    <div class="addItem">
                        <span>分组名称：</span>
                        <input class="addProName" type="text" name="Title" placeholder="请输入组名称" />
                    </div>
                    <div class="addItem">
                        <span>所属项目：</span>
                        <select class="addgroup selectProject" name="ProjectId">
                        </select>
                    </div>
                    <div class="addProbtn">
                        <span class="surebtn">提交</span>
                        <span class="cancelbtn addresetBtn">重置</span>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="js/groupinfo.js"></script>
</asp:Content>
