$(function () {
    $("#But_login").click(function () {
        var uname = $("#name").val();
        var pswd = $("#pswd").val();
        var yz = $("#yanzheng").val();
        if (uname == "") {
            alert("用户名不能为空！");
            return;
        }
        if (pswd == "") {
            alert("密码不能为空！");
            return;
        }
        if (yz == "") {
            alert("验证码不能为空！");
            return;
        }
        $.ajax({
            url: "Handler/login.ashx?username=" + encodeURI(uname) + "&pwd=" + pswd + "&yzm=" + yz + ""
        }).success(function (result) {
            if (result != "" && result != "error" && result != "no") {
               
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

})