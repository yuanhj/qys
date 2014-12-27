<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatepwd.aspx.cs" Inherits="ServiceWeb.updatepwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>密码修改-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
   <div id="container">
       <beauty:head_menu ID="head_menu" runat="server" />
    <div class="m_t"></div>  
    <!--weizhi开始-->
    <div class="weizhi">当前位置:首页>密码修改</div>
    <!--weizhi结束--> 
    <div class="mima">
       <span>用户名:</span><input type="text" style="height:25px;" id="uname" runat="server" readonly="readonly"/><br/><br/>
       <span><font style="color:#F00">*</font>请输入新密码:</span><%--<input type="text" style="height:25px;"/>--%><asp:TextBox ID="newpwd" TextMode="Password" runat="server" Height="25"></asp:TextBox><br/><br/>
       <span><font style="color:#F00">*</font>请确认新密码:</span><%--<input type="text" style="height:25px;"/>--%><asp:TextBox ID="newpwdtwo" TextMode="Password" runat="server" Height="25"></asp:TextBox><br/><br/>
       <asp:Button ID="But_OK" CssClass="yes_btn" runat="server" Text="提交" OnClick="But_OK_Click" />
    </div>
   <beauty:yuan_foot ID="web_foot" runat="server" />
</div>
    </form>
</body>
</html>
