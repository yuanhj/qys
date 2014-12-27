using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServiceWeb.BLL;
using Web;

namespace ServiceWeb
{
    public partial class DemandList : Web.RequestBase
    {
        BLL.Demands demands = new BLL.Demands();
        BLL.DemandProfile dpf = new BLL.DemandProfile();
        BLL.UserProfile userpfile = new BLL.UserProfile();
        BLL.PageManager pagemanager = new BLL.PageManager();
        BLL.County County = new BLL.County();
        BLL.Member user = new BLL.Member();
        private BLL.Department dpt = new Department();
        private string strsqls = "";
        private string stravg = "";
        private string users = "";
        private int pid;
        private int Total;
        private int finishNum;
        private Double chance;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

               if(!string.IsNullOrEmpty(Request.QueryString["ac"]))
               {
                   Binds("select * from Demands where  Status not in (0,3)  order by id desc");
               }
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
                string unames = Request.QueryString["unames"];
                if (string.IsNullOrEmpty(unames))
                {
                    SelectData();
                   // SelectFrom();
                }
                else
                {
                    DataSet ds = user.GetList("UserName='" + unames + "'");
                    rpt_list.DataSource = demands.GetList("UID=" + ds.Tables[0].Rows[0]["ID"] + " and  Status not in (0,3)  order by id desc");
                    rpt_list.DataBind();
                }
            }

        }
        public void Binds(string sql)
        {
            string Sql = sql;
            int CurrentPage = AspNetPager1.CurrentPageIndex;
            int PageSize = AspNetPager1.PageSize;
            int RecordCount;
            DataSet ds = pagemanager.GetPage(Sql, CurrentPage, PageSize, out RecordCount);
            if(ds.Tables[0].Rows.Count>0)
            {
                AspNetPager1.RecordCount = RecordCount;
                rpt_list.DataSource = ds;
                rpt_list.DataBind();
            }
            else
            {
                results.EnableViewState = true;
                results.Text = "<div style='margin-left:400px;'><span style='font-size:12px; font-family：宋体;'>对不起，没有搜索到您查找的内容</span></div>";
            }
        }
        public void BindsNum()
        {
            From_Num.DataSource = demands.ReturnDemands(strsqls);
            From_Num.DataBind();
        }
        public string Companyname(string uid)
        {
            if (uid != "")
            {
                return userpfile.GetList("UID=" + Convert.ToInt32(uid)).Tables[0].Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "";
            }
        }
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
        /// <summary>
        /// 模糊查询
        /// </summary>
        public void SelectData()
        {
            string title = Request.QueryString["title"];
            string dtype = Request.QueryString["dtype"];
            string danwei = Request.QueryString["danwei"];
            string zt = Request.QueryString["zt"];
            string content = Request.QueryString["Contents"];
            string username = Request.QueryString["username"];
            string dcid = Request.QueryString["dcid"];
            string countys = Request.QueryString["countys"];
            string str = "";
            if (!string.IsNullOrEmpty(title))
            {
                str = "Subject like '%" + title + "%' ";
            }
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(dtype))
            {
                str = str + " and DTypeID like  '%" + dtype + "%'";
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(dtype))
            {
                str = "DTypeID like  '%" + dtype + "%'";
            }

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(danwei))
            {
                str = str + " and CountyID=" + Convert.ToInt32(danwei) + "";
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(danwei))
            {
                str = "CountyID=" + Convert.ToInt32(danwei);
            }

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(zt))
            {
                str = str + " and Status=" + Convert.ToInt32(zt) + "";
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(zt))
            {
                str = "Status=" + Convert.ToInt32(zt);
            }

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(dcid))
            {
                str = str + " and DepartmentCID=" + Convert.ToInt32(dcid) + "";
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(dcid))
            {
                str = "DepartmentCID=" + Convert.ToInt32(dcid);
            }


            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(content))
            {
                DataSet ds = userpfile.GetList("CompanyName like '%" + content + "%'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    str = str + " and Subject like '%" + content + "%'";
                }
               
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(content))
            {
                DataSet ds = userpfile.GetList("CompanyName like '%" + content + "%'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    str = "Subject like '%" + content + "%'";
                }
                
            }

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(username))
            {
                DataSet ds = userpfile.GetList("CompanyName like '%" + username + "%'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    users = ds.Tables[0].Rows[0]["UID"].ToString();
                    str = str + "and UID=" + users;
                }
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(username))
            {
                DataSet ds = userpfile.GetList("CompanyName like '%" + username + "%'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    users = ds.Tables[0].Rows[0]["UID"].ToString();
                    str = "UID=" + users + "";

                }
            }
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(countys))
            {
                DataSet ds = dpt.SelectID(Convert.ToInt32(countys));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pid = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    str = str + "and pid=" + pid + "";
                }
            }
            else if (string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(countys))
            {
                DataSet ds = dpt.SelectID(Convert.ToInt32(countys));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pid = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    str = "pid=" + pid + "";
                }
            }


            if (string.IsNullOrEmpty(Request.QueryString["ac"]) && string.IsNullOrEmpty(str))
            {
                results.EnableViewState = true;
                results.Text = "<div style='margin-left:400px;'><span style='font-size:12px; font-family：宋体;'>对不起，没有搜索到您查找的内容</span></div>";
            }
          
            if (!string.IsNullOrEmpty(str))
            {
                Binds("select * from VDemandsProfile where " + str + "  and  Status not in (0)  order by id desc");
                strsqls = "select * from VDemandsProfile where " + str + "  and  Status not in (0)  order by id desc";
                stravg = "select AVG(DateDiff(DAY,AddTime,DoneTime)) from VDemandsProfile where " + str + "  and  Status not in (0) ";
                BindsNum();
                SelectTotal();
                SelectfinishNum();
            }
            else
            {
                //Binds("select * from Demands where  Status not in (0,3)   order by id desc");
                //strsqls = "select * from Demands where  Status not in (0,3)   order by id desc";
                //stravg ="select AVG(DateDiff(DAY,AddTime,DoneTime)) from Demands where  Status not in (0,3)";
                //BindsNum();
                //SelectTotal();
                //SelectfinishNum();
               
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            string unames = Request.QueryString["unames"];
            if (unames == "" || unames == null)
            {
                SelectData();
                //SelectFrom();
            }
            else
            {

                DataSet ds = user.GetList("UserName='" + unames + "'");
                rpt_list.DataSource = demands.GetList("UID=" + ds.Tables[0].Rows[0]["ID"]);
                rpt_list.DataBind();
            }
        }

        protected void But_Serch_Click(object sender, ImageClickEventArgs e)
        {
            //选择企业或者内容
            if (companyname.Checked == true&&content.Checked==false)
            {
                Response.Redirect("DemandList.aspx?username=" + this.title.Value + "&cid=" + CountyID);
            }
            if (content.Checked == true&&companyname.Checked==false)
            {
                Response.Redirect("DemandList.aspx?Contents=" +this.title.Value+ "&cid=" + CountyID);
            }
            if (companyname.Checked == false && content.Checked == false)
            {
                Response.Redirect("DemandList.aspx?cid=" + CountyID);
            }
            if(companyname.Checked==true&&content.Checked==true)
            {
                Response.Redirect("DemandList.aspx?username=" + this.title.Value + "&cid=" + CountyID+"&Contents=" + this.title.Value);
            }
        }

        public int SelectTotal()
        {
            DataSet ds = demands.ReturnDemands(strsqls);
            Total = ds.Tables[0].Rows.Count;
            return Total;
        }
        //办结完成数量
        public int SelectfinishNum()
        {
            DataSet ds = demands.ReturnDemands(strsqls);
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
        public string AvgToday()
        {
            DataSet ds = demands.GetAvgDay2(stravg);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// 获取某一个县区的平均满意度
        /// </summary>
        /// <returns></returns>
        public string AvgManyi(string countyid)
        {
            DataSet ds = dpf.AvgCountyEvaluate(Convert.ToInt32(countyid));
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {

                return "5";
            }
        }

        protected void Shaixuan_But_Click(object sender, ImageClickEventArgs e)
        {
            string dtype = this.Drop_Dtype.SelectedValue;
            string danwei = this.Countys.SelectedValue;
            string zt = this.Drop_Status.SelectedValue;
            string countys = this.Drop_Danwei.SelectedValue;
            string str = "";

            if (dtype != "0")
            {
                str = "dtype=" + dtype;
            }
            if (danwei != "0")
            {
                str = str + "&danwei=" + danwei;
            }
            if (zt != "0")
            {
                str = str + "&zt=" + zt;
            }
            if (countys != "0")
            {
                str = str + "&countys=" + countys;
            }
            if (str == "")
            {
                Response.Redirect("DemandList.aspx?cid=" + CountyID);
            }
            else
            {
                Response.Redirect("DemandList.aspx?" + str + "&cid=" + CountyID);
            }
        }
    }
}