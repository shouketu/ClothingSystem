<%@ Page Language="C#" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminLogin" %>


<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>后台管理</title>
    <meta name="keywords" content="PURE TEA" />
    <meta name="description" content="PURE TEA" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,minimal-ui,maximum-scale=1.0,user-scalable=no" />
    <link href="/skin/webcss/index.css" rel="stylesheet" />
    <link href="/skin/webcss/layout.css" rel="stylesheet" />
</head>

<body class="loginbody">

    <div id="app">
        <div class="loginContent">
            <div class="loginForm clearfix">
                <div class="logintitle">
                    <img src="/skin/webimages/zds01.png" />
                </div>
                <form class="loginForm">
                    <div class="memberForm">
                        <ul>
                            <li>
                                <input type="text" id="txtUser" placeholder="登录账号" /></li>
                            <li>
                                <input type="password" id="txtPwd" placeholder="密码" /></li>
                            <li>
                                <input type="text" id="txtCode" placeholder="验证码" />
                                <span class="loginCode">
                                    <img src="" id="imgCode" width="112" height="40" />
                                </span>
                            </li>
                            <li><a class="loginBtn" href="javascript:;" id="btnLogin">登 录</a></li>
                        </ul>
                        <input type="submit" style="display: none;" />
                    </div>
                </form>
            </div>
        </div>
    </div>

</body>
<script src="/skin/webjs/jquery-1.12.2.min.js"></script>
<script src="/skin/webjs/index.js"></script>
<script src="/web/js/tool.js"></script>
<script src="js/login.js"></script>
<script src="/skin/layer/layer.js"></script>

</html>
