using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceWeb.Model;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.BLL
{
    public partial class Department
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReader()
        {
            return dal.Datareader();
        }
        public DataSet SelectID(int cid)
        {
            return dal.SelectID(cid);
        }

        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReaderDpt()
        {
            return dal.DatareaderDpt();
        }
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReaderUser(string id)
        {
            return dal.DatareaderUser(id);
        }

        public bool ContactInfo(int pid, out Model.Department contact, out Model.Department department, out Model.County county)
        {
            bool info = false;
            department = null;
            county = null;
            BLL.Department bldepartment = new Department();
            BLL.County blcouty = new County();
            DAL.Department daldepartment = new DAL.Department();
            contact = bldepartment.GetModel(pid);
            if (contact != null)
            {
                department = daldepartment.GetModel(contact.ParentID);
                if (department != null)
                {
                    county = blcouty.GetModel(department.CountyID);
                    if (county != null)
                    {
                        info = true;
                    }
                }
            }
            return info;
        }

        public static string UserNameFromID(int pid)
        {
            DAL.Department dal = new DAL.Department();
            Model.Department entity = dal.GetModel(pid);
            if (entity != null)
            {
                return entity.UserName;
            }
            return string.Empty;
        }
    }
}