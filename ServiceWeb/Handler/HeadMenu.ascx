<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeadMenu.ascx.cs" Inherits="ServiceWeb.Handler.HeadMenu" %>
 <!--header开始-->
                  <div id="header">
    <div id="header_l">
        <div style="width: 270px; text-align: left; height: 32px; line-height: 32px; margin-top: 6px; font-size: 12px; font-family: '宋体'; margin-left: 0px; text-align: center; float: left;" id="datediv"></div>
        <script type="text/javascript" src="Scripts/zhuzhandate.js"></script>

        <div style="width: 210px; height: 35px; overflow: hidden; margin: 0px; padding: 0px;padding: 8px 5px 0 0;background-image:url(../images/top_bg.jpg) repeat-x;">
            <iframe name="weather_inc" src="http://i.tianqi.com/index.php?c=code&id=5" width="200" height="30" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" ></iframe>
        </div>
    </div>
    <div id="header_r">
        <%if(a) %>
        <%{%>
        <span>欢迎您，</span><a href='#' style='color:red;'> <%=usernames %></a><span>！<span>&nbsp;|&nbsp;</span><a  class='logout' href='Loginout.aspx' style='color:red;'>退出<a></span> <a href='index.aspx' class='home'>网站首页</a><span>&nbsp;|&nbsp;</span><a title='设为首页'  href='javascript:;'>设为首页</a>
        <% }else
          { %>
        <a href='Login.aspx' class='dl'>登录</a> <span>|</span> <a href='Register.aspx'>注册</a> <a href='../index.aspx' class='home'>网站首页</a><span>|</span> <a title='设为首页'  href='javascript:;'>设为首页</a>
        <% } %>
    </div>
</div>                                                                                                                   
            <!--header结束-->
            <div class="m_t">
            </div>
            <!--banner开始-->
            <div id="banner" style="height: 226px;">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                    width="1000" height="226">
                    <param name="movie" value="images/banner.swf" />
                    <param name="quality" value="high" />
                    <embed src="images/banner.swf" quality="high"
                        pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                        width="1000" height="226"></embed>
                </object>
            </div>
            <!--banner结束-->
            <!--nav开始-->
            <div id="nav">
                <div id="nav_top">
        	        <a href="index.aspx" class="w_90">首页</a>
                    <a href="AddDemands.aspx" class="w_125">企业提交诉求</a>
                    <a href="DemandList.aspx?ac=1" class="w_125" style="margin-left:6px;">诉求办理台帐</a>
                    <a href="Neirong.aspx?title=诉求办理流程" class="w_125" style="margin-left:6px;">诉求办理流程</a>
                    <a href="News.aspx" class="w_105" style="margin-left:2px;">服务动态</a>
                    <a href="Neirong.aspx?title=服务机构" class="w_105">服务机构</a>
                    <a href="ServiceNews.aspx" class="w_105">服务政策</a>
                    <a href="Tongji.aspx" class="w_105">诉求统计</a>          
            </div>  
                <div class="c_b">
                </div>
                <div class="son_nav1 s_n">
                    <span class="blod" style="color:gray;">县区子站：</span>
                    <span style="color:gray;font-size:12px; _float:left;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">安阳市</span>
                    <span style="color:gray; _float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">汤阴县</span>
                     <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">林州</span>
                     <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">内黄</span>
                     <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">安阳县</span>
                    <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">文峰区</span>
                     <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">龙安区</span>
                    <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px;">殷都区</span>
                     <span style="color:gray;_float:left;font-size:12px;font-family:'微软雅黑';display:inline-block;width:62px;font-size:12px; ">北关区</span>
                </div>
                <div id="nav_right">
                    <a href="http://www.ayesn.com/" target="_blank" >安阳企业服务网</a><a href="http://www.hnqyfw.com/" target="_blank">河南省企业服务网</a>
                </div>
            </div>
            <!--nav结束-->
            <div class="m_t">
            </div>
