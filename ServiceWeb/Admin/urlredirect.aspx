<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urlredirect.aspx.cs" Inherits="ServiceWeb.Admin.urlredirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <beauty:admin_head runat="server" ID="head" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="well showbox">
        <p><asp:Literal runat="server" ID="litMessage"></asp:Literal></p>
    </div>
    </form>
</body>
</html>
