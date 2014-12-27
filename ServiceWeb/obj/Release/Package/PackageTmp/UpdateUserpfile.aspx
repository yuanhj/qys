<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUserpfile.aspx.cs" Inherits="ServiceWeb.UpdateUserpfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>修改资料-安阳企业服务110</title>
   <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/nei.js" type="text/javascript"></script>
</head>
<body>
     <form id="form1" runat="server">
        <div id="container">
           <beauty:head_menu ID="head_menu"  runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>企业资料修改</div>
            <!--weizhi结束-->
            <div class="m_t"></div>
            <!--修改 开始-->
            <div id="bor">
                <div id="w795">
                    &nbsp;<table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="name"><span>*</span>用户名：</td>
                            <td class="inputnr">
                                <input type="text" id="username" runat="server" readonly="true" /></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>公司名称：</td>
                            <td class="inputnr">
                                <input type="text" id="companyname" runat="server" /></td>
                            <td class="sm">请输入完整的公司名称。</td>
                        </tr>
                        <tr>
                            <td class="name">公司简介：</td>
                            <td class="inputnr">
                                <textarea name="txtcontext"  id="txtcontext" runat="server"></textarea></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>法人：</td>
                            <td class="inputnr">
                                <input type="text" style="width: 150px;" id="LegalPerson" runat="server" /></td>
                            <td class="sm">请输入法人的姓名。</td>
                        </tr>
                        <tr>
                            <td class="name">具体地址：</td>
                            <td class="inputnr">
                                <input type="text"  id="address" runat="server"/></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name">单位电话：</td>
                            <td class="inputnr">
                                <input type="text" id="dwPhone"  runat="server"/></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name">网址：</td>
                            <td class="inputnr">
                                <input type="text" id="website" runat="server"  /></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name">联系人：</td>
                            <td class="inputnr">
                                <input type="text" style="width: 150px;" id="ContactName" runat="server" /></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name">联系电话：</td>
                            <td class="inputnr">
                                <input type="text" id="Mobile" runat="server" /></td>
                            <td class="sm"></td>
                        </tr>
                        <tr>
                            <td class="name"><span>*</span>邮箱：</td>
                            <td class="inputnr">
                                <input type="text" id="email" runat="server" /></td>
                            <td class="sm"></td>
                        </tr>
                    </table>
                    <div style="text-align: center; padding-bottom: 20px;">
                       <%-- <asp:ImageButton ID="Reg_OK" ImageUrl="images/but_next.jpg" Width="120" Height="32" runat="server"  />--%>
                        <asp:Button ID="But_Update" runat="server"  Text="确定修改" Width="120" Height="32" OnClick="But_Update_Click" />
                    </div>
                </div>
            </div>
            <!--修改结束-->
                          <beauty:yuan_foot ID="web_foot" runat="server" />

        </div>
    </form>
</body>
</html>
