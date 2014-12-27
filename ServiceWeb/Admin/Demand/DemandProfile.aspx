<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandProfile.aspx.cs" Inherits="ServiceWeb.Admin.Demand.DemandProfile" %>

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
                <label class="control-label"></label>
            </div>
        </div>
    <div>
    <div style=" line-height:30px;">
        所属诉求：<asp:DropDownList ID="Username" runat="server">
        </asp:DropDownList><br />
        过期时间: <asp:TextBox ID="ExpireTime" runat="server"></asp:TextBox><br />
        回复时间：<asp:TextBox ID="ReplyTime" runat="server"></asp:TextBox><br />
        回复内容：<asp:TextBox ID="reply" runat="server"></asp:TextBox><br />
        是否回复：<asp:DropDownList ID="IsReply" runat="server">
        <asp:ListItem Value="0">0</asp:ListItem>
        <asp:ListItem Value="1">1</asp:ListItem>
        </asp:DropDownList><br />
        需求：<asp:TextBox ID="xuqiu" runat="server"></asp:TextBox>
        <asp:Button ID="But_Add" runat="server" Text="确定" onclick="But_Add_Click" /><br />
    </div>
    </form>
</body>
</html>

