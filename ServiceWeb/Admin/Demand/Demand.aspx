<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demand.aspx.cs" Inherits="ServiceWeb.Admin.Demand.Demand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" class="form-horizontal" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
         <div class="well">
            <div class="control-group">
                <label class="control-label">诉求类型：</label>
                <div class="controls bui-form-group-select" data-type="city">
                    <asp:DropDownList ID="DropType" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">所属县区：</label>
                <div class="controls bui-form-group-select" data-type="city">
                    <asp:DropDownList ID="country" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">所属用户：</label>
                <div class="controls bui-form-group-select" data-type="city">
                    <asp:DropDownList ID="Username" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
             <div class="control-group">
                <label class="control-label"><s>*</s>诉求编号：</label>
                <div class="controls">
                    <asp:TextBox ID="Serial" runat="server" class="input-large" ></asp:TextBox>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label"><s>*</s>标题：</label>
                <div class="controls">
                    <asp:TextBox ID="title" runat="server" class="input-large"></asp:TextBox>
                </div>
            </div>
             <div class="control-group">
                <label class="control-label">内容：</label>
                <div class="controls  control-row-auto">
                   <textarea name="txteditor" id="txteditor" class="control-row4 input-large" runat="server"></textarea>
                </div>
            </div>
             
             <div class="row actions-bar">
                <div class="form-actions span13 offset3">
                    <asp:Button ID="But_Add" runat="server" Text="添加" Class="button" onclick="But_Add_Click" />
                </div>
            </div>
             </div>
    </form>
</body>
</html>
