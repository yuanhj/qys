<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandProfileshow.aspx.cs"
    Inherits="ServiceWeb.Admin.Demand.DemandProfileshow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <beauty:admin_head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="well">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table width="900" border="1" align="center" cellpadding="1" cellspacing="1" cssclass="table table-bordered">
                        <tr>
                            <td height="30">
                                <div align="center">办理单位</div>
                            </td>
                            <td>
                                <div align="center">办理人员</div>
                            </td>
                            <td>
                                <div align="center">联系电话</div>
                            </td>
                            <td>
                                <div align="center">办理期限</div>
                            </td>
                            <td>
                                <div align="center">回复时间</div>
                            </td>
                            <td>
                                <div align="center">诉求内容</div>
                            </td>
                            <td>
                                <div align="center">是否回复</div>
                            </td>
                            <td>
                                <div align="center">操作</div>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td height="30">
                            <div align="center"><%#GetCounty(Eval("PID").ToString()) %></div>
                        </td>
                        <td>
                            <div align="center"><%#GetName(Eval("PID").ToString()) %></div>
                        </td>
                        <td>
                            <div align="center"><%#GetMobile(Eval("PID").ToString()) %></div>
                        </td>
                        <td>
                            <div align="center"><%#Eval("ExpireTime")%></div>
                        </td>
                        <td>
                            <div align="center"><%#Eval("ReplyTime")%></div>
                        </td>
                        <td>
                            <div align="center"><%#Eval("Requirement")%></div>
                        </td>
                        <td>
                            <div align="center"><%#Eval("IsReply").ToString()=="0"?"未回复":"已回复"%></div>
                        </td>
                        <td>
                            <div align="center"><a href="BanliDetailed.aspx?id=<%#Eval("ID") %>">点击回复</a></div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div style=" text-align: center;">
                <p>
                    <a href="#page">
                        <asp:Label ID="LabNowPageNumber" runat="server">1</asp:Label>
                        /<asp:Label ID="LabAllPageNumber" runat="server"></asp:Label>&nbsp;&nbsp;</a>
                    <asp:LinkButton ID="LnkBtnOne" runat="server" OnClick="LnkBtnOne_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="LnkBtnUp" runat="server" OnClick="LnkBtnUp_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="LnkBtnNext" runat="server" OnClick="LnkBtnNext_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LnkBtnBack" runat="server" OnClick="LnkBtnBack_Click">尾页</asp:LinkButton>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
