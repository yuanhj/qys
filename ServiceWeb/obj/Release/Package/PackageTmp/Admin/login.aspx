<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServiceWeb.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>企业服务网后台管理系统</title>
    <!--[if IE 6]>
<script src="script/png.js" type="text/javascript"></script>
<script type="text/javascript">png.fix('.container')</script>
<![endif]-->
    <link href="style/login.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="main">
                <div style="margin-top: 150px; margin-left: 100px; width: 300px; float: left;">
                    <div class="yonghuming">用户名：<input type="text" id="tbUserName" runat="server" /></div>
                    <div class="secrit">密码：<input type="password" id="tbPassWord" runat="server" /></div>
                    <div class="identify">验证码：<input type="text" id="yzm" runat="server"/><img src="../bao_ValidCode.aspx" style="float:right; margin-right:87px;width:60px;" height="23" /></div>
                </div>
                <div class="anniu">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="img/anniu_03.gif" runat="server" OnClick="ImageButton1_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
