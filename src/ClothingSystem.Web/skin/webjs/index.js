

$(function () {

    //左侧导航
    $(".memberNav ul h3").click(function () {
        var that = $(this);
        if (that.hasClass("cur")) {
            that.removeClass("cur")
            that.parent("li").find(".memberSub").slideUp()
        } else {
            that.addClass("cur")
            that.parent("li").find(".memberSub").slideDown()
        }
    });

    $(".memberSub").each(function (i) {
        if ($(".memberSub").eq(i).find("p").hasClass("cur")) {
            $(".memberSub").eq(i).show()
            $(".memberSub").eq(i).prev("h3").addClass("cur")
        }
    })


    getDate();
    function getDate() {
        var getdate = new Date();
        this.year = getdate.getFullYear();
        this.month = getdate.getMonth() + 1;
        this.date = getdate.getDate();
        this.day = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六")[getdate.getDay()];
        this.hour = getdate.getHours() < 10 ? "0" + getdate.getHours() : getdate.getHours();
        this.minute = getdate.getMinutes() < 10 ? "0" + getdate.getMinutes() : getdate.getMinutes();
        this.second = getdate.getSeconds() < 10 ? "0" + getdate.getSeconds() : getdate.getSeconds();
        var currentTime = "当前时间: " + this.year + "/" + this.month + "/" + this.date + "/ " + this.hour + ":" + this.minute + ":" + this.second + " " + this.day;
        $(".getDate").html(currentTime)
    };

    //表格操作
    $(".modifyList").on("click", function () {  //修改
        var that = $(this);
        var index = that.parents("tr").index();
        var thisText = that.parents("tr").find(".projectName").text();  //项目名称

        var groupName = that.parents("tr").find(".groupName").text();  //分组名称

        if (thisText) {   //项目列表
            $(".projectnameInp").val(thisText)
        }

        if (groupName) {  // 分组管理
            $(".groupSelect").val(groupName)
        }

        $(".mask").removeClass("hide");
        $(".modofyFloat").removeClass("hide");
        $(".fixedSureBtn").attr("indexFlag", index);

        //分组列表

        $(".fixedSureBtn").on("click", function () { //确认修改
            debugger
            var valuetxt = $(".projectnameInp").val();
            var indexFlag = $(this).attr("indexFlag");
            if ($(".groupSelect").length > 0) {  //分组列表
                var selectGroup = $(".groupSelect option:selected").val();
                $(".projectTable tr").eq(indexFlag).find(".groupName").text(selectGroup)
            }


            $(".projectTable tr").eq(indexFlag).find(".projectName").text(valuetxt)
            $(".mask").addClass("hide");
            $(".modofyFloat").addClass("hide");
        })

    });

    $(".deleteList").on("click", function () {  //删除
        debugger
        var that = $(this);
        var index = that.parents("tr").index();

        $(".mask").removeClass("hide");
        $(".cancelFloat").removeClass("hide");
        $(".deleteSureBtn").attr("indexFlag", index)

    });

    $(".deleteSureBtn").on("click", function () { //确认修改
        debugger
        var indexFlag = $(this).attr("indexFlag")
        $(".projectTable tr").eq(indexFlag).remove();
        $(".mask").addClass("hide");
        $(".cancelFloat").addClass("hide");
    })

    $(".fixedcacBtn").on("click", function () { //取消修改
        $(".mask").addClass("hide");
        $(".modofyFloat").addClass("hide");
    });

    $(".deletecacBtn").on("click", function () { //取消修改
        $(".mask").addClass("hide");
        $(".cancelFloat").addClass("hide");
    });

    $(".addresetBtn").on("click", function () { //重置
        $(".addProName").val("")
    });

    $(".mask").on("click", function () {
        $(".mask").addClass("hide");
        $(".maskfloat").addClass("hide");
    });

    //修改业务列表
    $(document).on("click", ".businessModify", function () {
        debugger

        var _this = $(this);
        var index = _this.parents("tr").index();
        var cusName = _this.parents("tr").find("td:nth-child(1)").text()
        var cusPassword = _this.parents("tr").find("td:nth-child(2)").text()
        var cusPhone = _this.parents("tr").find("td:nth-child(3)").text()
        var cusGroup = _this.parents("tr").find("td:nth-child(4)").text()

        $(".busSureBtn").attr("indexFlag", index)

        $(".busId").val(cusName)
        $(".busPassword").val(cusPassword)
        $(".busPhone").val(cusPhone)
        $(".busGroup").val(cusGroup)

        $(".mask").removeClass("hide");
        $(".businessFloat").removeClass("hide");

    });

    $(".busSureBtn").click(function () {
        var index = $(this).attr("indexFlag")
        var name = $(".busId").val()
        var getpassword = $(".busPassword").val()
        var phone = $(".busPhone").val()
        var group = $(".busGroup").val()

        $(".projectItem tr").eq(index).find("td:nth-child(1)").html(name)
        $(".projectItem tr").eq(index).find("td:nth-child(2)").html(getpassword)
        $(".projectItem tr").eq(index).find("td:nth-child(3)").html(phone)
        $(".projectItem tr").eq(index).find("td:nth-child(4)").html(group)

        $(".mask").addClass("hide");
        $(".businessFloat").addClass("hide");
    })

    $(document).on("click", ".businessDelete", function () {
        var index = $(this).parents("tr").index();

        $(".mask").removeClass("hide");
        $(".businFloat").removeClass("hide");

        $(".busindel").click(function () {
            $(".projectItem tr").eq(index).remove();
            $(".mask").addClass("hide");
            $(".businFloat").addClass("hide");
        });

        $(".busicacBtn").click(function () {
            $(".mask").addClass("hide");
            $(".businFloat").addClass("hide");
        });

    })


    //修改客户列表
    $(document).on("click", ".projectModbtn", function () {
        debugger
        var _this = $(this);
        var index = _this.parents("tr").index();
        var cusName = _this.parents("tr").find("td:nth-child(1)").text()
        var cusPhone = _this.parents("tr").find("td:nth-child(2)").text()
        var cusBelonggr = _this.parents("tr").find("td:nth-child(3)").text()
        var cusBelongBus = _this.parents("tr").find("td:nth-child(4)").text()
        var cusAddr = _this.parents("tr").find("td:nth-child(5)").text()


        $(".proSureBtn").attr("indexFlag", index)

        $(".custmName").val(cusName)
        $(".custmPhone").val(cusPhone)
        $(".custmAddr").val(cusAddr)
        $(".belongPro").val(cusBelonggr)
        $(".belongBusiness").val(cusBelongBus)

        $(".mask").removeClass("hide");
        $(".projectMod").removeClass("hide");

    });

    $(".proSureBtn").click(function () {
        var index = $(this).attr("indexFlag")
        var name = $(".custmName").val()
        var phone = $(".custmPhone").val()
        var qq = $(".custmQq").val()
        var addr = $(".custmAddr").val()
        var cost = $(".custmCost").val()
        var firstCost = $(".custmFistMy").val()
        var sendPro = $(".custmSendpro").val()
        var manager = $(".custmManager").val()
        var joinDate = $(".custmJoindate").val()
        var label = $(".custmLabel").val()
        var group = $(".belongPro option:selected").val()
        var business = $(".belongBusiness option:selected").val()

        $(".projectItem tr").eq(index).find("td:nth-child(1)").html(name)
        $(".projectItem tr").eq(index).find("td:nth-child(2)").html(phone)
        $(".projectItem tr").eq(index).find("td:nth-child(3)").html(group)
        $(".projectItem tr").eq(index).find("td:nth-child(4)").html(business)
        $(".projectItem tr").eq(index).find("td:nth-child(5)").html(addr)

        $(".mask").addClass("hide");
        $(".projectMod").addClass("hide");

    });

    $(".procacBtn").click(function () {
        $(".mask").addClass("hide");
        $(".projectMod").addClass("hide");
    });

    $(document).on("click", ".projectcalbtn", function () {
        var index = $(this).parents("tr").index();

        $(".mask").removeClass("hide");
        $(".custmFloat").removeClass("hide");

        $(".cuslistSure").click(function () {
            $(".projectItem tr").eq(index).remove();
            $(".mask").addClass("hide");
            $(".custmFloat").addClass("hide");
        });

        $(".cuslistcal").click(function () {
            $(".mask").addClass("hide");
            $(".custmFloat").addClass("hide");
        });

    })



    //添加消费记录
    var label = false   //  用于添加消费记录和修改消费记录标识  false 为添加 true为 修改
    $(".addRecord").on("click", function () {
        $("#customerId").val("0");
        $(".modDate").find(".projectnameInp").val("")
        $(".modMoney").find(".projectnameInp").val("")
        $(".modMark").find(".labelCustomer").val("")
        $(".modiCoustomer .title").html("添加消费记录")
        $(".mask").removeClass("hide");
        $(".modiCoustomer").removeClass("hide");
        label = false
    });

    //修改消费记录
    $(document).on("click", ".customerModify", function () {
        // debugger
        var _this = $(this);
        var index = _this.parents("tr").index();
        var modDate = _this.parents("tr").find("td:nth-child(1)").text()
        var modMoney = _this.parents("tr").find("td:nth-child(2)").text()
        var modMark = _this.parents("tr").find("td:nth-child(3)").text()
        label = true
        $(".sureCustomer").attr("indexFlag", index);

        $("#customerId").val(_this.attr("rel"));
        $(".modDate").find(".projectnameInp").val(modDate)
        $(".modMoney").find(".projectnameInp").val(modMoney)
        $(".modMark").find(".labelCustomer").val(modMark)

        $(".modiCoustomer .title").html("修改消费记录")
        $(".mask").removeClass("hide");
        $(".modiCoustomer").removeClass("hide");



    });

    //确认修改消费记录
    //$(".sureCustomer").on("click", function(){ 

    //	var getmodDate = $(".modDate").find(".projectnameInp").val()
    //	var getmodMoney = $(".modMoney").find(".projectnameInp").val()
    //	var getmodMark = $(".modMark").find(".labelCustomer").val()
    //	debugger
    //	if(label){  //修改消费记录
    //		var indexFlag = $(this).attr("indexFlag");
    //		$(".projectItem tr").eq(indexFlag).find("td:nth-child(1)").html(getmodDate)
    //		$(".projectItem tr").eq(indexFlag).find("td:nth-child(2)").html(getmodMoney)
    //		$(".projectItem tr").eq(indexFlag).find("td:nth-child(3)").html(getmodMark)

    //	}else{  //添加

    //		var str =""
    //		str ="<tr>"+
    //		"<td>"+ getmodDate +"</td>"+
    //		"<td>"+ getmodMoney +"</td>"+
    //		"<td>"+ getmodMark +"</td>"+
    //		"<td><a class='customerModify' href='javascript:;'>修改</a><a class='customerDelete' href='javascript:;'>删除</a></td>"+
    //		"</tr>"

    //		$(".projectItem").append(str)

    //	}

    //	$(".mask").addClass("hide");
    //	$(".modiCoustomer").addClass("hide");
    //});

    //$(document).on("click",".customerDelete", function(){
    //	var index = $(this).parents("tr").index();

    //	$(".mask").removeClass("hide");
    //	$(".cancelCustomer").removeClass("hide");

    //	$(".customerDele").click(function(){
    //		$(".projectItem tr").eq(index).remove();
    //		$(".mask").addClass("hide");
    //		$(".cancelCustomer").addClass("hide");
    //	});

    //	$(".customercacBtn").click(function(){
    //		$(".mask").addClass("hide");
    //		$(".cancelCustomer").addClass("hide");
    //	});

    //})


    //员工登录-修改密码
    $(".modipassw").click(function () {
        $(".mask").removeClass("hide");
        $(".stuffFloat").removeClass("hide");
    });

    $(".stuffCal").click(function () {
        $(".mask").click();
    });

})
