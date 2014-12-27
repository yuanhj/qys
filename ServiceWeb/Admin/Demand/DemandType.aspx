<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandType.aspx.cs" Inherits="ServiceWeb.Admin.Demand.DemandType" %>

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
                 <label class="control-label">名称：</label>
                 <div class="controls"><asp:TextBox ID="typename" runat="server"></asp:TextBox></div>
                 <div class="controls"><asp:Button ID="But_Add" runat="server" Text="添加" onclick="But_Add_Click" /></div>
             </div>
        <h3>列表</h3>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AllowSorting="True" AutoGenerateColumns="False" onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating"  CssClass="table table-bordered"
            DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号"  ReadOnly="true"/>
                <asp:BoundField DataField="Name" HeaderText="名称" />
                <asp:CommandField HeaderText="操作" ShowEditButton="True" ShowDeleteButton="True" EditText="编辑" DeleteText="删除" />
            </Columns>
            <PagerStyle CssClass="page"></PagerStyle>
        </asp:GridView>
             </div>
    </form>
</body>
</html>
