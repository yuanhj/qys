<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostShow.aspx.cs" Inherits="ServiceWeb.Admin.PostShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <h3>搜索</h3>
            <div class="control-group">
                <label class="control-label">区县：</label>
                <div class="controls"><asp:DropDownList runat="server" ID="dpSearchCounty"/></div>
                <label class="control-label">类型：</label>
                <div class="controls"><asp:DropDownList runat="server" ID="dpSearchType"/></div>
                <label class="control-label">标题：</label>
                <div class="controls span10">
                    <asp:TextBox runat="server" ID="tbSearchKey"></asp:TextBox>
                    <asp:Button runat="server" ID="btnSearch" CssClass="button" Text="搜索" OnClick="btnSearch_Click"/>
                </div>
            </div>
            <h3>列表</h3>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="18"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"  CssClass="table table-bordered"
            onpageindexchanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="true" />
                <asp:BoundField DataField="countyid" HeaderText="区县"/>
                <asp:BoundField DataField="typeid" HeaderText="类型"/>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <a href="/PostDetail.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("Subject") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="addtime" HeaderText="添加日期"/>
                <asp:BoundField DataField="updatetime" HeaderText="修改日期"/>
                <asp:TemplateField HeaderText="置顶">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkIsTop" OnCheckedChanged="chkTop_CheckedChanged" AutoPostBack="True"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="管理" ShowDeleteButton="True" EditText="编辑" ShowEditButton="True" DeleteText="删除" />
            </Columns>
            <PagerStyle CssClass="page"></PagerStyle>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
