// JavaScript Document
  window.onload = $(function () {
               $.ajax({
                   url: "Handler/login.ashx"
               }).success(function (result) {
                   if (result != "" && result != "error") {
                       var arry = result.split(",");
                       $("#header_r").html("<span>欢迎您,</span><a href='#' style='color:red;'>" + arry[0] + "</a><span>！<span>|</span><a  class='logout' href='Loginout.aspx' style='color:red;'>退出<a></span> <a href='index.aspx' class='home'>网站首页</a><span>|</span><a title='设为首页' href='javascript:;'>设为首页</a>");
                   } else {
                       $("#header_r").html("<a href='Login.aspx' class='dl'>登录</a> <span>|</span> <a href='Register.aspx'>注册</a> <a href='../index.aspx' class='home'>网站首页</a><span>|</span> <a title='设为首页' href='javascript:;'>设为首页</a>");
                   }
               });
  })

