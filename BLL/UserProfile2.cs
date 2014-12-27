using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using ServiceWeb.Model;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.BLL
{
    public partial class UserProfile
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Datareader()
        {
            return dal.Datareader();
        }
        public SqlDataReader DataUser()
        {
            return dal.DataUser();
        }

        public Model.UserProfile GetModelFromUID(int uid)
        {
            return dal.DataRowToModel(dal.GetList("uid=" + uid).Tables[0].Rows[0]);
        }

        public bool HadCompanyName(int id, string companyname)
        {
            if (dal.GetList("id !=" + id + " and companyname = '" + companyname + "'").Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool HaveCompanyName(string companyname)
        {
            if (dal.GetList("companyname = '" + companyname + "' and uid not in (select id from member where status = -1)").Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
		}

        public DataSet SelectTop()
        {
            return dal.SelectTop();
        }
        public bool UpdateExpand(ServiceWeb.Model.UserProfile model)
        {
            return dal.UpdateExpend(model);
        }
    }
}
