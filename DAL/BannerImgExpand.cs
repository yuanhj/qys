using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ServiceWeb.DAL
{
    /// <summary>
    /// 数据访问类:BannerImg
    /// </summary>
    public partial class BannerImg
    {
        public DataSet SelectTop(int cid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select top 3 * from BannerImg where CountyID="+cid+" and Status=0 order by AddTime desc ");
            return DbHelperSQL.Query(strsql.ToString());
        }
    }
}
