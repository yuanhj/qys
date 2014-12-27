using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using ServiceWeb.Model;
using System.Data;
namespace ServiceWeb.BLL
{
    /// <summary>
    /// BannerImg
    /// </summary>
    public partial class BannerImg
    {
        public DataSet SelectTop(int cid)
        {
            return dal.SelectTop(cid);
        }
    }
}
