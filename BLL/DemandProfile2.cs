using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ServiceWeb.BLL
{
    public partial class DemandProfile
    {
        public SqlDataReader DataDemands()
        {
            return dal.DataDemands();
        }
        public bool UpdatePid(ServiceWeb.Model.DemandProfile model)
        {
            return dal.UpdatePid(model);
        }
        public DataSet GetList2()
        {
            return dal.GetList2("");
        }
        public bool UpdateContent(ServiceWeb.Model.DemandProfile model)
        {
            return dal.UpdateContent(model);
        }
        public DataSet AvgEvaluate(string strwhere)
        {
            return dal.AvgEvaluate(strwhere);
        }
       public DataSet AvgEvaluate(int id)
       {
           return dal.AvgEvaluate(id);
       }
        public DataSet AvgCountyEvaluate(int countyID)
        {
            return dal.AvgCountyEvaluate(countyID);
        }
    }
}
