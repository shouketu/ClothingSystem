<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 项目添加</p>
            <form class="formProject">
                <div class="addProject">
                    <div class="addItem">
                        <span>项目名称：</span>
                        <input class="addProName" name="Title" type="text" placeholder="请输入项目名称" />
                    </div>
                    <div class="addProbtn">
                        <span class="surebtn">提交</span>
                        <span class="cancelbtn addresetBtn">重置</span>
                    </div>
                </div>
                <button type="submit" style="display:none;" />
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="js/projectinfo.js"></script>
</asp:Content>
