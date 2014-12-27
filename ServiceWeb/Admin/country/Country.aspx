<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="ServiceWeb.Admin.Country" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head runat="server" ID="head" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <h3>添加</h3>
        <div class="row">
            <label class="control-label">所属单位：</label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="dpCounty"/>
                    <asp:CheckBox runat="server" ID="chkRecommend" Text="推荐到首页"/>
                    
                </div>
            <label class="control-label">排序号：</label>
                <div class="controls">
                    <asp:TextBox ID="paixu" runat="server"></asp:TextBox>(越小越靠前)
                </div>
        </div>
            <div class="row">
                <label class="control-label">单位名称：</label>
                <div class="controls"><asp:TextBox runat="server" ID="tbName"></asp:TextBox></div>
            </div>
            <asp:Button ID="Button1" runat="server" Text="添加" onclick="But_Add_Click" class="button" />
            <h3>列表</h3>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered"
        PageSize="15" AllowPaging="True" AutoGenerateColumns="False" onrowdeleting="GridView1_RowDeleting" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
        onrowcancelingedit="GridView1_RowCancelingEdit" DataKeyNames="ID" 
        onpageindexchanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="true" />
                    <asp:BoundField DataField="Name"  HeaderText="单位名称" />
                    <asp:BoundField DataField="Parent" HeaderText="所属单位" ReadOnly="True" />
                    <asp:TemplateField HeaderText="推荐">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkRecommmend" AutoPostBack="True" OnCheckedChanged="chkRecommmend_CheckedChanged"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Paixu" HeaderText="排序号"/>
                    <asp:CommandField HeaderText="管理" ShowHeader="True" ShowEditButton="True" EditText="编辑" ShowDeleteButton="True" DeleteText="删除"  />
                </Columns>
                <PagerStyle CssClass="page"></PagerStyle>
            </asp:GridView>
       </div>
    </form>
</body>
</html>
