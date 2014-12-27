<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCompany.aspx.cs" Inherits="ServiceWeb.Admin.zdompany.UpdateCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
     <div class="well">
          <div class="row">
                <label class="control-label">企业名称：</label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="CName"></asp:TextBox></div>
            </div>
          <div class="row">
                <label class="control-label">企业类型：</label>
                <div class="controls bui-form-group-select" data-type="city">
                    <asp:DropDownList ID="ctype" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <label class="control-label controls-logo">公司LOGO：</label>
                <div class="controls">
                    <asp:FileUpload runat="server" ID="fuLogo" CssClass="input-large" />
                    <asp:Literal runat="server" ID="litIogo"></asp:Literal></div>
            </div>
            <div class="clear"></div>
            <asp:Button ID="But_add" runat="server" Text="保存" CssClass="button" OnClick="But_add_Click" />
    </div>
    </form>
</body>
</html>
