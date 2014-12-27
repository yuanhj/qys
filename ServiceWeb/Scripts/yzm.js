// JavaScript Document
       //验证码的作用是防止你重复不停的提交，防止你随便发送请求
        //JS是客户端脚本，是在IE那边运行的
        //获得验证码
        function GetYZM() {
            //文本框清空
            
            //Math.random()是0到1，最小可以取0，但是不能取1
            //document.getElementById("lblUserYZM").innerText = parseInt(Math.random() * 10);
            var varNum1 = parseInt(Math.random() * 10);
            var varNum2 = parseInt(Math.random() * 10);
            var varNum3 = parseInt(Math.random() * 10);
            var varNum4 = parseInt(Math.random() * 10);
            document.getElementById("lblUserYZM").innerText = varNum1.toString() + varNum2.toString() + varNum3.toString() + varNum4.toString();
        }
        //验证验证码
        function VaYZM() {
            //1.获得验证码
            var varSysYZM = document.getElementById("lblUserYZM").innerText;
            //2.获得你输入的验证码
            //2.1 input全部点value
            var varUserYZM = document.getElementById("txtUserYZM").value;
            //3.对比
            if (varSysYZM == varUserYZM) {
                //3.1给出提示（正确）
                document.getElementById("lblUserShowError").innerText = "OK";
                //表示你的方法是一个true的bool值
                return true;
            }
            else {
                //3.2给出提示（错误）
                document.getElementById("lblUserShowError").innerText = "NO OK";
                //表示你的方法是一个false的bool值
                return false;
            }
        }
    
