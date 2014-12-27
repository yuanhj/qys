<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandList.aspx.cs" Inherits="ServiceWeb.DemandList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            <div class="weizhi">当前位置：首页>企业求诉办理台账</div>
            <!--weizhi结束-->
            <div class="m_t"></div>
            <!--search2开始-->
            <div id="search2">
                <table width="700" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td width="500"><span style="font-weight: bold; float: left; margin-top: 5px;">企业诉求组合搜索：</span><input style="height: 30px; width: 220px; border: 1px solid #d6d6d6; padding-left: 25px; background: #fff url(images/search01.jpg) left center no-repeat; line-height: 30px;" type="text" placeholder="请输入关键词" id="title" runat="server" /></td>
                        <td width="20">
                            <asp:CheckBox ID="companyname" runat="server"  Checked="True"/></td>
                        <td width="70" align="left">企业名称</td>
                        <td width="20">
                            <asp:CheckBox ID="content" runat="server" Checked="True" />
                        </td>
                        <td width="70" align="left">诉求标题</td>
                        <td width="60">
                            <asp:ImageButton ID="But_Serch" ImageUrl="~/images/search.png" runat="server" OnClick="But_Serch_Click" Height="30" /></td>
                    </tr>
                </table>
            </div>
            <!--search2结束-->
            <div class="m_t"></div>
            <!--selectqs开始-->
            <div id="selectqs">
                <div class="select_border">
                    <div class="xiala">
                        <asp:DropDownList ID="Drop_Dtype" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="select_border">
                    <div class="xiala">
                        <asp:DropDownList ID="Countys" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="select_border">
                    <div class="xiala">
                        <asp:DropDownList ID="Drop_Danwei" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="select_border">
                    <div class="xiala">
                        <asp:DropDownList ID="Drop_Status" runat="server">
                            <asp:ListItem Value="0">受理状态</asp:ListItem>
                            <asp:ListItem Value="1">已受理</asp:ListItem>
                            <asp:ListItem Value="4">办理中</asp:ListItem>
                            <asp:ListItem Value="3">拒绝受理</asp:ListItem>
                            <asp:ListItem Value="2">办结完成</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="searchmenu">
                    <asp:ImageButton ID="Shaixuan_But" runat="server" Text="筛选" ImageUrl="images/saixuan.jpg" OnClick="Shaixuan_But_Click" />
                </div>
                <div class="title2">
                  
                    <asp:FormView ID="From_Num" runat="server"  >
                        <ItemTemplate>
                    <table>
                        <tr>
                            <td>共：<span><%#SelectTotal() %>件</span>&nbsp;&nbsp;办结：<span><%#SelectfinishNum() %>件</span>办结率：<span><%#Num()*100 %>%</span>平均办结时间：<span><%#AvgToday().ToString()=="0"?"1":AvgToday() %>天</span></td>
                        </tr>
                        <tr>
                            <td><span style="display: inline-block;float: left;width:80px;color:#444;">企业满意度：</span><div class="starss" data-score="<%#AvgManyi(Eval("ID").ToString()).ToString()=="0"?"5":AvgManyi(Eval("ID").ToString())%>" style="float: right; margin-top:2px; margin-right:45px;"></div></td>
                        </tr>
                    </table>
                         </ItemTemplate>
                    </asp:FormView>
                </div>
            </div>
            <!--selectqs结束-->
            <div class="m_t"></div>
            <!--qs_lie开始-->
            <div class="qs_lie">
                <ul>
                    <li class="table_title2">
                        <span class="lie_260">企业名称</span>
                        <span class="lie_420">诉求标题</span>
                        <span class="lie_110">进展情况</span>
                        <span class="lie_110">办理状态</span>
                        <span class="lie_99">提交日期</span>
                    </li>
                </ul>
                <div class="m_t"></div>
                <div class="table_lie">
                    <ul>
                        <asp:Repeater ID="rpt_list" runat="server">
                            <ItemTemplate>
                                <li><a href="DemandsDetail.aspx?id=<%#Eval("ID") %>"><span class="lie_240"><%#Companyname(Eval("UID").ToString()) %></span><span class="lie_420"><%#Eval("Subject").ToString().Length>26?Eval("Subject").ToString().Substring(0,26):Eval("Subject") %></span><span class="lie_110"><%#Eval("Working") %></span><span class="lie_110" style="margin-left: 13px;">[<%#SelectStatus(Eval("Status").ToString()) %>]</span><span class="lie_99"><%#string.Format("{0:d}",Eval("AddTime")) %></span></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                 <asp:Literal ID="results" runat="server" EnableViewState="False"></asp:Literal>
                <!--qs_lie结束-->
                <!--snpages开始-->
                <div class="snpages">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" PageSize="8" AlwaysShow="True"></webdiyer:AspNetPager>
                </div>

                <!--snpages结束-->
            </div>
            <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>
    </form>
</body>
</html>
