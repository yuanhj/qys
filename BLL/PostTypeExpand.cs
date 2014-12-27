using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceWeb.BLL
{
    public partial class PostType
    {
        private static DAL.PostType sdal = new DAL.PostType();
        public static string NameFromID(int id)
        {
            Model.PostType entity = sdal.GetModel(id);
            if (entity != null)
            {
                return entity.Name;
            }
            return "";
        }
    }
}
