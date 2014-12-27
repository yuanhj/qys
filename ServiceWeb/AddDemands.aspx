<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDemands.aspx.cs" Inherits="ServiceWeb.AddDemands" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>企业发布诉求-安阳企业服务110</title>
    <beauty:yuan_head ID="yuan_head" runat="server" />
     <script type="text/javascript" >
         $(document).ready(function () {
             $("#But_Add").click(function () {
                 if ($("#faren").val() == '' || $("input[type=checkbox]:checked").size() == 0 || $("#countyID").find('option:selected').text() == '请选择...' || $("#phone").val() == '' || $("#address").val() == '' || $("#email").val() == '' || $("#title").val==''||$("#txteditor").val()=='') {
                     //$("#userLab").Text("用户名不能为空");
                     alert("*号项为必填项,请填写完整！");
                     return false;
                 } else {
                    // alert($("input[type=checkbox]:checked").size());
                    
                 }
             });
         });
       
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <beauty:head_menu ID="head_menu" runat="server" />
            <!--weizhi开始-->
            <div class="weizhi">当前位置：首页>发布诉求</div>
            <!--weizhi结束-->
            <div class="m_t"></div>
            <!--注册 开始-->
 <div id="bor">
                <div id="lanse">
                   <h3 class="suqiu_title">发布诉求</h3>  
                <div id="w795">
                    <div class="inputer">
                        <ul>
                            <li><span class="name"><font class="color">*</font>公司名称：</span>
                               <asp:TextBox ID="Cname" runat="server" Height="30" Width="260" ReadOnly="True"></asp:TextBox>
                            </li>
                            <li><span class="name"><font class="color">*</font>所属县区：</span>
                                <asp:DropDownList ID="countyID" runat="server" Width="265" Height="30" ></asp:DropDownList>
                            </li>
                            <li>
                                <span class="name"><font class="color">*</font>诉求类型：</span>
                                <div class="wi400">
                                    <asp:CheckBoxList ID="chk"  runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="0" CellSpacing="0" RepeatColumns="6">
                                    </asp:CheckBoxList>
                                </div>
                            </li>
                           
                            <li><span class="name"><font class="color">*</font>法人：</span><asp:TextBox ID="faren" runat="server" Height="30" Width="260" ></asp:TextBox></li>
                            <li><span class="name"><font class="color">*</font>电话：</span><asp:TextBox ID="phone" runat="server" Height="30" Width="260"></asp:TextBox></li>
                            <li><span class="name"><font class="color">*</font>地址：</span><asp:TextBox ID="address" runat="server" Height="30" Width="260"></asp:TextBox></li>
                            <li><span class="name"><font class="color">*</font>邮箱：</span><asp:TextBox ID="email" runat="server" Height="30" Width="260"></asp:TextBox></li>
                            <li><span class="name"><font class="color">*</font>标题：</span><asp:TextBox ID="title" runat="server" Height="30" Width="650"></asp:TextBox></li>
                            <li><span class="name" style="float:left;"><font class="color">*</font>诉求内容：</span><textarea name="txteditor" runat="server" id="txteditor" style="width: 650px; height: 400px; "></textarea></li>
                        </ul>
                    </div>
                    <div style="clear: both;"></div>

   
  <div style="margin-left: 208px; margin-top:20px; padding-bottom:20px;"> <asp:ImageButton ID="But_Add" ImageUrl="~/images/but_sub.jpg" Width="120" Height="32" runat="server" OnClick="But_Add_Click" /></div>
  </div>
  </div>
    <!--注册结束-->
        </div>
             <beauty:yuan_foot ID="web_foot" runat="server" />
            </div>
          
    </form>
</body>
</html>
