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

    public partial class Post
    {
      
        /// <summary>
        /// 逐行读取
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReader()
        {
            return dal.Datareader();
        }
        /// <summary>
        /// 读取最新一条数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader DataReaderTop(int cid)
        {
            return dal.DatareaderTop(cid);
        }

        /// <summary>
        /// 读取最新几条数据
        /// </summary>
        /// <returns></returns>
        public DataSet DataTop(string num,string tablename,int cid)
        {
            return dal.GetListTop(num,tablename,cid);
        }

        public bool Delete(Model.Post post)
        {
            post.Status = -1;
            return dal.Update(post);
        }
    }
}
