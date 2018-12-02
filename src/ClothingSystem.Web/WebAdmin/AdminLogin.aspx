<%@ Page Language="C#" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Web/jquery-1.12.2.min.js"></script>
    <script src="../Web/js/tool.js"></script>
    <script src="js/login.js"></script>
</head>
<body>
    <div>
        <input type="text" id="txtUser" placeholder="用户名" />
        <input type="text" id="txtPwd" placeholder="密码" />
        <input type="text" id="txtCode" placeholder="验证码" />
        <input type="button" id="btnLogin" value="登录" />
        <img src="https://www.baidu.com/img/baidu_jgylogo3.gif" id="imgCode" />
    </div>
</body>
</html>
