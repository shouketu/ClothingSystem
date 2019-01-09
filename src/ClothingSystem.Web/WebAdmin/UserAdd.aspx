<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <form class="formUser">
                <p class="currentPosition">当前位置：管理中心 > 业务添加</p>
                <div class="addProject">
                    <div class="addItem">
                        <span>姓名：</span>
                        <input class="addProName" type="text" placeholder="请输入姓名" name="UserName" />
                    </div>
                    <div class="addItem">
                        <span>密码：</span>
                        <input class="addProName" type="text" placeholder="请输入密码" name="UserPwdText" />
                    </div>
                    <div class="addItem">
                        <span>手机：</span>
                        <input class="addProName" type="text" placeholder="请输入手机号" name="Mobile" />
                    </div>
                    <div class="addItem">
                        <span>所属项目：</span>
                        <select class="addgroup selectGroup" name="GroupId">
                        </select>
                    </div>
                    <div class="addProbtn">
                        <span class="surebtn">提交</span>
                        <span class="cancelbtn addresetBtn">重置</span>
                    </div>
                    <input type="submit" style="display:none;" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="js/userinfo.js"></script>
</asp:Content>
