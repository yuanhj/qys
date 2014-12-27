﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using ServiceWeb.Model;
using System.Data.SqlClient;
using System.Data;
namespace ServiceWeb.BLL
{
    /// <summary>
    /// 数据访问类:DemandType
    /// </summary>
    public partial class DemandType
    {
        public SqlDataReader DataDType()
        {
            return dal.DatareaderDType();
        }

        public string[] NameFromIDs(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                DataSet ds = dal.GetList("status > -1 and id in(" + ids.Trim(',') + ")");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sb.Append("," + row["name"]);
                    }
                    return sb.ToString().Trim(',').Split(',');
                }
            }
            return new string[] { };
        }

        public static bool InUse(int id)
        {
            BLL.Demands blldemands = new Demands();
            DataSet ds = blldemands.GetList("status > -1 and charindex('," + id + ",', ','+DTypeID+',') > 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}