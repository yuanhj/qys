using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using ServiceWeb.Model;
namespace ServiceWeb.BLL
{
    /// <summary>
    /// ForgetPwdLog
    /// </summary>
    public partial class ForgetPwdLog
    {
         public bool Updates(ServiceWeb.Model.ForgetPwdLog model)
         {
             return dal.Updates(model);
         }
    }
}
