// JavaScript Document
       //��֤��������Ƿ�ֹ���ظ���ͣ���ύ����ֹ����㷢������
        //JS�ǿͻ��˽ű�������IE�Ǳ����е�
        //�����֤��
        function GetYZM() {
            //�ı������
            
            //Math.random()��0��1����С����ȡ0�����ǲ���ȡ1
            //document.getElementById("lblUserYZM").innerText = parseInt(Math.random() * 10);
            var varNum1 = parseInt(Math.random() * 10);
            var varNum2 = parseInt(Math.random() * 10);
            var varNum3 = parseInt(Math.random() * 10);
            var varNum4 = parseInt(Math.random() * 10);
            document.getElementById("lblUserYZM").innerText = varNum1.toString() + varNum2.toString() + varNum3.toString() + varNum4.toString();
        }
        //��֤��֤��
        function VaYZM() {
            //1.�����֤��
            var varSysYZM = document.getElementById("lblUserYZM").innerText;
            //2.������������֤��
            //2.1 inputȫ����value
            var varUserYZM = document.getElementById("txtUserYZM").value;
            //3.�Ա�
            if (varSysYZM == varUserYZM) {
                //3.1������ʾ����ȷ��
                document.getElementById("lblUserShowError").innerText = "OK";
                //��ʾ��ķ�����һ��true��boolֵ
                return true;
            }
            else {
                //3.2������ʾ������
                document.getElementById("lblUserShowError").innerText = "NO OK";
                //��ʾ��ķ�����һ��false��boolֵ
                return false;
            }
        }
    
