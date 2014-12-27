<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeparmentShow.aspx.cs" Inherits="ServiceWeb.Admin.DeparmentShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="well">
        <h3>添加</h3>
        <div class="row">
            <label class="control-label">所属部门：</label>
            <div class="controls"><asp:DropDownList ID="dpBumen" runat="server"></asp:DropDownList></div>
        </div>
        <div class="row">
            <label class="control-label">部门名称：</label>
            <div class="controls"><asp:TextBox ID="UserName" runat="server"></asp:TextBox></div>
        </div>
        <div class="row">
            <div class="controls"><asp:Button ID="ButSave" runat="server" Text="添 加" CssClass="button" OnClick="ButSave_Click" /></div>
        </div>
        <h3>列表</h3>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CssClass="table table-bordered"
              onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
               <asp:BoundField DataField="ID" HeaderText="编号"  ReadOnly="true"/>
                <asp:BoundField DataField="CountyID" HeaderText="县区名称" ReadOnly="true" />
                <asp:BoundField DataField="DepartmentName" HeaderText="部门名称" />
                 <asp:BoundField DataField="Status" HeaderText="状态" />
                <asp:CommandField HeaderText="管理" EditText="编辑" ShowEditButton="True" ShowDeleteButton="True" DeleteText="删除"/>
        </Columns>
        <PagerStyle CssClass="page"></PagerStyle>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
