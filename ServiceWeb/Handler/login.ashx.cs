using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ServiceWeb.BLL;
using Web;

namespace ServiceWeb.Handler
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {
        Web.User user = new User();
        Model.Member usertity = new Model.Member();
        BLL.UserProfile upf = new BLL.UserProfile();
        Model.UserProfile userprofile = new Model.UserProfile();
        private BLL.Demands demands = new Demands();
        private int Total;
        private int finishNum;
        private Double chance;
        public void ProcessRequest(HttpContext context)
        {

            //if(user.IsLogin)
            //{
            //    //DataSet ds = upf.GetList("UID=" + user.UserEntity.ID);
            //    //context.Response.Write(user.UserEntity.UserName);
            //}
            //else
            //{
            //    string username = System.Web.HttpUtility.HtmlDecode(context.Request.QueryString["username"]);
            //    string pwd = context.Request.QueryString["pwd"];
            //     if (User.ValidUser(username, pwd, ref usertity, ref userprofile))
            //     {
            //         user.Login(usertity.ID, userprofile.ID);
            //         context.Response.Write("OK");
            //     }
            //     else
            //     {
            //         context.Response.Write("on");
            //     }
            //}
            #region 原来的
            if (user.IsLogin)
            {
                DataSet ds = upf.GetList("UID=" + user.UserEntity.ID);
                string cname = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                double strnum = Num() * 100;
                if (strnum > 0)
                {
                    context.Response.Write(user.UserEntity.UserName + "," + cname + "," + SelectTotal() + "," + SelectfinishNum() + "," + strnum.ToString());
                }
                else
                {

                    context.Response.Write(user.UserEntity.UserName + "," + cname + "," + SelectTotal() + "," + SelectfinishNum() + "," + "0");
                }
            }
            else
            {
                HttpCookie cookie = context.Request.Cookies["fcvalidtcode"];
                string yzm = "";
                if (cookie != null)
                {
                    yzm = context.Request.Cookies["fcvalidtcode"].Value.ToLower();
                }
                string username = System.Web.HttpUtility.HtmlDecode(context.Request.QueryString["username"]);
                string pwd = context.Request.QueryString["pwd"];
                string yanzheng = context.Request.QueryString["yzm"];
                if (yanzheng == yzm)
                {

                    if (User.ValidUser(username, pwd, ref usertity, ref userprofile))
                    {
                        user.Login(usertity.ID, userprofile.ID);
                        context.Response.Write("OK");

                    }
                    else
                    {
                        context.Response.Write("no");
                    }
                }
                else
                {
                    context.Response.Write("error");

                }
            }
            #endregion

        }

        //获取诉求总数
        public int SelectTotal()
        {
            DataSet ds = demands.GetList("Status<>3 and UID="+user.UserEntity.ID);
            Total = ds.Tables[0].Rows.Count;
            return Total;
        }
        //办结完成数量
        public int SelectfinishNum()
        {
            DataSet ds = demands.GetList("Status=2 and UID="+user.UserEntity.ID);
            finishNum = ds.Tables[0].Rows.Count;
            return finishNum;
        }
        //完成率
        public Double Num()
        {
            chance = Convert.ToDouble(finishNum) / Convert.ToDouble(Total);
            //Math.Round(chance,2);

            return Math.Round(chance, 2);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
        
    }
}