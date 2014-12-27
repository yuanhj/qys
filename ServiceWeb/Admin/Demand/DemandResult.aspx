<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandResult.aspx.cs" Inherits="ServiceWeb.Admin.Demand.DemandResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
    <script type="text/javascript" src="/Scripts/jquery.raty.min.js"></script>
    <script type="text/javascript" src="../script/demandresult.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <div class="control-group">
                <label class="control-label">诉求标题：</label>
                <div class="controls"><asp:Literal runat="server" ID="litSubject"></asp:Literal></div>
            </div>
            <asp:Repeater runat="server" ID="rptProfileItem">
                <ItemTemplate>
                    <div class="itemresult">
                        <div class="control-group">
                        <label class="control-label">受理单位</label>
                        <div class="controls"><%# Eval("name") %></div>
                        <label class="controls">受理部门：</label>
                        <div class="controls"><%# Eval("departmentname") %></div>
                        <label class="control-label">受理人员：</label>
                        <div class="controls"><%# Eval("Username") %></div>
                        <label class="control-label">联系电话：</label>
                        <div class="controls"><%# Eval("mobile") %></div>
                        <label class="control-label">过期时间：</label>
                        <div class="controls"><%# Convert.ToDateTime(Eval("expiretime")).ToShortDateString() %></div>
                        <label class="control-label">满意度：</label>
                        <div class="controls"><div class="raty" data-score="<%# Eval("evaluate") %>"></div></div>
                    </div>
                        <div class="control-group">
                        <label class="control-label">办理事项：</label>
                        <div class="controls"><%# Eval("requirement") %></div>
                    </div>
                        <div class="control-group">
                        <label class="control-label">回复：</label>
                        <div class="controls"><%# Eval("reply") %></div>
                    </div>
                </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="control-group h180">
                <label class="control-label">总结：</label>
                <div class="controls"><asp:TextBox runat="server" ID="tbMessage" TextMode="MultiLine" CssClass="message"></asp:TextBox></div>
            </div>
            <asp:Button ID="But_Result" class="button" runat="server" Text="提交" OnClick="But_Result_Click" />
        </div>
    </form>
</body>
</html>
