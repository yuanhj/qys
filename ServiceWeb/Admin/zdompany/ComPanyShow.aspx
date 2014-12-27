<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComPanyShow.aspx.cs" Inherits="ServiceWeb.Admin.zdompany.ComPanyShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <asp:Button ID="But_add" runat="server" Text="添加" CssClass="button" OnClick="But_add_Click" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" DataKeyNames="ID" AllowPaging="True" AutoGenerateColumns="False" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="true" />
                    <asp:BoundField HeaderText="企业名称" DataField="Name" />
                     <asp:BoundField HeaderText="所属企业类型" DataField="CID" />
                    <asp:TemplateField HeaderText="首页是否推荐">
                        <ItemTemplate>
                            <asp:CheckBox ID="tuijian" runat="server" AutoPostBack="True" OnCheckedChanged="tuijian__CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="管理" ShowEditButton="True" EditText="编辑" ShowDeleteButton="True" DeleteText="删除" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
