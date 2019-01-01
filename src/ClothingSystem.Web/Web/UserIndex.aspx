<%@ Page Language="C#" AutoEventWireup="true" Inherits="ClothingSystem.Web.WebPage.UserIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-1.12.2.min.js"></script>
    <script src="js/tool.js"></script>
    <%--<script src="js/index.js"></script>--%>
    <script src="angular.min.js"></script>
</head>
<body>
    <input type="button" id="btnLogout" value="登出" />
    <div ng-app="indexapp" ng-controller="customer">
        <p ng-repeat="x in items">
            {{x.Id + '，' + x.Name}}
        </p>
    </div>
</body>
    <script>
        var app = angular.module('indexapp', []);
        app.controller("customer", function ($scope, $http) {
            var data = {
                "Name": null,
                "PageIndex": 1,
                "PageSize": 20
            };
            var heads = { "Content-Type": "application/json;charset=utf-8" };
            heads["Authorization"] = "Basic " + $lsjTool.getCookie("usertoken");
            $http({
                method: "post",
                url: "/api/CustomerInfo/SearchPage",
                headers: heads,
                data: data,
            }).then(function successCallback(res) {
                console.log(res);
                $scope.items = res.data.Data.Items;
            });
        });
    </script>
</html>
