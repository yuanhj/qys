<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfileAdd.aspx.cs" Inherits="ServiceWeb.Admin.user.UserProfileAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="well">
        <div class="row">
            <label class="control-label">县/区：</label>
            <div class="controls"><asp:DropDownList ID="county" runat="server"></asp:DropDownList></div>
        </div>
        <div class="row">
            <label class="control-label">用户名：</label>
            <div class="controls"><asp:TextBox runat="server" ID="tbUserName"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">密码：</label>
            <div class="controls"><asp:TextBox runat="server" ID="tbPassWord" TextMode="Password"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">公司名称：</label>
            <div class="controls"> <asp:Textbox ID="CompanyName" runat="server" CssClass="input-large"></asp:Textbox></div>
        </div>
        <div class="row">
            <label class="control-label">企业法人：</label>
            <div class="controls"><asp:TextBox ID="LegalPerson" runat="server"></asp:TextBox></div>
        </div>
       <div class="row">
           <label class="control-label">企业地址：</label>
           <div class="controls"><asp:TextBox ID="Address" runat="server" CssClass="input-large"></asp:TextBox></div>
       </div>
        <div class="row">
            <label class="control-label">企业电话：</label>
            <div class="controls"><asp:TextBox ID="phone" runat="server"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">网址：</label>
            <div class="controls"><asp:TextBox ID="website" runat="server" CssClass="input-large"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">联系人：</label>
            <div class="controls"><asp:TextBox ID="ContactName" runat="server"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">手机：</label>
            <div class="controls"><asp:TextBox ID="mobile" runat="server"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label">电子邮箱：</label>
            <div class="controls"><asp:TextBox ID="Email" runat="server" CssClass="input-large"></asp:TextBox></div>
        </div>
        <div class="row">
            <label class="control-label controls-logo">公司LOGO：</label>
            <div class="controls"><asp:FileUpload runat="server" ID="fuLogo" CssClass="input-large"/> <asp:Literal runat="server" ID="litIogo"></asp:Literal></div>
        </div>
        <div class="clear"></div>
        <div class="row r-message">
            <label class="control-label">公司简介：</label>
            <div class="controls"><asp:TextBox ID="summary" runat="server" Height="153px" TextMode="MultiLine" Width="800px"></asp:TextBox></div>
        </div>
         <div class="row">
            <label class="control-label">是否置顶：</label>
            <div class="controls">
                <asp:RadioButtonList ID="IsTop" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
            </asp:RadioButtonList>
            </div>
        </div>
        <asp:Button ID="But_add" runat="server" Text="保存" onclick="But_add_Click" CssClass="button" />
    </div>
    </form>
</body>
</html>

