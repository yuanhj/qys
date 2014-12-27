using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceWeb.BLL
{
    public partial class Member
    {
        public bool HaveUserName(string username)
        {
            if (dal.GetList("username = '" + username + "' and status > -1").Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
