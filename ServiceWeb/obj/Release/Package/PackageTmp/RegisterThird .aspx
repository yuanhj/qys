<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterThird .aspx.cs" Inherits="ServiceWeb.RegisterThird" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>完成注册-安阳企业服务网</title>
   <beauty:yuan_head ID="yuan_head" runat="server" />
    <script src="Scripts/nei.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $$ = function (id) { return document.getElementById(id); };
        var time = 3;
        var href_url = "index.aspx";
        function url() {
            if (time < 0) { window.location.href = href_url; }
            else { $$("second").innerHTML = time--; }
        }



</script>
</head>
<body>
    <form id="form1" runat="server">
            <div id="container">
           <beauty:head_menu ID="head_menu"  runat="server" />
            <!--weizhi开始-->
    <div class="weizhi">当前位置：首页>企业注册</div>
    <!--weizhi结束-->
    <div class="m_t"></div>
    <!--注册 开始-->
  <div id="bor">
  <div id="w795">
  <img src="images/step_03.jpg"/>
  <div style=" text-align:center; margin:50px auto;">
      <img src="images/gx.jpg" /><br />
     <div id="url">该页面将在<span id="second"></span>秒后进行跳转，您可以<a href="index.aspx">点击这里</a>立即跳转。</div>
  </div>
  </div>
  </div>
<script type="text/javascript" language="javascript">setInterval("url()", 1000);</script>
    <!--注册结束-->
       <beauty:yuan_foot ID="web_foot" runat="server" />
        </div>

    </form>
</body>
</html>
