<%@ Page Language="C#" MasterPageFile="~/WebAdmin/WebSite.Master" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminIndex" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="memberRight">
        <div class="memberrightCon">
            <p class="currentPosition">当前位置：管理中心 > 客户添加</p>
            <form class="formCustomer">
                <div class="addProject">
                    <div class="addItem">
                        <span>姓名：</span>
                        <input class="addProName" type="text" placeholder="请输入姓名" name="Name" />
                    </div>
                    <div class="addItem">
                        <span>手机：</span>
                        <input class="addProName" type="text" placeholder="请输入手机"  name="Mobile" />
                    </div>
                    <div class="addItem">
                        <span>QQ：</span>
                        <input class="addProName" type="text" placeholder="请输入QQ"  name="QQ" />
                    </div>
                    <div class="addItem">
                        <span>授权地址：</span>
                        <input class="addProName" type="text" placeholder="请输入授权地址"  name="AuthAddress" />
                    </div>
                    <div class="addItem">
                        <span>进货折扣：</span>
                        <input class="addProName" type="number" placeholder="请输入进货折扣" name="PurchaseDiscount"  />
                    </div>
                    <div class="addItem">
                        <span>首批款项：</span>
                        <input class="addProName" type="number" placeholder="请输入首批款项" name="FirstPayment"  />
                    </div>
                    <div class="addItem">
                        <span>发货款项：</span>
                        <input class="addProName" type="number" placeholder="请输入发货款项" name="ShipmentPayment"  />
                    </div>
                    <div class="addItem">
                        <span>签约经理：</span>
                        <input class="addProName" type="text" placeholder="请输入签约经理" name="ContractManager"  />
                    </div>
                    <div class="addItem">
                        <span>加入日期：</span>
                        <input class="addProName" type="text" placeholder="请选择加入日期" lay="date" name="JoinTime"  />
                    </div>
                    <div class="addItem">
                        <span>备注：</span>
                        <textarea class="customerdt" placeholder="备注信息" name="Remark"></textarea>
                    </div>
                    <div class="addItem">
                        <span>所属分组：</span>
                        <select class="addgroup selectGroup" name="GroupId">
                            <option value="0">暂不分配</option>
                        </select>
                    </div>
                    <div class="addItem">
                        <span>所属业务：</span>
                        <select class="addgroup selectUser" name="UserId">
                            <option value="0">暂不分配</option>
                        </select>
                    </div>
                    <div class="addProbtn">
                        <span class="surebtn">提交</span>
                        <span class="cancelbtn addresetBtn">重置</span>
                    </div>
                    <button type="submit" style="display:none;" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Foot" runat="server">
    <script src="/skin/laydate/laydate.js"></script>
    <script src="js/customerinfo.js"></script>
</asp:Content>
