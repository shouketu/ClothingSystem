<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminCustomerDetail" %>

<asp:Content ContentPlaceHolderID="Header" runat="server">
    <link href="/skin/laydate/theme/default/laydate.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">客户详细资料</p>
            <div class="addProject customerline">
                <div class="addItem">
                    <span class="Item">姓名：</span>
                    <span class="detail"><%=_model.Name %></span>
                </div>
                <div class="addItem">
                    <span class="Item">手机：</span>
                    <span class="detail"><%=_model.Mobile %></span>
                </div>
                <div class="addItem">
                    <span class="Item">QQ：</span>
                    <span class="detail"><%=_model.QQ %></span>
                </div>
                <div class="addItem">
                    <span class="Item">授权地址：</span>
                    <span class="detail"><%=_model.AuthAddress %></span>
                </div>
                <div class="addItem">
                    <span class="Item">进货折扣：</span>
                    <span class="detail"><%=_model.PurchaseDiscount %></span>
                </div>
                <div class="addItem">
                    <span class="Item">首批款项：</span>
                    <span class="detail"><%=_model.FirstPayment %></span>
                </div>
                <div class="addItem">
                    <span class="Item">发货款项：</span>
                    <span class="detail"><%=_model.ShipmentPayment %></span>
                </div>
                <div class="addItem">
                    <span class="Item">签约经理：</span>
                    <span class="detail"><%=_model.ContractManager %></span>
                </div>
                <div class="addItem">
                    <span class="Item">加入日期：</span>
                    <span class="detail"><%=_model.JoinTime %></span>
                </div>
                <div class="addItem">
                    <span class="Item">备注：</span>
                    <span class="detail"><%=_model.Remark %></span>
                </div>
                <div class="addItem">
                    <span class="Item">所属分组：</span>
                    <span class="detail"><%=_model.GroupTitle %></span>
                </div>
                <div class="addItem">
                    <span class="Item">所属业务：</span>
                    <span class="detail"><%=_model.UserName %></span>
                </div>

                <div class="consumeRecord">
                    <a class="addRecord" href="javascript:;">添加消费记录</a>
                    消费记录
                </div>
                <div class="recordTable">
                    <table class="projectItem" width="100%" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th width="20%">消费日期</th>
                                <th width="20%">消费金额</th>
                                <th width="30%">备注</th>
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
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="/skin/laydate/laydate.js"></script>
    <script src="js/consumptionrecrod.js"></script>

    <!--遮罩-->
    <div class="mask hide"></div>

    <!-- 修改 -->
    <div class="maskfloat modiCoustomer hide">
        <div class="title">修改</div>
        <form class="formCoustomer">
            <input type="submit" style="display: none;" />
            <input type="hidden" id="customerId" />
            <div class="modofyname">
                <div class="modDate">
                    <span class="customerSpan">消费日期：</span>
                    <input lay="date" class="projectnameInp" type="text" placeholder="yyyy-MM-dd" />
                </div>
                <div class="modMoney">
                    <span class="customerSpan">消费金额：</span>
                    <input class="projectnameInp" type="text" id="customerAmount" />
                </div>
                <div class="modMark">
                    <span class="customerSpan">备注：</span>
                    <textarea class="labelCustomer" id="customerRemark"></textarea>
                </div>

                <div class="addProbtn">
                    <span class="surebtn sureCustomer">确定</span>
                    <span class="cancelbtn resetCustomer">重置</span>
                </div>
            </div>
        </form>
    </div>

    <%--<div class="maskfloat cancelCustomer hide">
        <div class="title">是否确认删除</div>
        <div class="cancelbtnlist">
            <span class="surebtn customerDele" indexflag="">确定</span>
            <span class="cancelbtn customercacBtn">取消</span>
        </div>
    </div>--%>
</asp:Content>
