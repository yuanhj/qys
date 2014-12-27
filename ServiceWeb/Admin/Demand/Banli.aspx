<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banli.aspx.cs" Inherits="ServiceWeb.Admin.Demand.Banli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
    <script type="text/javascript" src="../script/banli.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.raty.min.js"></script>
</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
   <div class="well">
      <a href="DemandShow.aspx"><h3>返回诉求列表</h3></a>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="row banliitem">
                <div class="control-group">
                    <label class="control-label">办理单位：</label>
                    <div class="controls"><%#GetCounty(Eval("PID").ToString()) %></div>
                    <label class="control-label">办理部门：</label>
                    <div class="controls"><%#GetDepartmentName(Eval("PID").ToString()) %></div>
                    <label class="control-label">办理人员：</label>
                    <div class="controls"><%#GetName(Eval("PID").ToString()) %></div>
                    <label class="control-label">联系电话：</label>
                    <div class="controls"><%#GetMobile(Eval("PID").ToString()) %></div>
                    <label class="control-label">过期时间：</label>
                    <div class="controls"><%# Convert.ToDateTime(Eval("ExpireTime")).ToString("yyyy-MM-dd")%></div>
                </div>
                <div class="control-group">
                    <label class="control-label">办理事项：</label>
                    <div class="controls"><%# Web.Helper.RemoveMeta(Eval("Requirement").ToString()) %></div>
                </div>
                <div class="control-group h140">
                    <label class="control-label">回复：</label>
                    <div class="controls"><textarea rows="5" cols="90" rel='<%# Web.Des.EncryptDes(Eval("id").ToString()) %>' class="message" name="message" ch='<%# Web.Helper.MD5(Eval("Reply").ToString()).ToLower() %>'><%# Eval("Reply") %></textarea></div>
                </div>
                <%--<div class="control-group">
                    <label class="control-label">满意度：</label>
                    <div class="controls"><div class="raty" data-score="<%# Eval("evaluate") %>"></div></div>
                </div>--%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
       <asp:HiddenField runat="server" ID="hfData"/>
       <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="button" OnClick="btnSave_Click"/>
       </div>
    </form>
</body>
</html>
