<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ServiceWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>注册-安阳企业服务110</title>
   <beauty:yuan_head ID="yuan_head" runat="server" />
       <script src="Scripts/nei.js" type="text/javascript"></script>
     <script type="text/javascript" >
         $(document).ready(function () {
             $("#But_Add").click(function () {
                 if ($("#county").find('option:selected').text() == '请选择...') {
                     alert("请选择区县");
                     return false;
                 } else if ($("#username").val() == '') {
                     alert("用户名不能为空！");
                     return false;
                 } else if ($("#username").val().length < 4 || $("#username").val().length > 16) {
                     alert("用户名长度在4-16位之间！");
                     return false;
                 } else if ($("#pwd").val() == '') {
                     alert("密码不能为空");
                     return false;
                 } else if ($("#pwd").val().length < 6) {
                     alert("密码长度不能小于6");
                     return false;
                 } else if ($("#pwd_repet").val() != $("#pwd").val()) {
                     alert("两次密码输入不一致！");
                     return false;
                 }
             });
         });

     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
           <beauty:head_menu ID="head_menu"  runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>企业注册</div>
            <!--weizhi结束-->
            <div class="m_t"></div>
            <!--注册 开始-->
            <div id="bor">
                <div id="w795">
                    <img src="images/step_01.jpg" />
                    <table border="0" cellpadding="0" cellspacing="0">
                         <tr>
                            <td class="name"><span>*</span>区县：</td>
                            <td class="inputnr">
                                <div id="xiala" style="margin-left: -5px;">
                                <asp:DropDownList ID="county" runat="server" Width="108" Height="32" >
                                </asp:DropDownList>
                                    </div>
                               </td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>用户名：</td>
                            <td class="inputnr">
                                <input type="text" id="username" runat="server" /></td>
                            <td class="sm">请输入<span>4-16位</span>字符，<span>中文、英文、数字</span>均可。</td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>密码：</td>
                            <td class="inputnr">
                                <input type="password"  id="pwd" runat="server"/></td>
                            <td class="sm">请输入<span>6位(数字和字母组合)</span>以上字符，不允许空格。</td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>确认密码：</td>
                            <td class="inputnr">
                                <input type="password" id="pwd_repet" runat="server" /></td>
                            <td class="sm">请重复输入上面的密码。</td>
                        </tr>
                    </table>
                    <div style="text-align: center; padding-bottom: 20px;">
                    <%--    <img src="images/but_next.jpg" width="120" height="32" />--%>
                        <asp:ImageButton ID="But_Add" runat="server" ImageUrl="~/images/but_next.jpg" Width="120" Height="32" OnClick="But_Add_Click" />
                    </div>
                </div>
            </div>
            <!--注册结束-->
         <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>
    </form>
</body>
</html>
