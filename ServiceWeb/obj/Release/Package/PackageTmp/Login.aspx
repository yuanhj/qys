<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServiceWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script type="text/javascript" >
        $(document).ready(function () {
            $("#But_OK").click(function () {
                if ($("#name").val() == '') {
                    alert("用户名不能为空！");
                    return false;
                } else if ($("#pswd").val() == '') {
                    alert("密码不能为空！");
                    return false;
                } else if ($("#yanzheng").val() == '') {
                    alert("验证码不能为空");
                    $("#yanzheng").focus();
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
            <div class="weizhi">当前位置：首页>企业登陆</div>
            <!--weizhi结束-->
            <div class="m_t"></div>
            <!--注册 开始-->
            <div id="bor">
                    <table class="yhj_table">
                        <tr>
                            <td width="100"> <span style="width: 60px">用户名：</span></td>
                            <td>
                                <input type="text" id="name" class="yhj_input" runat="server" />
                            </td>
                            <td style="text-align:left; padding-left: 10px;">请输入<font style="color: #F00">4-16</font>，中文、英文、数字均可。</td>
                        </tr>
                        <tr>
                            <td><span style="width: 60px">密码：</span></td>
                            <td>
                                <input type="password" id="pswd" class="yhj_input" runat="server" /></td>
                            <td style="text-align:left; padding-left: 10px;">请输入<font style="color: #F00">6</font>位以上字符，不允许空格。</td>
                        </tr>
                        <tr>
                            <td><span style="width: 60px">验证码：</span></td>
                            <td valign="middle">
                                <input type="text" id="yanzheng" class="yhj_input input_yzm" runat="server" /><img src="bao_ValidCode.aspx" /></td>
                            <td style="text-align:left; padding-left: 10px;">请输入验证码</td>
                        </tr>
                    </table>
                 <table class="zcl_table" style="margin-left:320px;">
                            <tr>
                                <td>
                                    <asp:Button ID="But_OK" runat="server" Text="登录" class="btn1" OnClick="But_OK_Click"  />
                                </td>
                                <td>
                                    <a href="Register.aspx" class="btn1">注册</a>
                                </td>
                                <td>
                                    <a href="FindPasspwod.aspx">忘记密码?</a>
                                </td>
                            </tr>
                        </table>

            </div>


            <!--注册结束-->
            <beauty:yuan_foot ID="web_foot" runat="server" />

        </div>


    </form>
</body>
</html>
