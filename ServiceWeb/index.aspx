<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ServiceWeb.index" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script type="text/javascript" src="Scripts/index.js"></script>
    <script src="Scripts/jquery.raty.min.js"></script>
    <script src="Scripts/pinfen.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#But_OK").click(function () {
                if ($("#name").val() == '') {
                    alert("用户名不能为空！");
                    return false;
                } else if ($("#pswd").val() == '') {
                    alert("密码不能为空！");
                    return false;
                } else if ($("#yanzheng").val() == '') {
                    alert("验证码不能为空");
                    $("#yanzheng").focus();
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu" runat="server" />
            <!--main开始-->
            <div id="main">
                <!--main上部分开始-->
                <div class="img_news">
                    <div class="pic_slider">
                        <div class="comiis_wrapad" id="slideContainer">
                            <div id="frameHlicAe" class="frame cl">
                                <div class="temp"></div>
                                <div class="block">
                                    <div class="cl">
                                        <ul class="slideshow" id="slidesImgs">
                                            <asp:Repeater ID="Rpt_banner" runat="server">
                                                <ItemTemplate>
                                                    <li><a href="<%#Eval("ImageLinks") %>" target="_blank">
                                                        <img src="<%#Eval("ImagePath") %>" /></a><span class="title1"><h5><%#Eval("Subject") %></h5>
                                                            <%#Eval("Contents") %></span></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div class="slidebar" id="slideBar">
                                        <ul>
                                            <li class="on">1</li>
                                            <li>2</li>
                                            <li>3</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <script type="text/javascript">
                            SlideShow(3000);
                        </script>
                    </div>
                    <div class="m_t">
                    </div>
                    <a href="http://www.ayesn.com/" target="_blank"><img src="images/qys.jpg"  style="border: 0px;"/></a>
                </div>
                <div class="box_news">
                    <asp:FormView ID="FormView1" runat="server">
                        <ItemTemplate>
                            <div class="news_cont">
                                <h3>
                                    <a href="PostDetail.aspx?id=<%#Eval("ID") %>"><%#Eval("Subject").ToString().Length>21?Eval("Subject").ToString().Substring(0,21):Eval("Subject") %></a></h3>
                                <a href="PostDetail.aspx?id=<%#Eval("ID") %>"><span>[<%#NoHTML(ToutiaoCountent().Length<=35?ToutiaoCountent():ToutiaoCountent().Substring(0,35)) %>]</span></a>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                    <img src="images/line.jpg" />
                    <div class="news_list">
                        <ul>
                            <asp:Repeater ID="Rpt_post" runat="server">
                                <ItemTemplate>
                                    <li><a href="PostDetail.aspx?id=<%#Eval("ID") %>"><%#Eval("Subject").ToString().Length>25?Eval("subject").ToString().Substring(0,25):Eval("subject") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="box_login">
                    <div id="login_cont">
                        <%if (a) %>
                        <%{%>
                        <table width='350' height='160'>
                            <tr>
                                <td><span>用户名：<%=usernames %></span></td>
                            </tr>
                            <tr>
                                <td><span>公司名称：<%=cname %>  </span></td>
                            </tr>
                            <tr>
                                <td><span>发布诉求<span style='color: red; margin: 0px;'><%=zongshu %></span>件&nbsp;&nbsp;办结<span style='color: red; margin: 0px;'><%=wancheng %></span>件&nbsp;&nbsp;办结率<span style='color: red; margin: 0px;'><%=wcl%></span>%</span></td>
                            </tr>
                            <tr>
                                <td><span><a href='MyDemands.aspx?uid=<%=uid %>'>
                                    <img src='images/suqiu.jpg' border='0' width='55px' height='30'></a></span><span><a href='UpdateUserpfile.aspx'><img src='images/update_1.jpg' border='0' width='55px' height='30'></a></span><span><a href='Loginout.aspx'><img src='images/exit_1.jpg' border='0' width='55px' height='30'></a></span></td>
                            </tr>
                        </table>
                        <% }
                          else
                          { %>
                        <table class="zcl_table">
                            <tr>
                                <td style="width: 56px">用户名：</td>
                                <td>
                                    <input type="text" id="name" class="zcl_input" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>密码：</td>
                                <td>
                                    <input type="password" id="pswd" class="zcl_input" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>验证码：</td>
                                <td>
                                    <input type="text" id="yanzheng" class="zcl_input zcl_input_yzm" runat="server">
                                    <img src="bao_ValidCode.aspx">
                                </td>
                            </tr>
                        </table>
                        <table class="zcl_table">
                            <tr>
                                <td>
                                    <%--<input type="button" id="But_login" value="登录" class="btn1">--%>
                                    <asp:Button ID="But_OK" runat="server" Text="登录" class="btn1" OnClick="But_OK_Click" />
                                </td>
                                <td>
                                    <a href="Register.aspx" class="btn1">注册</a>
                                </td>
                                <td>
                                    <a href="FindPasspwod.aspx">忘记密码?</a>
                                </td>
                            </tr>
                        </table>
                        <% }%>
                        <ul>
                            <li><span>服务热线：</span><font style="font-family: '微软雅黑'; font-size: 12px;">0372-3700051</font></li>
                            <li><span>地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</span><font style="font-family: '微软雅黑'; font-size: 12px;">市文明大道东段工信大楼</font></li>
                        </ul>

                    </div>
                    <div class="m_t">
                    </div>
                    <a href="mailto:ayqyfwb@163.com"><img src="images/img02.png" style="border: 0px;" /></a>
                </div>
                <!--main上部分结束-->
                <div class="c_b">
                </div>
                <div class="m_t">
                </div>
                <!--main中间部分开始-->
                <div class="main_c">
                    <div class="title">
                        <asp:FormView ID="From_Num" runat="server">
                            <ItemTemplate>
                                <p>
                                    企业诉求共：<span><%#SelectTotal() %>件</span> 办结：<span><%#SelectfinishNum() %>件</span>办结率：<span><%#Num()*100%>%</span>平均办结时间：<span><%#AvgToday(CountyID).ToString()=="0"?"1":AvgToday(CountyID)%>天</span>企业满意度：<div class="stars" data-score="<%#AvgManyi().ToString()=="0"?"5":AvgManyi()%>" style="margin-top: 14px; float: right;"></div>
                                </p>
                            </ItemTemplate>
                        </asp:FormView>
                    </div>
                    <div id="search">
                        <div style="float: left;" id="serch_1">
                            <span style="font-weight: bold; float: left; margin-top: 5px;">企业诉求组合搜索：</span><asp:TextBox ID="title" runat="server"></asp:TextBox>
                        </div>
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
                            <div class="xiala" style="margin-right: 10px;">
                                <asp:DropDownList ID="Drop_Status" runat="server">
                                    <asp:ListItem Value="0">受理状态</asp:ListItem>
                                    <asp:ListItem Value="1">已受理</asp:ListItem>
                                    <asp:ListItem Value="4">办理中</asp:ListItem>
                                    <asp:ListItem Value="3">拒绝受理</asp:ListItem>
                                    <asp:ListItem Value="2">办结完成</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="ButSerch">
                            <input type="button" style="background: url(/images/search.png) no-repeat; width: 98px; height: 35px; border: none; margin-left: 10px;" id="btn_search" />
                        </div>
                    </div>
                    <div class="main_cont_box">
                        <h3>最新诉求</h3>
                        <a href="DemandList.aspx" class="more">查看更多>></a>
                        <ul>
                            <li class="table_title"><span class="s_w_250">企业名称</span><span class="s_w_360">诉求标题</span><span
                                class="s_w_150">受理状态</span><span class="s_w_125">提交日期</span></li>
                           
                            <asp:Repeater ID="Rpt_Demandover" runat="server">
                                <ItemTemplate>
                                    <li><a href="DemandsDetail.aspx?id=<%#Eval("ID") %>"><span class="s_w_250"><%#SelectCompany(Eval("UID").ToString()) %></span><span class="s_w_360"><%#Eval("Subject").ToString().Length>25?Eval("Subject").ToString().Substring(0,25):Eval("Subject") %></span><span
                                        class="s_w_150">[<%#SelectStatus(Eval("Status").ToString()) %>]</span><span class="s_w_125"><%#string.Format("{0:d}",Eval("AddTime")) %></span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="m_t">
                    </div>
                    <div class="main_cont_box">
                        <h3>办理中诉求</h3>
                        <a href="DemandList.aspx" class="more">查看更多>></a>
                        <ul>
                            <li class="table_title"><span class="s_w_250">企业名称</span><span class="s_w_300">诉求内容</span><span class="s_w_60">进展情况</span><span class="s_w_150">办理状态</span><span class="s_w_125">办理日期</span></li>

                          
                            <asp:Repeater ID="Rpt_Demanding" runat="server">
                                <ItemTemplate>
                                    <li><a href="DemandsDetail.aspx?id=<%#Eval("ID") %>"><span class="s_w_250"><%#SelectCompany(Eval("UID").ToString()) %></span><span class="s_w_300"><%#Eval("Subject").ToString().Length>18?Eval("Subject").ToString().Substring(0,18):Eval("Subject")     %></span><span class="s_w_60"><%#Eval("Working") %></span><span
                                        class="s_w_150">[<%#SelectStatus(Eval("Status").ToString()) %>]</span><span class="s_w_125"><%#string.Format("{0:d}",Eval("AddTime")) %></span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="m_t">
                    </div>
                    <div class="main_cont_box">
                        <h3>办结诉求</h3>
                        <a href="DemandList.aspx" class="more">查看更多>></a>
                        <ul>
                            <li class="table_title"><span class="s_w_250">企业名称</span><span class="s_w_360">诉求标题</span><span class="s_w_150">企业满意度</span><span class="s_w_125">办结时间</span></li>
                          
                            <asp:Repeater ID="Rpt_DemandBJ" runat="server">
                                <ItemTemplate>
                                    <li><a href="DemandsDetail.aspx?id=<%#Eval("ID") %>"><span class="s_w_250"><%#SelectCompany(Eval("UID").ToString()) %></span><span class="s_w_360"><%#Eval("Subject") %></span></a><span class="s_w_150"><div class="star" data-score="<%#!string.IsNullOrEmpty(Manyi(Eval("ID").ToString()))&&Manyi(Eval("ID").ToString())!="0"?Manyi(Eval("ID").ToString()):"5" %>" style="margin-top: 3px;"></div>
                                    </span><span class="s_w_125"><%#ResultDates(Eval("ID").ToString())!="0"?ResultDates(Eval("ID").ToString()):"1" %>天</span></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!--main_c中间部分结束-->
                <div class="m_t">
                </div>

                <!--main_b下面部分开始-->
                <div class="main_b">
                    <div class="qy_list">
                        <span>50强企业</span><a href="CompanyLogo.aspx" style="font-size: 12px;">查看更多>></a>
                        <hr style="border-top: 1px solid #116eca;" />
                        <ul>
                            <asp:Repeater ID="rpt_logo" runat="server">
                                <ItemTemplate>
                                    <li><a><%#Eval("Name") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="qy_list">
                        <span>50高企业</span><a href="CompanyLogo.aspx" style="font-size: 12px;">查看更多>></a>
                        <hr style="border-top: 1px solid #116eca;" />
                        <ul>
                            <asp:Repeater ID="rpt_gao" runat="server">
                                <ItemTemplate>
                                    <li><a><%#Eval("Name") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>

                <div class="m_t">
                </div>
                <div class="main_link">
                    <div class="dash_bg">
                        <asp:Repeater ID="Rpt_Member" runat="server">
                            <ItemTemplate>
                                <a><%#Eval("name") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <!--main_b下面部分结束-->
            </div>
            <!--main结束-->
            <div class="m_t">
            </div>
            <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>
        <asp:HiddenField runat="server" ID="hfCurrentCountyId" />
    </form>
</body>
</html>
