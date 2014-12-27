<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BanliDetailed.aspx.cs" Inherits="ServiceWeb.Admin.Demand.BanliDetailed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
         <div style="padding: 15px 50px; width: 450px; text-align: left; line-height: 28px;
                font-size: 12px; border: 1px #000 solid;">
               办理事项：[<asp:Label ID="xuqiu" runat="server" ></asp:Label>]<br />
               <div style="vertical-align:middle;">
               回复内容：<asp:TextBox 
                   ID="content" runat="server" Height="110px" TextMode="MultiLine" Width="304px"></asp:TextBox><br />
                   </div>
               <asp:Button ID="But_Sav" 
                    runat="server" Text="保存" style="height: 21px" onclick="But_Sav_Click" /><br />
            </div>
            <div style="height:5px;">
                </div>
    </form>
</body>
</html>
