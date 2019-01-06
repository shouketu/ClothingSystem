<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <dl class="loginInfo clearfix">
                <dt>
                    <img src="/skin/webimages/zds01.png" /></dt>
                <dd>
                    <p class="getDate">当前时间：<%=DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + ClothingSystem.Common.StringExpansion.ToDayOfWeek(DateTime.Now.DayOfWeek) %></p>
                    <p class="memberText"><%=_user.UserName %></p>
                    <p>欢迎进入网站管理中心！</p>
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>

