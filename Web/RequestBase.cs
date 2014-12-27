using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web
{
   public  class RequestBase:System.Web.UI.Page
    {
       protected int CountyID = 1;
	   private HttpCookie usercookie;
       private const string cookiename = "county_id";
       protected override void OnPreLoad(EventArgs e)
       {
           base.OnPreLoad(e);
           BaseLoad();
       }

       private int BaseLoad()
       {
           usercookie = new HttpCookie(cookiename);
           string cid = HttpContext.Current.Request.QueryString["cid"];
           if (!string.IsNullOrEmpty(cid))
           {
               CountyID = Convert.ToInt32(cid);
			   usercookie.Values.Add("countyid", cid.ToString());
               usercookie.Expires = DateTime.Now.AddDays(1);
               HttpContext.Current.Response.Cookies.Add(usercookie);
           }
		   else
           {
               usercookie = HttpContext.Current.Request.Cookies[cookiename];
               if(usercookie!=null)
               {
                   return CountyID = Convert.ToInt32(usercookie["countyid"].ToString());
               }
           }
           return CountyID;
       }
    }
}
