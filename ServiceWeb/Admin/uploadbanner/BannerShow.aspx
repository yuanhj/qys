<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BannerShow.aspx.cs" Inherits="ServiceWeb.Admin.uploadbanner.BannerShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="well">
            <a href="AddBanner.aspx" class="button">添加</a>
             <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" CssClass="table table-bordered" OnPageIndexChanging="gvList_PageIndexChanging" OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound"  >
                 <Columns>
                     <asp:BoundField HeaderText="编号" DataField="ID"/>
                     <asp:BoundField HeaderText="标题" DataField="Subject"/>
                     <asp:BoundField HeaderText="图片名称" DataField="ImagePath"/>
                     <asp:BoundField HeaderText="提交时间" DataField="AddTime"/>
                     <asp:BoundField HeaderText="状态" DataField="status"/>
                     <asp:BoundField HeaderText="区/县" DataField="CountyID" />
                     <asp:TemplateField HeaderText="管理">
                         <ItemTemplate>
                             <asp:LinkButton CommandName="edit" CommandArgument='<%# Eval("id") %>' runat="server" ID="btnEdit" Text="编辑" /> 
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
    </div>
    </form>
</body>
</html>
