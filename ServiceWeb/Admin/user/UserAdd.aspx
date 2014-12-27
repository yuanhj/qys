<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="ServiceWeb.Admin.UserAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head runat="server" ID="head" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <h3>添加管理员</h3>
              <div class="row">
                <label class="control-label">区县：</label>
                <div class="controls"><asp:DropDownList ID="countys" runat="server"></asp:DropDownList></div>
            </div>
            <div class="row">
                <label class="control-label">用户名：</label>
                <div class="controls"><asp:TextBox ID="UserName" runat="server"></asp:TextBox></div>
            </div>
            <div class="row">
                <label class="control-label">密&nbsp;&nbsp;码：</label>
                <div class="controls"><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></div>
            </div>
            <div class="row">
                <div class="controls"><asp:Button ID="But_Add" runat="server" Text="添加" onclick="But_Add_Click" CssClass="button" /></div>
            </div>
            <h3>管理员列表</h3>
            <asp:Repeater runat="server" ID="rptList" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>用户名</th>
                                <th>所属区县</th>
                                <th>启用</th>
                                <th>最后登录时间</th>
                                <th>最后登录IP</th>
                                <th>管理</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("username") %></td>
                        <td><%#GetCname(Eval("CountyID").ToString()) %></td>
                        <td><asp:Label runat="server" ID="lbStatus"></asp:Label></td>
                        <td><%# Eval("LastLoginTime") %></td>
                        <td><%# Eval("LastLoginIp") %></td>
                        <td><asp:Button runat="server" ID="btnActive" CommandName="Active" CommandArgument='<%# Eval("id") %>' CssClass="button"/> 
                            <asp:Button runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' CssClass="button btncfm" Text="删除"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
