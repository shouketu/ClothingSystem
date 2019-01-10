<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 业务列表</p>
            <div class="projectTable">
                <div class="searchItem clearfix">
                    <form class="userSearch">
                        <div class="seachGroup">
                            <span>所属分组</span>
                            <select class="groupSearch selectGroup">
                                <option value="">全部</option>
                            </select>
                        </div>
                        <div class="searchMember">
                            <span>用户搜索</span>
                            <input class="membertext" type="text" />
                            <button type="submit" class="memberbtn">搜索</button>
                        </div>
                    </form>
                </div>
                <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="15%">账号</th>
                            <th width="15%">密码</th>
                            <th width="15%">电话</th>
                            <th width="15%">分组</th>
                            <th width="15%">权限</th>
                            <th>常规操作</th>
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
    <!--遮罩-->
    <div class="mask hide"></div>

    <!-- 修改 -->
    <div class="maskfloat businessFloat hide">
        <div class="title">修改</div>
        <div class="modofyname">
            <form class="formEditUser">
                <input type="hidden" name="Id" />
                <div class="groupItem">
                    <span>账号：</span>
                    <input class="busId" name="UserName" type="text" />
                </div>
                <%--<div class="groupItem">
                    <span>密码：</span>
                    <input class="busPassword" name="UserPwdText" type="text" />
                </div>--%>
                <div class="groupItem">
                    <span>电话：</span>
                    <input class="busPhone" name="Mobile" type="text" />
                </div>
                <div class="groupItem">
                    <span>所属分组：</span>
                    <select class="groupSelect busGroup selectGroup" name="GroupId">
                    </select>
                </div>
                <div class="addProbtn">
                    <span class="surebtn busSureBtn" indexflag="">确定</span>
                    <span class="cancelbtn buscacBtn">取消</span>
                </div>
            </form>
        </div>
    </div>

    <!-- 修改 -->
    <div class="maskfloat businessUpdatePwdFloat hide">
        <div class="title">修改</div>
        <div class="modofyname">
            <form class="formEditUserPwd">
                <input type="hidden" name="UserId" />
                <div class="groupItem">
                    <span>账号：</span>
                    <span class="username"></span>
                </div>
                <div class="groupItem">
                    <span>旧密码：</span>
                    <span class="spanPwd">**********</span>
                </div>
                <div class="groupItem">
                    <span>密码：</span>
                    <input name="UserPwdText" type="text" />
                </div>
                <div class="addProbtn">
                    <span class="surebtn busSureBtn" indexflag="">确定</span>
                    <span class="cancelbtn buscacBtn">取消</span>
                </div>
            </form>
        </div>
    </div>

    <script src="/skin/laydate/laydate.js"></script>
    <script src="js/userinfo.js"></script>
</asp:Content>
