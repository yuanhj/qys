using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ServiceWeb.BLL;
using Web;
using System.Text.RegularExpressions;

namespace ServiceWeb
{
    public partial class index : Web.RequestBase
    {
        BLL.Post post = new BLL.Post();
        BLL.Demands demands = new BLL.Demands();
        BLL.UserProfile userprofile = new BLL.UserProfile();
        BLL.County County = new BLL.County();
        BLL.BannerImg img = new BLL.BannerImg();
        BLL.EmphasisComPany company=new EmphasisComPany();
        Model.Member usertity = new Model.Member();
        Model.UserProfile userprofiles = new Model.UserProfile();
        private BLL.DemandProfile dpfle = new DemandProfile();
        private BLL.DemandsStatus dstatus = new DemandsStatus();
        private Web.Select select = new Select();
        private int Total;
        private int finishNum;
        private Double chance;
        public bool a = false;
        public string usernames = "";
        public string uid = "";
        public string cname = "";
        Web.User users=new User();
        public string zongshu = "";
        public string wancheng = "";
        public string wcl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            hfCurrentCountyId.Value = CountyID.ToString();
            if (!IsPostBack)
            {
                Toutiao(CountyID);
                SqlDataReader dr = demands.DataReaderDemands();
                while (dr.Read())
                {
                    Drop_Dtype.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
                }
                Drop_Dtype.Items.Insert(0, new ListItem("诉求分类", "0"));

                SqlDataReader county_ID = County.DataRead2();
                while (county_ID.Read())
                {
                    
                    Countys.Items.Add(new ListItem(county_ID["Name"].ToString(), county_ID["ID"].ToString()));
                }
                Countys.Items.Insert(0, new ListItem("区/县", "0"));

                SqlDataReader countydr = County.DataReader3();
                while (countydr.Read())
                {
                    Drop_Danwei.Items.Add(new ListItem(countydr["Name"].ToString(), countydr["ID"].ToString()));
                }
                Drop_Danwei.Items.Insert(0, new ListItem("受理单位", "0"));
            }
            if(users.IsLogin)
            {
                DataSet ds = userprofile.GetList("UID=" + users.UserEntity.ID);
                cname = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                usernames = users.UserEntity.UserName;
                uid = users.UserEntity.ID.ToString();
                zongshu = select.SelectTotal(users.UserEntity.ID).ToString();
                wancheng = select.SelectfinishNum(users.UserEntity.ID).ToString();
                if (Convert.ToInt32(wancheng)>0)
                {
                    wcl = select.Num(Convert.ToInt32(zongshu), Convert.ToInt32(wancheng)).ToString();
                }
                else
                {
                    wcl = 0.ToString();
                }
                a = true;
              
            }
        }
        //绑定数据
        public void Toutiao(int cid)
        {
            FormView1.DataSource = post.DataReaderTop(cid);
            FormView1.DataBind();

            Rpt_post.DataSource = post.DataTop("9","Post",cid);
            Rpt_post.DataBind();

            Rpt_Demandover.DataSource =demands.GetListTop("5","Demands",cid);
            Rpt_Demandover.DataBind();

            Rpt_Demanding.DataSource = demands.GetList("Status=4 order by id desc");
            Rpt_Demanding.DataBind();

            Rpt_DemandBJ.DataSource = demands.GetList("Status=2 order by id desc");
            Rpt_DemandBJ.DataBind();

            Rpt_banner.DataSource = img.SelectTop(cid);
            Rpt_banner.DataBind();

            rpt_logo.DataSource = company.GetList(8,"Status=0 and IsTop=1 and CID=1"," id asc");
            rpt_logo.DataBind();

            rpt_gao.DataSource = company.GetList(8, "Status=0 and IsTop=1 and CID=2", " id asc");
            rpt_gao.DataBind();

            //From_Num.DataSource = demands.GetList("CountyID="+cid);
            //From_Num.DataBind();
            From_Num.DataSource = demands.GetAllList();
            From_Num.DataBind();

            Rpt_Member.DataSource = County.GetList("Recommend=1 and Status>-1 order by Paixu asc");
            Rpt_Member.DataBind();


        }
        //新闻头条
        public string ToutiaoCountent()
        {
            
            string content = "";
            SqlDataReader reader = post.DataReaderTop(CountyID);
            while (reader.Read())
            {
                content =reader["Message"].ToString();  
            }
            return NoHTML(content);
        }
        //查询公司名
        public string SelectCompany(string id)
        {
            DataSet ds = userprofile.GetList("UID="+Convert.ToInt32(id));
            string company="";
            if (ds.Tables[0].Rows.Count > 0)
            {
                 company = ds.Tables[0].Rows[0]["CompanyName"].ToString();
            }
            return company;
        }
        //返回状态
        public string SelectStatus(string status)
        {
            switch (status)
            {
                case "0": return "未受理";
                    break;
                case "1": return "已受理";
                    break;
                case "2": return "办结完成";
                    break;
                case "3": return "拒绝办理";
                    break;
                case "4": return "办理中";
                    break;
                default: return "";
                    break;
            }
        }

        //获取诉求总数
        public int SelectTotal()
        {
            DataSet ds = demands.GetList("Status not in (0,3)");
            Total=ds.Tables[0].Rows.Count;
            return Total;
        }
        //办结完成数量
        public int SelectfinishNum()
        {
            DataSet ds = demands.GetList("Status=2");
            finishNum = ds.Tables[0].Rows.Count;
            return finishNum;
        }
        //完成率
        public Double Num()
        {
            chance =Convert.ToDouble(finishNum) / Convert.ToDouble( Total);
            //Math.Round(chance,2);
            
            return Math.Round(chance, 2);
        }
        //平均办结时间
        public string AvgToday(int countyID)
        {
            DataSet ds = demands.GetAvgDay(countyID);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        //满意度
        public string Manyi(string id)
        {
            DataSet ds =dpfle.AvgEvaluate("DID="+Convert.ToInt32(id));
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "5";
            }
           
        }
        //获取单条的办结时间
        public  string ResultDates(string id)
        {
            DataSet ds = demands.ResultDate(Convert.ToInt32(id));
            return ds.Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// 获取某一个县区的平均满意度
        /// </summary>
        /// <returns></returns>
        public string AvgManyi()
        {
           
            DataSet ds = dpfle.AvgCountyEvaluate(CountyID);
            return ds.Tables[0].Rows[0][0].ToString();
        }

      
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
                RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
                RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        protected void But_OK_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["fcvalidtcode"];
            string yzm = "";
            if (cookie != null)
            {
                yzm = Request.Cookies["fcvalidtcode"].Value.ToLower();
            }
            string yanzheng = this.yanzheng.Value;
            if (yanzheng == yzm)
            {

                if (Web.User.ValidUser(this.name.Value,this.pswd.Value, ref usertity, ref userprofiles))
                {
                    users.Login(usertity.ID, userprofiles.ID);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    jsb.JsHelper.Alert(Page,"用户名或密码不正确！");
                }
            }
            else
            {
                jsb.JsHelper.Alert(Page, "验证码输入不正确！");
            }
        }

    }
}