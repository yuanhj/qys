<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandShow.aspx.cs" Inherits="ServiceWeb.Admin.Demand.DemandShow" %>

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
                 <label class="control-label" style="width: 50px;">区县：</label>
                 <div class="controls"><asp:DropDownList runat="server" ID="dpSearchCounty"/></div>
                 <label class="control-label" style="width: 50px;">类型：</label>
                 <div class="controls"><asp:DropDownList runat="server" ID="dpSearchDType"/></div>
                 <label class="control-label" style="width: 50px;">状态：</label>
                 <div class="controls">
                     <asp:DropDownList runat="server" ID="dpSearchStatus"/>
                 </div>
                 <label class="control-label" style="width: 180px;">企业名称/标题/内容/编号：</label>
                 <div class="controls"><asp:TextBox runat="server" ID="tbSearchKey"></asp:TextBox></div>
                 <div class="controls"><asp:Button runat="server" ID="btnSearch" Text="搜索" CssClass="button" OnClick="btnSearch_Click"/></div>
             </div>
             <h3>列表</h3>
             <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" AllowPaging="True" PageSize="18" CssClass="table table-bordered" OnPageIndexChanging="gvList_PageIndexChanging" OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound">
                 <Columns>
                     <asp:BoundField HeaderText="编号" DataField="Serial"/>
                     <asp:BoundField HeaderText="区县" DataField="countyid"/>
                     <asp:BoundField HeaderText="类别" DataField="DTypeID"/>
                     <asp:BoundField HeaderText="企业名称"/>
                     <asp:TemplateField HeaderText="标题">
                         <ItemTemplate>
                             <a href="/DemandsDetail.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("subject") %></a>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField HeaderText="提交时间" DataField="AddTime"/>
                     <asp:BoundField HeaderText="状态" DataField="status"/>
                     <asp:TemplateField HeaderText="管理">
                         <ItemTemplate>
                             <asp:LinkButton CommandName="edit" CommandArgument='<%# Eval("id") %>' runat="server" ID="btnEdit" Text="编辑" /> 
                             <asp:LinkButton CommandName="allow" CommandArgument='<%# Eval("id") %>' runat="server" ID="btnAllow" Text="受理" />
                             <asp:LinkButton CommandName="Process" CommandArgument='<%# Eval("id") %>' runat="server" ID="btnProcess" Text="办理" />
                             <asp:LinkButton CommandName="deny" CommandArgument='<%# Eval("id") %>' runat="server" ID="btnDeny" Text="拒绝受理" />
                             <asp:LinkButton runat="server" CommandName="done" CommandArgument='<%# Eval("id") %>' Text="办结"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <PagerStyle CssClass="page"></PagerStyle>
             </asp:GridView>
    </div>
    </form>
</body>
</html>
