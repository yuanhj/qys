<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebFoot.ascx.cs" Inherits="ServiceWeb.Handler.WebFoot" %>
<div class="m_t"></div>
<div id="foot_nav">
    <a href="index.aspx" style="margin-left: 50px">首&nbsp;页</a>
    <a href="AddDemands.aspx">企业提交诉求</a>
    <a href="DemandList.aspx">诉求办理台帐</a>
    <a class="w_125"><a href="Neirong.aspx?title=诉求办理流程">诉求办理流程</a>
        <a href="News.aspx">服务动态</a>
        <a href="Neirong.aspx?title=服务机构">服务机构</a>
        <a href="ServiceNews.aspx">服务政策</a>
        <a href="#" target="_blank">安阳企业服务网</a>
</div>
<div class="f_son">
    <%-- <asp:Repeater ID="Rpt_County" runat="server">
            <HeaderTemplate>
                <span class="blod">县区子站：</span>
            </HeaderTemplate>
                <ItemTemplate>
        	         <a href="index.aspx?cid=<%#Eval("ID") %>"><span><%#Eval("Name") %></span></a>
               </ItemTemplate>
            </asp:Repeater>--%>
   <%-- <span class="blod">县区子站：</span>
    <a href="#"><span>安阳市</span></a>
    <a href="#"><span>汤阴县</span></a>
    <a href="#"><span>滑县</span></a>
    <a href="#"><span>林州</span></a>
    <a href="#"><span>内黄</span></a>
    <a href="#"><span>安阳县</span></a>
    <a href="#"><span>文峰区</span></a>
    <a href="#"><span>龙安区</span></a>
    <a href="#"><span>殷都区</span></a>
    <a href="#"><span>北关区</span></a>
    <a href="http://www.hnqyfw.com/" target="_blank">河南省企业服务网</a>--%>
</div>
<div id="footer">
    <p>主办单位：<a href="http://www.aygxj.gov.cn/">安阳市工信局</a> 联系方式：0372-3700051 技术支持：<a href="http://www.0372.cn">安阳信息网</a></p>
</div>
