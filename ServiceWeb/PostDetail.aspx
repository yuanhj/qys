<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="ServiceWeb.PostDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>服务动态-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/nei.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">

            <beauty:head_menu ID="head_menu" runat="server" />
            <asp:FormView ID="Bind_Post" runat="server">
                <ItemTemplate>
                    <!--weizhi开始-->
                    <div class="weizhi">当前位置：首页><%#NewType(Eval("TypeID").ToString()) %></div>
                    <!--weizhi结束-->
                    <div class="m_t"></div>
                    <div id="details">
                        <h3><%#Eval("Subject") %></h3>
                        <div style="text-align: right;">
                            <span>日期：<%#string.Format("{0:d}",Eval("AddTime")) %></span>
                        </div>
                        <div class="m_t"></div>
                        <div class="hr" style="padding: 10px 0px"></div>
                        <p><%#Eval("Message")%></p>
                        <div class="m_t"></div>


                    </div>
                </ItemTemplate>
            </asp:FormView>
            <beauty:yuan_foot ID="web_foot" runat="server" />

        </div>
    </form>
</body>
</html>
