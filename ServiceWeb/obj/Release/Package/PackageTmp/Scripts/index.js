$().ready(function () {
//    //init login
//    $.ajax({
//        url: "Handler/login.ashx"
//    }).success(function (result) {
//        alert(result);
//        if (result != "" && result != "error") {
           
//            var arry = result.split(",");
//            $("#header_r").html("<span>欢迎您，</span><a href='#' style='color:red;'>" + arry[0] + "</a><span>！<span>&nbsp;|&nbsp;</span><a  class='logout' href='Loginout.aspx' style='color:red;'>退出<a></span> <a href='index.aspx' class='home'>网站首页</a><span>&nbsp;|&nbsp;</span><a title='设为首页'  href='javascript:;'>设为首页</a>");
//            $("#login_cont").html("<div id='tab' style='border-bottom:1px dashed #ddd; padding-bottom: 10px; margin-right:10px;' ><table  width='350' height='160'><tr><td><span>用户名：" + arry[0] + "</span></td></tr><tr><td><span>公司名称：" + arry[1] + "</span></td></tr><tr><td><span>发布诉求<span style='color:red; margin:0px;'>" + arry[2] + "</span>件&nbsp;&nbsp;办结<span style='color:red;margin:0px;'>" + arry[3] + "</span>件&nbsp;&nbsp;办结率<span style='color:red;margin:0px;'>" + arry[4] + "</span>%</span></td></tr><tr><td><span><a href='DemandList.aspx?unames=" + arry[0] + "'><img src='images/suqiu.jpg' border='0' width='55px' height='30'></a></span><span><a href='UpdateUserpfile.aspx'><img src='images/update_1.jpg' border='0' width='55px' height='30'></a></span><span><a href='Loginout.aspx'><img src='images/exit_1.jpg' border='0' width='55px' height='30'></a></span></td></tr></table></div> <ul><li><span>服务热线：</span><font style='font-family: 微软雅黑;font-size: 12px;'>0372-3700051</font></li><li><span>地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</span><font style='font-family: 微软雅黑; font-size: 12px; '>市文明大道东段工信大楼</font></li></ul></div>");
//        } else {
//            $("#header_r").html("<a href='Login.aspx' class='dl'>登录</a> <span>|</span> <a href='Register.aspx'>注册</a> <a href='../index.aspx' class='home'>网站首页</a><span>|</span> <a title='设为首页'  href='javascript:;'>设为首页</a>");
//        }
//    });
    //login enent
    $("#But_login").click(function () {
        var uname = $("#name").val();
        var pswd = $("#pswd").val();
        $.ajax({
            url: "Handler/login.ashx?username=" + encodeURI(uname) + "&pwd=" + pswd + ""
        }).success(function (result) {
            //alert(result);
            if (result != "" && result != "error" && result != "no") {
                window.location.href = "index.aspx";
            }
            else if (result == "error") {
                alert("验证码输入有误！");
                $("#header_r").html("<a href='#'>登录</a> <span>|</span> <a href='#'>注册</a> <a href='#' class='home'>网站首页</a><span>|</span> <a href='#'>设为首页</a>");
            } else if (result == "no") {
                alert("用户名或密码不正确！");
                $("#header_r").html("<a href='#'>登录</a> <span>|</span> <a href='#'>注册</a> <a href='#' class='home'>网站首页</a><span>|</span> <a href='#'>设为首页</a>");
            } else {
                $("#header_r").html("<a href='#'>登录</a> <span>|</span> <a href='#'>注册</a> <a href='#' class='home'>网站首页</a><span>|</span> <a href='#'>设为首页</a>");
            }
        });
    });
    //enter event
    $('.key_ent').on('keydown', function () {
        if (event.keyCode == '13') {
            $('#But_login').click();
        }
    });
    //search
    $('#btn_search').on('click', function () {
        var keytext = $('#title');
        var type = $('#Drop_Dtype');
        var countys = $('#Drop_Danwei');
        var status = $('#Drop_Status');
        var county = $('#Countys');
        var currentcountry = $('#hfCurrentCountyId');
        //if (keytext!="0" || type!="0" || county!="0" || status!="0") {
        //    location.href = 'DemandList.aspx?title=' + keytext.val() + '&dtype=' + type.val() + '&danwei=' + county.val() + '&zt=' + status.val() + '&cid=' + currentcountry.val();
        //}
        var str = "";
        if (keytext.val() != "0") {
            str = "title=" + keytext.val() + "";
        }
        if (str != "" && type.val() != "0") {
            str += "&dtype=" + type.val() + "";
        } else if (str == "" && type.val() != "0") {
            str = "dtype=" + type.val() + "";
        }
        if (str != "" && county.val() != "0") {
            str += "&danwei=" + county.val() + "";
        } else if (str == "" && county.val() != "0") {
            str += "danwei=" + county.val() + "";
        }
        if (str != "" && countys.val() != "0") {
            str += "&countys="+countys.val()+"";
        } else  if(str==""&&countys.val()!="0"){
            str += "countys="+countys+"";
        }
        if (str != "" && status.val() != "0") {
            str += "&zt=" + status.val() + "";
        } else if (str == "" && status.val() != "0") {
            str = "zt=" + status.val() + "";
        }

        if (str == "") {
            location.href = "DemandList.aspx";
        } else {
            location.href = "DemandList.aspx?" + str + "&cid=" + currentcountry.val() + "";
        }

    });
});