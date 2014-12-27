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
    public partial class Demands
    {
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReader()
        {
            return dal.Datareader();
        }
        public SqlDataReader DataReaderDemands()
        {
            return dal.DatareaderDemandType();
        }
        public SqlDataReader DataUser()
        {
            return dal.DataUser();
        }
        public bool UpdateStatus(ServiceWeb.Model.Demands model)
        {
            return dal.UpdateStauts(model);
        }
        public bool UpdateResult(ServiceWeb.Model.Demands model)
        {
            return dal.UpdateResult(model);
        }
        public bool UpdateReason(ServiceWeb.Model.Demands model)
        {
            return dal.UpdateReason(model);
        }

        public DemandsStatus Status(string status)
        {
            return (DemandsStatus) Enum.Parse(typeof (DemandsStatus), status);
        }

        public bool IsDenyed(int id)
        {
            Model.Demands demands = GetModel(id);
            return demands.Status == (int) DemandsStatus.拒绝;
        }
        public DataSet GetListTop(string num, string tablename, int cid)
        {
            return dal.GetListTop(num, tablename, cid);
        }
        public DataSet GetAvgDay(int countyID)
        {
            return dal.GetAvgDay(countyID);
        }
        public DataSet GetAvgDay2(string str)
        {
            return dal.GetAvgDay2(str);
        }
        public DataSet ResultDate(int id)
        {
            return dal.ResultDate(id);
        }
        public DataSet ReturnDemands(string sql)
        {
            return dal.ReturnDemands(sql);
        }

    }

    public enum DemandsStatus
    {
        未受理 = 0,
        已受理 = 1,
        办结完成 = 2,
        拒绝 = 3,
        删除 = -1,
        办理中 = 4
    }
    
}
