<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="ServiceWeb.News" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
               <beauty:head_menu ID="head_menu"  runat="server" />
                <!--weizhi开始-->
                <div class="weizhi">当前位置：首页>服务动态</div>
                <!--weizhi结束-->
                <div class="m_t"></div>
                <!--qs_lie开始-->
                <div class="qs_lie">
                    <ul>
                        <li class="table_title2"><span class="lie_260" style="text-align:center;">区县</span><span class="lie_420" style="text-align:center; ">标题</span><span class="lie_99" style="text-align:center; width:300px;">提交日期</span></li>
                    </ul>
                    <div class="m_t"></div>
                    <div class="table_lie">
                        <ul>
                            <asp:Repeater ID="rpt_Newslist" runat="server">
                                <ItemTemplate>
                                    <li><a href="PostDetail.aspx?id=<%#Eval("ID") %>"><span class="lie_240"><%#CountyName( Eval("CountyID").ToString()) %></span><span class="lie_420"><%#Eval("Subject").ToString().Length>26?Eval("Subject").ToString().Substring(0,26):Eval("Subject").ToString() %></span><span class="lie_99" style="text-align:center;width:260px;"><%#string.Format("{0:d}",Eval("AddTime")) %></span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!--qs_lie结束-->
                    <!--snpages开始-->
                    <div class="snpages">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" PageSize="10" OnPageChanged="AspNetPager1_PageChanged"></webdiyer:AspNetPager>
                    </div>

                    <!--snpages结束-->
                </div>
                              <beauty:yuan_foot ID="web_foot" runat="server" />

            </div>
        </form>
</body>
</html>
