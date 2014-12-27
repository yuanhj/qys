<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPasspwod.aspx.cs" Inherits="ServiceWeb.FindPasspwod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>找回密码-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script type="text/javascript" >
        $(document).ready(function () {
            $("#But_OK").click(function () {
                if ($("#uname").val() == '') {
                    alert("用户名不能为空！");
                    return false;
                }else if ($("#email").val() == '') {
                    alert("邮箱不能为空");
                    return false;
                } else if (!$("#emails").val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                    alert("邮箱格式不正确！");
                    $("#emails").focus();
                    return false;
                }
            });
        });

     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">

            <beauty:head_menu ID="head_menu" runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置:首页>找回密码</div>
            <!--weizhi结束-->
            <div class="mima">
                <span>用户名:</span><input type="text" id="uname" style="height: 25px; width: 200px" runat="server" /><br />
                <br />
                <span><font style="color: #F00">*</font>Email:</span><input type="text" id="emails" style="height: 25px; width: 200px" runat="server" /><br />
                <br /><asp:Button ID="But_OK" runat="server" class="yes_btn" Text="发送验证邮件" OnClick="But_OK_Click" />
            </div>
            <beauty:yuan_foot ID="web_foot" runat="server" />

        </div>
    </form>
</body>
</html>
