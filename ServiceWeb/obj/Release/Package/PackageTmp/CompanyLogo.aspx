<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyLogo.aspx.cs" Inherits="ServiceWeb.CompanyLogo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>重点企业-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/pic_nav.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu" runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>企业标志</div>
            <!--weizhi结束-->
            <div class="pic m_t">
                <div id="tabbox">
                    <ul class="tabs" id="tabs">
                        <li><a href="#">50强企业</a></li>
                        <li><a href="#">50高企业</a></li>
                    </ul>
                    <ul class="tab_conbox" id="tab_conbox">
                        <li class="tab_con">
                            <div class="show">
                                <asp:Repeater ID="Rpt_logo" runat="server">
                                    <ItemTemplate>
                                        <a>
                                           <span><%#Eval("Name") %></span></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="snpages" style="margin: 10px auto;">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" PageSize="100" AlwaysShow="True"></webdiyer:AspNetPager>
                            </div>
                        </li>
                        <li class="tab_con">
                             <div class="show">
                                <asp:Repeater ID="rpt_gao" runat="server">
                                    <ItemTemplate>
                                        <a>
                                          <span><%#Eval("Name") %></span></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="snpages" style="margin: 10px auto;">
                                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged" PageSize="100" AlwaysShow="True"></webdiyer:AspNetPager>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        <div class="m_t"></div>
        <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>
    </form>
</body>
</html>
