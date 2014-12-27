using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceWeb.BLL;
using System.Net.Mail;
using Web;

namespace ServiceWeb
{
    public partial class FindPasspwod : System.Web.UI.Page
    {
        private BLL.Member user = new Member();
        private BLL.UserProfile userprofile = new UserProfile();
        private BLL.ForgetPwdLog fpl = new ForgetPwdLog();
        private Model.ForgetPwdLog mfpl = new Model.ForgetPwdLog();
        private Web.User users = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (users.IsLogin)
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void But_OK_Click(object sender, EventArgs e)
        {
            if (uname.Value != "")
            {
                DataSet ds = user.GetList("UserName='" + uname.Value + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (IsValidEmail(emails.Value.Trim()) == true)
                    {
                        DataSet ds2 =userprofile.GetList("UID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString()));
                        if(emails.Value.Trim()==ds2.Tables[0].Rows[0]["Email"].ToString())
                        {
                           
                           
                            string id = ds.Tables[0].Rows[0]["ID"].ToString();
                            string salts = Web.User.Salt();
                            DateTime strdate = System.DateTime.Now;
                            bool bl = Send("332382406@qq.com", "yuanhongjun@126", emails.Value.Trim(), "smtp.qq.com", "安阳企业服务网密码找回链接",
                                "请点击此链接重新设置密码(三天内有效)：" + "http://qys.0372.cn/updatepwd.aspx?id=" +Web.Des.EncryptDes(id)+"&cc="+salts+"&ca="+ConvertDateTimeInt(strdate)); 
                            if(bl==true)
                            {
                                mfpl.UID = Convert.ToInt32(id);
                                mfpl.AddTime = strdate;
                                mfpl.IP = Request.UserHostName;
                                mfpl.Salt = salts.Trim();
                                mfpl.Status = 0;
                                fpl.Add(mfpl);
                                jsb.JsHelper.AlertAndRedirect("发送成功,请及时查看邮件！", "index.aspx");
                            }
                            else
                            {
                                jsb.JsHelper.Alert("发送失败，请检查网络！");

                            }
                            
                        }
                        else
                        {
                            jsb.JsHelper.Alert("邮箱不匹配！");
                        }
                    }
                    else
                    {
                        //jsb.JsHelper.Alert("邮箱格式不正确");
                    }
                }
                else
                {
                    jsb.JsHelper.Alert("用户名不正确！");
                }
            }
            else
            {
               // jsb.JsHelper.Alert("用户名不能为空！");
            }
        }
        ///.NET 正则验证邮箱

        public bool IsValidEmail(string strIn)
        {
            //   Return   true   if   strIn   is   in   valid   e-mail   format. 
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// 发送邮件,返回true表示发送成功
        /// </summary>
        /// <param name="a">发件人邮箱地址；发件人用户名</param>
        /// <param name="b">密码</param>
        /// <param name="c">接受者邮箱地址</param>
        /// <param name="host">SMTP服务器的主机名</param>
        /// <param name="sub">邮件主题行</param>
        /// <param name="body">邮件主体正文</param>
        public bool Send(string a, string b, string c, string host, string sub, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(a, b);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                System.Net.Mail.MailMessage message = new MailMessage(a, c);
                message.Subject = sub;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("发送失败，原因如下:\n "+ ex.Message);
                return false;
            }
           
        }


        ///// <summary>
        ///// 发送邮件
        ///// </summary>
        ///// <param name="ToEmail">邮件目标地址（收件人）</param>
        ///// <param name="FromEmail">邮件来源地址（发件人）</param>
        ///// <param name="Subject">邮件主题</param>
        ///// <param name="Content">邮件的内容</param>
        ///// <param name="UserName">用户名（发件人）</param>
        ///// <param name="UserPwd">用户密码（发件人）</param>
        ///// <param name="Host">主机服务器类型（发件人）：126，163,sina</param>
        ///// <returns>发送结果</returns>
        //public string SendEmail(string ToEmail, string FromEmail, string Subject, string Content, string UserName, string UserPwd, string Host)
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.Host = "smtp." + Host + ".com";
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential(UserName, UserPwd);
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    MailMessage message = new MailMessage(FromEmail, ToEmail);
        //    message.Subject = Subject;
        //    message.Body = Content;
        //    message.BodyEncoding = Encoding.GetEncoding("gb2312");
        //    //message.IsBodyHtml = true;
        //    Attachment data = new Attachment(@"C:\data.txt", MediaTypeNames.Application.Octet);
        //    message.Attachments.Add(data);
        //    try
        //    {
        //        client.Send(message);
        //        return "邮件发送成功！";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "邮件发送失败，失败原因：" + ex.Message;
        //    }
        //}
    }
}