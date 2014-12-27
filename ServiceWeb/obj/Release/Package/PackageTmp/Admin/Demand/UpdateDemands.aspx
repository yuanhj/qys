<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDemands.aspx.cs" Inherits="ServiceWeb.Admin.Demand.UpdateDemands" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Ueditor/ueditor.all.js" type="text/javascript"></script>
    <script src="../Ueditor/ueditor.config.js" type="text/javascript"></script>
    <link href="../Ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <div class="row">
                <label class="control-label">所属县区：</label>
                <div class="controls"><asp:Literal runat="server" ID="litCounty"></asp:Literal></div>
            </div>
            <div class="row">
                <label class="control-label">企业名称：</label>
                <div class="controls"><asp:Literal runat="server" ID="litCompanyName"></asp:Literal></div>
            </div>
            <div class="row">
                <label class="control-label">发布IP：</label>
                <div class="controls"><asp:Literal runat="server" ID="litPostIp"></asp:Literal></div>
            </div>
            <div class="row">
                <label class="control-label">诉求类型：</label>
                <div class="controls"><asp:CheckBoxList runat="server" ID="chlType" RepeatDirection="Horizontal" CssClass="chklist"/></div>
            </div>
             <div class="row">
                <label class="control-label">诉求编号：</label>
                <div class="controls"><asp:Literal runat="server" ID="litSerial"></asp:Literal></div>
            </div>
             <div class="row">
                <label class="control-label">进展情况：</label>
                <div class="controls  control-row-auto">
                    <asp:TextBox ID="qingkuang" runat="server" class="input-large"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label class="control-label">标题：</label>
                <div class="controls"><asp:TextBox ID="tbSubject" runat="server" class="input-large"></asp:TextBox></div>
            </div>
            <div class="row h180">
                <label class="control-label">内容：</label>
                <div class="controls"><asp:TextBox runat="server" ID="tbMessage" TextMode="MultiLine" CssClass="message"></asp:TextBox></div>
            </div>
            <asp:Button ID="But_Update" class="button" runat="server" Text="保存" OnClick="But_Update_Click" />
        </div>
    </form>
</body>
</html>
