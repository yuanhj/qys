<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TongJi.aspx.cs" Inherits="ServiceWeb.TongJi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>诉求统计-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/jquery.raty.min.js"></script>
    <script src="Scripts/pinfen.js"></script>
    <script type="text/javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--ul-->";
            eprnstr = "<!--ulend-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 9);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            //alert(prnhtml);
            window.print();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu" runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>诉求统计</div>
            <!--weizhi结束-->

            <div class="suqiu m_t">
                <!--ul-->
                <table class="tj_table">
                    <tr class="table_title">
                        <td>县区/单位</td>
                        <td>全部</td>
                        <td>已办结</td>
                        <td>办结率</td>
                        <td>平均办结天数</td>
                        <td>企业满意度</td>
                    </tr>
                    <asp:Repeater ID="rpt_tongji" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="font_bold"><%#Eval("Name") %></td>
                                <td><%#SelectTotal(Eval("ID").ToString()) %>件</td>
                                <td><%#SelectfinishNum(Eval("ID").ToString()) %>件</td>
                                <td><%#Num()*100>0?(Num()*100).ToString():"0" %>%</td>
                                <td><%#SelectTotal("ID").ToString()!="0"?""+AvgToday(CountyID)+"天":"无"%></td>
                                <td>
                                    <div class="stars2" data-score="<%#AvgManyi(Eval("ID").ToString()).ToString()=="0"?"5":AvgManyi(Eval("ID").ToString()) %>"></div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>


                <!--ulend-->
            </div>
            <div class="tongji_btn">
                <asp:Button ID="DownLoand" CssClass="btn2" runat="server" Text="下&nbsp;载" OnClick="DownLoand_Click" /><input id="Prints" class="btn2" type="button" value="打&nbsp;印" onclick="preview()" />
            </div>
            <div class="m_t"></div>
            <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>
    </form>
</body>
</html>
