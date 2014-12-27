<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandsDetail.aspx.cs" Inherits="ServiceWeb.DemandsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>诉求台帐详情-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
   <script src="Scripts/nei.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.8.1.min.js"></script>
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
            <div class="m_t"></div>
            <div id="details">
                <asp:FormView ID="Bind_Demands" runat="server">
                    <ItemTemplate>
                        <h3><%#Eval("Subject") %></h3>
                        <div style="width: 858px;">
                            <span>企业名称：</span><%#Companyname(Eval("UID").ToString()) %>&nbsp;&nbsp;&nbsp;&nbsp;<span>求诉编号：</span></span><%#Eval

("Serial") %>&nbsp;&nbsp;&nbsp;&nbsp;<span>办理状态：</span><%#SelectStatus(Eval("Status").ToString()) %>&nbsp;&nbsp;&nbsp;&nbsp;<span>诉求类别：</span><%#SelectType(Eval("DTypeID").ToString()).Substring(0,SelectType(Eval("DTypeID").ToString()).Length-1) %>
                        </div>
                        <div class="m_t"></div>
                        <div class="hr" style="padding: 10px 0px"></div>
                        <%#Eval("Contents")%>
                        <div class="m_t"></div>
                        <div class="data">
                            <span>提交时间：</span><%#string.Format("{0:d}",Eval("AddTime")) %>&nbsp;&nbsp;&nbsp;&nbsp;<%--<span>办理时间：</span>2013-11-08--%>&nbsp;&nbsp;&nbsp;&nbsp;<%--<span>办结时间：</span>2013-11-11</div>--%>
                    </ItemTemplate>
                </asp:FormView>
                <asp:Repeater ID="Rpt_DemandProfile" runat="server">
                    <ItemTemplate>
                        <div class="details_list" style="margin-top: 20px;">
                            <span class="ul_title">诉求编号：<%#SelectNumaber(Eval("DID").ToString()) %>_<%=Nums++ %></span><div style="padding: 15px 50px; text-align: left; line-height: 28px; font-size: 12px;">
                                <span>办理单位：</span><%#GetCounty(Eval("PID").ToString()) %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <span>办理部门：</span><%#GetDepartmentName(Eval("PID").ToString()) %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <span>办理人员：</span><%#GetName(Eval("PID").ToString()) %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <span>联系电话：</span><%#GetMobile(Eval("PID").ToString()) %><br />
                                <span>转办时间：</span><%#string.Format("{0:d}",Eval("AddTime")) %>&nbsp;&nbsp;&nbsp;&nbsp;
               <span>办理期限：</span><%#RequeirDay(Eval("ExpireTime").ToString(),Eval("AddTime").ToString()) %>(截至<%#string.Format("{0:d}",Eval("ExpireTime")) %>)&nbsp;&nbsp;&nbsp;&nbsp; <span>回复时间：</span><%#Eval("IsReply").ToString()=="1"?Eval("ReplyTime"):"[<span style='color:#C30;font-family:'宋体';font-size:12px;'>尚未回复</span>]" %><br />
                                <span>办理事项：</span><%#Eval("Requirement") %><br />
                                <span>回复内容：</span><%#Eval("IsReply").ToString()=="1"?"<span style='color:#C30;font-family:'宋体';font-size:12px;'>"+Eval("Reply")+"</span>":"[<span style='color:#C30;font-family:'宋体';font-size:12px;'>尚未回复</span>]" %><br />
                                <%#Eval("IsReply").ToString()=="1"?"<span style='float:left;'>企业满意度：</span><div class='de-star' rel="+Server.UrlEncode(Web.Des.EncryptDes(Eval("id").ToString()))+" data-score="+Eval("evaluate")+" style='margin-top:3px;'></div>":""%>
                                
                            </div>
                        </div>
                        <div class="m_t"></div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="c_b"></div>
                <div class="m_t"></div>
                <div class="details_list">
                    <asp:FormView ID="DemandsOver" runat="server">
                        <ItemTemplate>
                            <span class="span_btn" style="color: #fff; font-weight: bold;">办结总结</span>
                            <div style="padding: 0px 30px 10px 30px; text-align: left; line-height: 28px;">
                                <%#Eval("Status").ToString()=="2"?"<p style='color: #FF0000; font-size: 15px; line-height: 25px;'>"+Eval("Result")+"</p>":"[<span style='color:#C30;font-family:'宋体';font-size:12px;'>尚未办结</span>]" %>
                                 <%#Eval("Status").ToString()=="2"?"<div style='margin-top: 5px;'></div><span style=' float: left;' >企业综合满意度：</span><div class='starss2' data-score="+Manyi(Eval("ID").ToString())+" style=' margin-top:3px; float: right; margin-right:565px;'></div>":"" %>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                </div>
            </div>
            <div class="m_t"></div>
            <beauty:yuan_foot ID="web_foot" runat="server" />

        </div>

    </form>
</body>
</html>
