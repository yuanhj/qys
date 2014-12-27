<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Neirong.aspx.cs" Inherits="ServiceWeb.Neirong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   
    <title><%=title %>-安阳企业服务110</title>
      
    <beauty:yuan_head ID="yuan_head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu"  runat="server" />
            <asp:FormView ID="Bind_Post" runat="server" Width="100%">
                <ItemTemplate>
                    <!--weizhi开始-->
                    <div class="weizhi">当前位置：首页><%#Eval("Subject") %></div>
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
