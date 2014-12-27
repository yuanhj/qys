using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
namespace ServiceWeb
{
    public partial class ServiceNews : Web.RequestBase
    {
        BLL.Post post = new BLL.Post();
        BLL.PageManager pagemanager = new BLL.PageManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Binds();
        }
        public  void Binds()
        {
            string Sql = "select * from Post where CountyID=" + CountyID + " and Subject not in('服务机构','诉求办理流程') and TypeID=2 and Status>-1  order by ID desc";
            int CurrentPage = AspNetPager1.CurrentPageIndex;
            int PageSize = AspNetPager1.PageSize;
            int RecordCount;
            DataSet ds = pagemanager.GetPage(Sql, CurrentPage, PageSize, out RecordCount);
            AspNetPager1.RecordCount = RecordCount;
            this.rpt_Newslist.DataSource = ds;
            rpt_Newslist.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Binds();
        }
        /**/
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
                RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
                RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
                RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /**/
        ///提取HTML代码中文字的C#函数
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="strHtml">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public class StripHTMLTest
        {
            public static void Main()
            {
                string s = StripHTML(
                  "<HTML><HEAD><TITLE>我的博客 </TITLE></HEAD><BODY>faddfs欢迎您</BODY></HTML>");
                Console.WriteLine(s);
            }

            public static string StripHTML(string strHtml)
            {
                string[] aryReg =
    {
      @"<script[^>]*?>.*?</script>",

      @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>", @"([\r\n])[\s]+", @"&(quot|#34);", @"&(amp|#38);", @"&(lt|#60);", @"&(gt|#62);", @"&(nbsp|#160);", @"&(iexcl|#161);", @"&(cent|#162);", @"&(pound|#163);",@"&(copy|#169);", @"&#(\d+);", @"-->", @"<!--.*\n"
    };

                string[] aryRep =
    {
      "", "", "", "\"", "&", "<", ">", "   ", "\xa1", //chr(161),
      "\xa2", //chr(162),
      "\xa3", //chr(163),
      "\xa9", //chr(169),
      "", "\r\n", ""
    };

                string newReg = aryReg[0];
                string strOutput = strHtml;
                for (int i = 0; i < aryReg.Length; i++)
                {
                    Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                    strOutput = regex.Replace(strOutput, aryRep[i]);
                }
                strOutput.Replace("<", "");
                strOutput.Replace(">", "");
                strOutput.Replace("\r\n", "");
                return strOutput;
            }
        }

        //使用静态方法移除HTML标签
        #region
        ///移除HTML标签
        /**/
        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        #endregion

        ///   取出文本中的图片地址
        #region
        ///   取出文本中的图片地址
        /**/
        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
                RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        #endregion
    }
}