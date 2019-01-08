<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight stuffRg">
        <div class="memberrightCon">
            <p class="currentPosition">查找客户</p>
            <div class="projectTable">
                <div class="searchItem clearfix">
                    <div class="seachGroup">
                        <span>所属分组</span>
                        <select class="selectGroup groupSearch">
                            <option value="">全部</option>
                        </select>
                    </div>
                    <div class="seachGroup">
                        <span>所属业务</span>
                        <select class="selectUser userSearch">
                            <option value="">全部</option>
                        </select>
                    </div>
                    <form class="customerSearch">
                        <div class="searchMember">
                            <span>用户搜索</span>
                            <input class="membertext" type="text" />
                            <button class="memberbtn">搜索</button>
                        </div>
                    </form>
                </div>
                <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="12%">姓名</th>
                            <th width="12%">电话</th>
                            <th width="12%">分组</th>
                            <th width="12%">业务</th>
                            <th width="30%">授权地址</th>
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
    <div class="maskfloat projectMod hide">
        <div class="title">修改</div>
        <form class="formEditCustomer">
            <input type="hidden" name="Id" />
            <div class="modofyname clearfix">
                <div class="groupItem">
                    <span>姓名：</span>
                    <input class="custmName" type="text" name="Name" />
                </div>
                <div class="groupItem">
                    <span>手机：</span>
                    <input class="custmPhone" type="text" name="Mobile" />
                </div>
                <div class="groupItem">
                    <span>QQ：</span>
                    <input class="custmQq" type="text" name="QQ" />
                </div>
                <div class="groupItem">
                    <span>授权地址：</span>
                    <input class="custmAddr" type="text" name="AuthAddress" />
                </div>
                <div class="groupItem">
                    <span>进货折扣：</span>
                    <input class="custmCost" type="text" name="PurchaseDiscount" />
                </div>
                <div class="groupItem">
                    <span>首批款项：</span>
                    <input class="custmFistMy" type="text" name="FirstPayment" />
                </div>
                <div class="groupItem">
                    <span>发货款项：</span>
                    <input class="custmSendpro" type="text" name="ShipmentPayment" />
                </div>
                <div class="groupItem">
                    <span>签约经理：</span>
                    <input class="custmManager" type="text" name="ContractManager" />
                </div>
                <div class="groupItem">
                    <span>加入日期： </span>
                    <input class="custmJoindate" lay="date" type="text" name="JoinTime" />
                </div>
                <div class="groupItem">
                    <span>备注：</span>
                    <input class="custmLabel" type="text" name="Remark" />
                    <%--<textarea name="Remark"></textarea>--%>
                </div>
                <div class="groupItem">
                    <span>所属分组：</span>
                    <select class="groupSelect belongPro selectGroup" name="GroupId">
                        <option value="0">暂不分配</option>
                    </select>
                </div>
                <div class="groupItem">
                    <span>所属业务：</span>
                    <select class="groupSelect belongBusiness selectUser" name="UserId">
                        <option value="0">暂不分配</option>
                    </select>
                </div>

            </div>
            <div class="addProbtn">
                <span class="surebtn proSureBtn" indexflag="">确定</span>
                <span class="cancelbtn procacBtn">取消</span>
            </div>
            <button type="submit" style="display:none;"></button>
        </form>
    </div>

    <script src="/skin/laydate/laydate.js"></script>
    <script src="js/customerinfo.js"></script>
</asp:Content>
