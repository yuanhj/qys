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
	/// <summary>
	/// CompanyType
	/// </summary>
	public partial class CompanyType
    {
         public SqlDataReader GetCompany()
         {
             return dal.GetCompany();
         }

         public string CompanyName(int id)
         {
             string cname = string.Empty;
             //Model.County mCounty = dal.GetModel(id);
             Model.CompanyType ctp = dal.GetModel(id);
             if (ctp != null)
             {
                 cname = ctp.Name;
             }
             return cname;
         }

    }
}
