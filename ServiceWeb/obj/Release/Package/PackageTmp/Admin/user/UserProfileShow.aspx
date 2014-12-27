<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfileShow.aspx.cs" Inherits="ServiceWeb.Admin.user.UserProfileShow" %>

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
                 <label class="control-label" style="width: 180px;">用户名/企业名称/法人/手机：</label>
                 <div class="controls"><asp:TextBox runat="server" ID="tbSearchKey"></asp:TextBox></div>
                 <div class="controls"><asp:Button runat="server" ID="btnSearch" Text="搜索" CssClass="button" OnClick="btnSearch_Click"/></div>
             </div>
             <h3>列表</h3>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="18" 
            AutoGenerateColumns="False" onrowcancelingedit="GridView1_RowCancelingEdit"  CssClass="table table-bordered"
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="用户ID" ReadOnly="true" />
                <asp:BoundField DataField="CountyID" HeaderText="区县" ReadOnly="true" />
                <asp:BoundField DataField="Username" HeaderText="用户名"/>
                <asp:TemplateField HeaderText="企业名称">
                    <ItemTemplate>
                        <a title="点击查看该企业诉求" href="/Admin/Demand/DemandShow.aspx?cname=<%# Server.UrlEncode(Eval("companyname").ToString()) %>"><%# Eval("companyname") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LegalPerson" HeaderText="法人" />
                <asp:BoundField DataField="Phone" HeaderText="电话" />
                <asp:TemplateField HeaderText="网址">
                    <ItemTemplate>
                        <a href="<%# Eval("WebSite") %>" target="_blank"><%# Eval("WebSite") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContactName" HeaderText="联系人" />
                <asp:BoundField DataField="Mobile" HeaderText="手机" />
                <asp:CommandField HeaderText="管理" ShowEditButton="True" ShowDeleteButton="True" EditText="编辑/查看" DeleteText="删除" />
            </Columns>
            <PagerStyle CssClass="page"></PagerStyle>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
