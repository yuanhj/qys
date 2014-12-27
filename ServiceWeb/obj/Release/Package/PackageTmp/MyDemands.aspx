<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDemands.aspx.cs" Inherits="ServiceWeb.MyDemands" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>诉求办理台帐-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/jquery.raty.min.js"></script>
    <script src="Scripts/pinfen.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu" runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>我的诉求</div>
            <!--weizhi结束-->
              <div class="m_t">
            </div>
            <!--qs_lie开始-->
            <div class="qs_list">
                <div class="table_list">
                    <ul class="c_b">
                        <li class="table_title1"><span class="s_w_260">企业名称</span><span class="s_w_300">诉求内容</span><span class="s_w_100">进展情况</span><span class="s_w_100">办理状态</span><span class="s_w_100">提交日期</span><span class="s_w_100" style="border: none;">操作</span></li>
                        <div class="m_t"></div>
                         <asp:Repeater ID="rpt_list" runat="server">
                            <ItemTemplate>
                        <li class="lie_dot"><a href="DemandsDetail.aspx?id=<%#Eval("ID") %>"><span class="s_w_250"><%#Companyname(Eval("UID").ToString()) %></span><span class="s_w_300"><%#Eval("Subject").ToString().Length>26?Eval("Subject").ToString().Substring(0,26):Eval("Subject") %></span><span class="s_w_100"><%#Eval("Working") %></span><span class="s_w_100">[<%#SelectStatus(Eval("Status").ToString()) %>]</span><span class="s_w_100"><%#string.Format("{0:d}",Eval("AddTime")) %></span></a><span class="s_w_100"  >
                                  <%#Eval("Status").ToString()=="0"?"<a href='AddDemands.aspx?id="+Eval("ID")+"&ac=editor' style='color:red; display: inline-block; width: 92px;text-align: center;' >修改</a>":"<a  style='color:black; display: inline-block; width: 92px;text-align: center;' >无</a>" %> </span></li>
                                 </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                 <!--snpages开始-->
            <div class="snpages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True"></webdiyer:AspNetPager>
            </div>

            <!--snpages结束-->
            </div>
            <!--qs_lie结束-->
           
            <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>

    </form>
</body>
</html>
