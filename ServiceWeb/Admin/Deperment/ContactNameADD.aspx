<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactNameADD.aspx.cs" Inherits="ServiceWeb.Admin.Deperment.ContactNameADD" %>

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
        <h3>添加</h3>
        <div class="row">
            <label class="control-label">区县：</label>
            <div class="controls"><asp:DropDownList runat="server" ID="dpCounty" AutoPostBack="True" OnSelectedIndexChanged="dpCounty_SelectedIndexChanged"/></div>
            <label class="control-label">所属部门：</label>
            <div class="controls"><asp:DropDownList ID="bumen" runat="server"></asp:DropDownList></div>
        </div>
        <div class="row">
            <label class="control-label">负责人：</label>
            <div class="controls"><asp:TextBox ID="UserName" runat="server"></asp:TextBox></div>
            <label class="control-label">电话：</label>
            <div class="controls"><asp:TextBox ID="Mobile" runat="server"></asp:TextBox></div>
        </div>
        <div class="row">
            <div class="controls"><asp:Button ID="ButSave" CssClass="button" runat="server" Text="添加" OnClick="ButSave_Click" /></div>
        </div>
        <h3>列表</h3>
        <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" AllowPaging="True" PageSize="18" CssClass="table table-bordered" OnPageIndexChanging="gvList_PageIndexChanging" OnRowCancelingEdit="gvList_RowCancelingEdit" OnRowDataBound="gvList_RowDataBound" OnRowDeleting="gvList_RowDeleting" OnRowEditing="gvList_RowEditing" OnRowUpdating="gvList_RowUpdating">
            <Columns>
                <asp:BoundField HeaderText="编号" DataField="cid" ReadOnly="True"/>
                <asp:BoundField HeaderText="区县" DataField="contyname" ReadOnly="True"/>
                <asp:BoundField HeaderText="部门" DataField="departmentname" ReadOnly="True"/>
                <asp:BoundField HeaderText="联系人" DataField="username"/>
                <asp:BoundField HeaderText="电话" DataField="mobile"/>
                <asp:CommandField HeaderText="管理" ShowDeleteButton="True" ShowEditButton="True" EditText="编辑" DeleteText="删除"/>
            </Columns>
            <PagerStyle CssClass="page"></PagerStyle>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
