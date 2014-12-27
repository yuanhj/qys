<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shouli.aspx.cs" Inherits="ServiceWeb.Admin.Shuqiushouli.Shouli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
    <script type="text/javascript" src="../script/shouli.js"></script>
</head>
<body>
    <form id="J_Form" runat="server" class="form-horizontal">
        <div class="well demanitem-well">
            <h3>企业诉求受理</h3>
            <asp:Repeater runat="server" ID="rptList">
                <ItemTemplate>
                    <div class="row demanitem" rel="<%# Server.HtmlEncode(Web.Des.EncryptDes(Eval("id").ToString())) %>">
                        <div class="control-group">
                            <label class="control-label">承办单位：</label>
                            <div class="controls"><select name="country"><option value="">请选择</option></select></div>
                            <label class="control-label">受理部门：</label>
                            <div class="controls"><select name="deperment"><option value="">请选择</option></select></div>
                            <label class="control-label">受理人员：</label>
                            <div class="controls"><select name="contanct" ori-data="<%# Eval("pid") %>"><option value="">请选择</option></select> 联系电话：<span class="mobile"><%# (new ServiceWeb.BLL.Department()).GetModel(Convert.ToInt32(Eval("pid"))).Mobile %></span></div>
                            <label class="control-label">受理时限：</label>
                            <div class="controls"><input type="text" class="calendar" ori-data="<%# Eval("ExpireTime") %>" value="<%# Convert.ToDateTime(Eval("ExpireTime")).ToString("yyyy/MM/dd") %>" name="calendar"/></div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">诉求需求：</label>
                            <div class="controls">
                                <textarea rows="5" class="requirement" cols="50" name="message" ori-data="<%# Eval("requirement") %>"><%# Server.HtmlEncode(Eval("requirement").ToString()) %></textarea>
                                <input type="button" class="button btn-del" value="－删除"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <a href="javascript:;" id="btnJoin" class="button">＋增加</a>
            <asp:HiddenField runat="server" ID="hfData"/>
            <asp:Button ID="But_Save" runat="server" Text="保存" OnClick="But_Save_Click" CssClass="button" />
       </div>
    </form>
</body>
</html>
