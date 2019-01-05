<%@ Page Language="C#" MasterPageFile="~/Web/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.UserIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight stuffRg">
        <div class="memberrightCon">
            <p class="currentPosition">查找客户</p>
            <div class="projectTable">
                <div class="searchItem clearfix">
                    <form class="customerSearch">
                        <div class="searchMember">
                            <span>用户搜索</span>
                            <input class="membertext" type="text" />
                            <button class="memberbtn" type="submit">搜索</button>
                        </div>
                    </form>
                </div>
                <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="12%">姓名</th>
                            <th width="12%">加入日期</th>
                            <th width="12%">手机</th>
                            <th width="12%">QQ</th>
                            <th width="30%">授权地址</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody id="con">
                    </tbody>
                </table>
            </div>
            <div class="fenye" id="page">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="js/customerinfo.js"></script>
</asp:Content>
