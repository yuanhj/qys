using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServiceWeb.Admin
{
    public partial class Post : Web.BasePage
    {
        BLL.Post post = new BLL.Post();
        Model.Post mpost = new Model.Post();
        private string ac = string.Empty;
        private string id = string.Empty;
        private bool IsEdit = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ac = Request.QueryString["ac"];
            id = Request.QueryString["id"];
            Pre_Load();
            if (!IsPostBack)
            {
                Binds();
            }
        }
        private void Binds()
        {
            if (IsEdit)
            {
                mpost = post.GetModel(Convert.ToInt32(id));
                if (mpost != null)
                {
                    DropDownList1.SelectedValue = mpost.CountyID.ToString();
                    zhuti.Text = mpost.Subject;
                    txteditor.InnerText = mpost.Message;
                    radio_top.SelectedValue = mpost.IsTop.ToString();
                    if (mpost.TypeID.HasValue)
                    {
                        dpPostType.SelectedValue = mpost.TypeID.Value.ToString();
                    }
                }
            }
        }

        private void Pre_Load()
        {
            if (!string.IsNullOrEmpty(ac) && ac.Equals("edit"))
            {
                IsEdit = true;
            }
            SqlDataReader dr = post.DataReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }
            DropDownList1.Items.Insert(0, new ListItem("请选择...", "0"));
            DropDownList1.SelectedValue = "1"; ///todo: delete this line.
            DropDownList1.Enabled = false; ///todo: delete this line.
            DataSet ds = (new BLL.PostType()).GetList("status > -1");
            dpPostType.DataSource = ds;
            dpPostType.DataValueField = "id";
            dpPostType.DataTextField = "name";
            dpPostType.DataBind();
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            string county = DropDownList1.SelectedValue;
            string subject = zhuti.Text.Trim();
            string message = HttpUtility.UrlDecode(txteditor.InnerText.Trim());
            string istop = radio_top.SelectedValue;
            string typeid = dpPostType.SelectedValue;
            if (string.IsNullOrEmpty(county) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(istop))
            {
                ReWrite(Request.UrlReferrer.ToString(), "请填写全部信息", 1);
            }
            if (IsEdit)
            {
                //编辑
                mpost = post.GetModel(Convert.ToInt32(id));
                mpost.CountyID = Convert.ToInt32(county);
                mpost.Subject = subject;
                mpost.TypeID = Convert.ToInt32(typeid);
                mpost.Message = message;
                mpost.IsTop = Convert.ToInt32(istop);
                mpost.UpdateTime = DateTime.Now;
                post.Update(mpost);
                ReWrite("/admin/post/post.aspx?ac=edit&id=" + mpost.ID, "保存成功", 1);
            }
            else
            {
                //添加
                mpost = new Model.Post();
                mpost.CountyID = Convert.ToInt32(county);
                mpost.Subject = subject;
                mpost.TypeID = Convert.ToInt32(typeid);
                mpost.Message = message;
                mpost.IsTop = Convert.ToInt32(istop);
                mpost.Status = 0;
                mpost.IsSystem = 0;
                mpost.AddTime = DateTime.Now;
                mpost.DispalyOrder = 0;
                post.Add(mpost);
                ReWrite("/admin/post/PostShow.aspx", "添加成功", 1);
            }
        }
    }
}