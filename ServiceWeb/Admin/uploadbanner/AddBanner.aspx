<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBanner.aspx.cs" Inherits="ServiceWeb.Admin.uploadbanner.AddBanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <beauty:admin_head ID="head" runat="server" class="form-horizontal" />
    </head>
    <body>
        <form id="form1" runat="server" class="form-horizontal">
            <div class="control-group">
                    <label class="control-label">所属县区：</label>
                    <div class="controls bui-form-group-select" data-type="city">
                        <asp:DropDownList ID="country" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
              <div class="demo-content">
                <div class="control-group">
                    <label class="control-label"><s>*</s>上传图片</label>
                    <div class="controls">
                        <asp:FileUpload runat="server" ID="fuLogo" CssClass="input-large" />
                         <asp:Literal runat="server" ID="litIogo"></asp:Literal>
                    </div>
                </div>
                  </div>
            <div class="demo-content">
                <div class="control-group">
                    <label class="control-label"><s>*</s>图片标题：</label>
                    <div class="controls">
                        <asp:TextBox ID="title" runat="server" class="input-large"></asp:TextBox>
                    </div>
                </div>
                </div>
                 <div class="demo-content">
                <div class="control-group">
                    <label class="control-label"><s>*</s>图片链接：</label>
                    <div class="controls">
                        <asp:TextBox ID="Imagelink" runat="server" class="input-large"></asp:TextBox>
                    </div>
                </div>
               </div>
                <div class="control-group">
                    <label class="control-label">内容：</label>
                    <div class="controls  control-row-auto">
                        <textarea name="txteditor" id="txteditor" class="control-row4 input-large" runat="server"></textarea>
                    </div>
                </div>
                <div class="row actions-bar">
                    <div class="form-actions span13 offset3">
                        <asp:Button ID="But_Add" runat="server" Text="添加" Class="button" OnClick="But_Add_Click" />
                    </div>
                </div>
        </form>


    </body>
</html>
