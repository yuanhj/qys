using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.Common;
using ServiceWeb.Model;
namespace ServiceWeb.BLL
{
  public partial  class PageManager
    {
      private readonly ServiceWeb.DAL.PageManager dal = new ServiceWeb.DAL.PageManager();
        /**/
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public  DataSet GetPage(string sql, int currentPage, int pagesize, out int recordcount)
        {

            return DAL.PageManager.GetPage(sql, currentPage, pagesize,out recordcount);
        }
    }
}
