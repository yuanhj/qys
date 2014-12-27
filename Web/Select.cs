using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ServiceWeb.BLL;
using ServiceWeb.DAL;
using ServiceWeb.Model;


namespace Web
{

   public class Select
    {

       public ServiceWeb.Model.Member usertity = new ServiceWeb.Model.Member();
       public ServiceWeb.BLL.UserProfile upf = new ServiceWeb.BLL.UserProfile();
       public ServiceWeb.Model.UserProfile userprofile = new ServiceWeb.Model.UserProfile();
       private ServiceWeb.BLL.Demands demands = new ServiceWeb.BLL.Demands();
        private int Total;
        private int finishNum;
        private Double chance;
        //获取诉求总数
        public int SelectTotal(int id)
        {
            DataSet ds = demands.GetList("Status<>3 and UID=" + id);
            Total = ds.Tables[0].Rows.Count;
            return Total;
        }
        //办结完成数量
        public int SelectfinishNum(int id)
        {
            DataSet ds = demands.GetList("Status=2 and UID=" +id);
            finishNum = ds.Tables[0].Rows.Count;
            return finishNum;
        }
        //完成率
        public Double Num(int a, int b)
        {
            chance = Convert.ToDouble(a)/Convert.ToDouble(b);
            //Math.Round(chance,2);
            return Math.Round(chance, 2);
        }
    }
}
