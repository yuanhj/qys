<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDemand.aspx.cs" Inherits="ServiceWeb.Admin.Shuqiushouli.SelectDemand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <link href="../css/dpl-min.css" rel="stylesheet" />
    <link href="../css/bui-min.css" rel="stylesheet" />
    <script src="../js/bui-min.js"></script>
    <script src="../js/bui.js"></script>
    <script src="../js/jquery-1.8.1.min.js"></script>
    <script language="javascript" type="text/javascript">//jQuery代码
        $().ready(function () {
            $('#lbtWtr').bind('click', function () {
                var template = '<li class="wtr rbl new" rel="0"><label>姓名：</label><input type="text" name="name" value="" class="kuang2" /><label>身份证号：</label><input type="text" name="idcode" value=""/><label>手机号：</label><input type="text" name="mobile" value=""/><span class="btn btnwtr_del">删除</span></li>';
                $(template).insertBefore($('.ul-wtr').find('li').slice(-1));
            });

        });
     </script>
</head>
<body>
     <ul class="ul-wtr ma120">
         <li id="liwtrEmpty" class="wtr rbl new" rel="0">
             sdfsdfsdf
             sdfsdfsdfsf
             333333333
         </li>
         <li><input type="button" onclick="javascript:;" id="lbtWtr"></li>
     </ul>
</body>
</html>
