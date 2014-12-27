<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refuse.aspx.cs" Inherits="ServiceWeb.Admin.Shuqiushouli.Refuse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1"  class="form-horizontal" runat="server">
    <div class="well">
        <div class="row">
            <div class="control-group">
                <label class="control-label">诉求标题：</label>
                <div class="controls"><asp:Literal runat="server" ID="litSubject"></asp:Literal></div>
            </div>
        </div>
         <div class="row">
             <label class="control-label">拒绝：</label>
             <div class="controls"><asp:CheckBox runat="server" ID="chkDeney" CssClass="checkbox"/></div>
         </div>  
        <div class="row">
            <div class="control-group">
                <label class="control-label">原因：</label>
                <div class="controls  control-row-auto">
                    <textarea name="Reason" id="Reason" class="message" runat="server"></textarea>
                </div>
            </div>
        </div> 
        <asp:Button ID="But_Reason" class="button" runat="server" Text="提交" OnClick="But_Reason_Click"  />
        </div>
    </form>
</body>
</html>
