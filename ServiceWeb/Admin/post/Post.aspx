<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="ServiceWeb.Admin.Post" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head runat="server" ID="head" />
    <script src="../Ueditor/ueditor.all.js" type="text/javascript"></script>
    <script src="../Ueditor/ueditor.config.js" type="text/javascript"></script>
    <link href="../Ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <div class="control-group">
                <label class="control-label">县/区：</label>
                <div class="controls"><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></div>
            </div>  
            <div class="control-group">
                <label class="control-label">类型：</label>
                <div class="controls"><asp:DropDownList runat="server" ID="dpPostType"/></div>
            </div>
            <div class="control-group">
                    <label class="control-label">主题：</label>
                    <div class="controls"><asp:TextBox ID="zhuti" runat="server" CssClass="input-large"></asp:TextBox></div>
                </div>    
                <div class="control-group">
                    <label class="control-label">内容：</label>
                    <div class="controls  control-row-auto"><textarea rows="5" cols="90" name="txteditor" id="txteditor"  style="width:600px; height:150px;" runat="server"></textarea>
                        <script type="text/javascript">
                            var editor = new baidu.editor.ui.Editor();
                            editor.render('txteditor');
                        </script>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">是否置顶：</label>
                    <div class="controls"><asp:RadioButtonList ID="radio_top" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">不置顶</asp:ListItem>
                            <asp:ListItem Value="1">置顶</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <asp:Button ID="Btn_Add" runat="server" Text="保存" Font-Size="Large" Height="29px" CssClass="button" OnClick="Btn_Add_Click" />
        </div>
    </form>
</body>
</html>
