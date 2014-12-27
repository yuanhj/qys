using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.Admin.Demand
{
    public partial class DemandProfileshow : System.Web.UI.Page
    {
        BLL.DemandProfile dpfile = new BLL.DemandProfile();
        BLL.Department dpt = new BLL.Department();
        BLL.County county = new BLL.County();
        public int incount;
        public int npage, cpage;
        public int pageindex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binds();
                ViewState["pageindex"] = 0;
                BindData();
            }
        }      
        public void Binds()
        {

            this.Repeater1.DataSource = dpfile.GetList2();
            this.Repeater1.DataBind();
        }
        #region 查看诉求办结信息
        public string GetPid(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                string DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                return DepartmentName;
            }
            else
            {
                return "未知";
            }

        }
        public string GetName(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                string DepartmentName = ds.Tables[0].Rows[0]["UserName"].ToString();
                return DepartmentName;
            }
            else
            {
                return "未知";
            }

        }
        public string GetMobile(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID=" + id);
                string DepartmentName = ds.Tables[0].Rows[0]["Mobile"].ToString();
                return DepartmentName;
            }
            else
            {
                return "未知";
            }

        }
        public string GetCounty(string id)
        {
            if (id != "")
            {
                DataSet ds = dpt.GetList("ID="+id);
                DataSet ds2 = county.GetList("ID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["CountyID"]));
                return ds2.Tables[0].Rows[0]["Name"].ToString();
            }
            else
            {
                return "未知";
            }
        }
        #endregion

        protected void LnkBtnOne_Click(object sender, EventArgs e)
        {
            LabNowPageNumber.Text = "1";
            BindData();
        }

        protected void LnkBtnUp_Click(object sender, EventArgs e)
        {
            LabNowPageNumber.Text = Convert.ToString(Convert.ToInt32(LabNowPageNumber.Text) - 1);
            BindData();
        }

        protected void LnkBtnNext_Click(object sender, EventArgs e)
        {
            LabNowPageNumber.Text = Convert.ToString(Convert.ToInt32(LabNowPageNumber.Text) + 1);
            BindData();
        }

        protected void LnkBtnBack_Click(object sender, EventArgs e)
        {
            LabNowPageNumber.Text = LabAllPageNumber.Text;
            BindData();
        }
        private void BindData()
        {
            DataTable objTable = new DataTable();
            DataSet ds1 = dpfile.GetAllList();    //获取数据集   
            objTable = ds1.Tables[0];
            if (objTable != null && objTable.Rows.Count > 0)
            {
                DataView objView = objTable.DefaultView; 
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = objView;
                ps.AllowPaging = true;//是否可以分页
                ps.PageSize = 7;//显示数量
                int curpage = Convert.ToInt32(LabNowPageNumber.Text);//取得当前页的页码
                ps.CurrentPageIndex = curpage - 1;
                LnkBtnOne.Enabled = true;
                LnkBtnUp.Enabled = true;
                LnkBtnNext.Enabled = true;
                LnkBtnBack.Enabled = true;
                if (ps.IsFirstPage)//如果是第一页
                {
                    LnkBtnOne.Enabled = false;//不显示第一页按钮
                    LnkBtnUp.Enabled = false;//不显示上一页按钮
                }
                if (ps.IsLastPage)//如果是最后一页
                {
                    LnkBtnNext.Enabled = false;//不显示下一页按钮
                    LnkBtnBack.Enabled = false;//不显示最后一页按钮
                }
                LabAllPageNumber.Text = Convert.ToString(ps.PageCount);//获取总页码
                Repeater1.DataSource = ps;//给Repeater数据源
                Repeater1.DataBind();//绑定数据源

            }
        }
    }
}