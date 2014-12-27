using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceWeb.BLL;
using System.Data;
using System.IO;
using System.Drawing.Printing;
using Web;

namespace ServiceWeb
{
    public partial class TongJi : Web.RequestBase
    {
        BLL.County county = new County();
        private BLL.Demands demands = new Demands();
        private BLL.DemandProfile dpf = new DemandProfile();
        private int Total;
        private int finishNum;
        private Double chance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rpt_tongji.DataSource = county.GetList("Status>-1");
                rpt_tongji.DataBind();
            }
        }
        //获取诉求总数
        public int SelectTotal(string countyid)
        {
            DataSet ds = demands.GetList("Status not in (0,3) and countyid="+countyid);
            Total = ds.Tables[0].Rows.Count;
            return Total;
        }
        //办结完成数量
        public int SelectfinishNum(string countyid)
        {
            DataSet ds = demands.GetList("Status=2  and countyid="+countyid);
            finishNum = ds.Tables[0].Rows.Count;
            return finishNum;
        }
        //完成率
        public Double Num()
        {
            chance = Convert.ToDouble(finishNum) / Convert.ToDouble(Total);
            //Math.Round(chance,2);
            
            return Math.Round(chance, 2);
        }
        //平均办结天数
        public string AvgToday(int countyID)
        {
            DataSet ds = demands.GetAvgDay(countyID);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// 获取某一个县区的平均满意度
        /// </summary>
        /// <returns></returns>
        public string AvgManyi(string countyid)
        {
            DataSet ds = dpf.AvgCountyEvaluate(Convert.ToInt32(countyid));
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {

                return "5";
            }

            //return ds.Tables[0].Rows[0][0].ToString();
        }

        protected void DownLoand_Click(object sender, EventArgs e)
        {
            DataSet ds = county.GetList("Status>-1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder strData = new StringBuilder();

                strData.Append("<h3 align='right' style='font: 宋体; font-size: 12px;'>导出时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</h3>");

                strData.Append("<table border='1' style='width:900px;border-collapse:collapse;' style='font: 宋体; font-size: 12px;'>" +
                    "<tr class='title'>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold;font-size: 12px; FONT-FAMILY: 宋体;'>id</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;' >单位</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;'>全部</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;'>已办结</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;'>办结率</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;'>平均办结天数</td>" +
                    "<td align ='center' style ='FONT-WEIGHT: bold; font-size: 12px; FONT-FAMILY: 宋体;'>企业总体满意度</td>" +
                    "</tr>");


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strData.Append("<tr>");
                    strData.Append("<td align ='left'>" + dr["id"].ToString() + "</td>");
                    strData.Append("<td align ='left'>" + dr["Name"].ToString() + "</td>");
                    strData.Append("<td align ='left'>" + SelectTotal(dr["id"].ToString())+ "</td>");
                    strData.Append("<td align ='left'>" +SelectfinishNum(dr["id"].ToString()) + "</td>");
                    if(Num()*100>0)
                    {
                        strData.Append("<td align ='left'>" + Num() * 100 + "%</td>");
                    }
                    else
                    {
                        strData.Append("<td align ='left'>0%</td>"); 
                    }
                    
                    strData.Append("<td align ='left'>" + AvgToday(Convert.ToInt32(dr["id"]))+ "天</td>");
                    strData.Append("<td align ='left'>非常满意</td>");
                    strData.Append("</tr>");
                }
                strData.Append("</table>");

                string sb = strData.ToString();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Charset = "utf-8";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" +System.DateTime.Now.ToString()+ ".xls;charset=utf-8");
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.Write("<h3 align=center>" + "企业服务网统计结果" + "</h3>");
                HttpContext.Current.Response.Write(sb);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
                Response.Write("<script>alert('导出成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('对不起，没有数据可导！');</script>");
            }
        }
      



    }
}