using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace Web
{
    public static class Helper
    {
        public static int ErrorCode = 0;
        public static string ErrorMessage = null;

        #region static function
        /// <summary>
        /// left
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Left(string input, int n)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            return input.Substring(0, input.Length >= n ? n : input.Length);
        }
        /// <summary>
        /// get url content
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Response(string url)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            Request.UserAgent = "Mozilla/4.0+(compatible;+MSIE+6.0;+Windows+NT+5.1;+SV1;+QQPinyin+730;+TencentTraveler+4.0;+Mozilla/4.0+(compatible;+MSIE+6.0;+Windows+NT+5.1;+SV1)+)";
            Request.KeepAlive = true;
            Stream stream;
            StreamReader reader;
            string result = "";
            try
            {
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                stream = Response.GetResponseStream();
                reader = new StreamReader(stream, System.Text.Encoding.Default);
                result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                ErrorCode = 1;
                ErrorMessage = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// get url content
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Response(string url, string encoding)
        {
            ///<summary>get url conent</summary>
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            Request.UserAgent = "Mozilla/4.0+(compatible;+MSIE+6.0;+Windows+NT+5.1;+SV1;+QQPinyin+730;+TencentTraveler+4.0;+Mozilla/4.0+(compatible;+MSIE+6.0;+Windows+NT+5.1;+SV1)+)";
            Request.KeepAlive = true;
            Stream stream;
            StreamReader reader;
            string result = "";
            try
            {
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                stream = Response.GetResponseStream();
                reader = new StreamReader(stream, System.Text.Encoding.GetEncoding(encoding));
                result = reader.ReadToEnd();
                //HtmlHelper.Write(result);
                //HtmlHelper.Write(System.Text.Encoding.Default.EncodingName);
                stream.Dispose();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                Helper.Write(ex.Message);
            }
            return result;
        }
        /// <summary>
        /// remove meta
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveMeta(string html)
        {
            return new Regex("<[^>]+>", RegexOptions.Singleline | RegexOptions.Multiline).Replace(html, "");
        }
        /// <summary>
        /// response.write 
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            HttpContext.Current.Response.Write(str);
        }
        /// <summary>
        /// throw exception
        /// </summary>
        /// <param name="message"></param>
        public static void ThrowEx(string message)
        {
            throw new Exception(message);
        }
        /// <summary>
        /// error clear
        /// </summary>
        public static void ErrorClear()
        {
            ErrorCode = 0;
            ErrorMessage = null;
        }
        /// <summary>
        /// response.end
        /// </summary>
        public static void End()
        {
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// Server.MapPath
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string MapPath(string fileName)
        {
            return HttpContext.Current.Server.MapPath(fileName);
        }
        /// <summary>
        /// md5
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MD5(string key)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        }
        /// <summary>
        /// sha1
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SHA1(string key)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(key, "SHA1");
        }
        /// <summary>
        /// rand string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandString(int length)
        {
            string keystring = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            int n = keystring.Length;
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += keystring.Substring(random.Next(0, n), 1);
            }
            return str;
        }
        /// <summary>
        /// default value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReplaceNullOrEmpty(string source, string key)
        {
            if (String.IsNullOrEmpty(source))
            {
                return key;
            }
            return source;
        }
        /// <summary>
        /// unix time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double ToUnixTime(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            double result = 0;
            result = (int)(time - startTime).TotalSeconds;
            return result;
        }
        /// <summary>
        /// from unix time
        /// </summary>
        /// <param name="unxtime"></param>
        /// <returns></returns>
        public static DateTime FromUnixTime(double unxtime)
        {
            DateTime time = System.DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            time = startTime.AddSeconds(unxtime);
            return time;
        }
        /// <summary>
        /// user host address
        /// </summary>
        /// <returns></returns>
        public static string UserHostAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// read cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ReadCookie(string key, string name)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    if (HttpContext.Current.Request.Cookies[key][name] != null)
                    {
                        return HttpContext.Current.Request.Cookies[key][name].ToString();
                    }
                    return null;
                }
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            return null;
        }
        /// <summary>
        /// build qicq message link
        /// </summary>
        /// <param name="qqstring"></param>
        /// <param name="showImage"></param>
        /// <returns></returns>
        public static string BuildQicqMessageLink(string qqstring, bool showImage)
        {
            string[] qqs = qqstring.Split(',');
            if (qqs.Length <= 0)
            {
                return "";
            }
            string tmp = "";
            string strformat = "<a href=\"http://wpa.qq.com/msgrd?uin={0}&site=0372.cn&menu=yes\" target=\"_blank\">{0}</a>";
            if (showImage)
            {
                strformat = "<a href=\"http://wpa.qq.com/msgrd?uin={0}&site=0372.cn&menu=yes\" target=\"_blank\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=1:{0}:4\" alt=\"点击这里给我发消息\" />{0}</a>";
            }
            foreach (string qq in qqs)
            {
                if (String.IsNullOrEmpty(qq))
                {
                    continue;
                }
                tmp += String.Format(strformat, qq);
            }
            return tmp;
        }
        /// <summary>
        /// qq icon img src
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static string QicqIconSrc(string qq)
        {
            if (String.IsNullOrEmpty(qq))
            {
                return "";
            }
            return String.Format("http://wpa.qq.com/pa?p=1:{0}:4", qq);
        }
        /// <summary>
        /// regex replace
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pattern"></param>
        /// <param name="replace"></param>
        public static void RegReplace(ref string data, string pattern, string replace)
        {
            data = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(data, replace);
        }
        /// <summary>
        /// regex remove
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pattern"></param>
        public static void RegRemove(ref string data, string pattern)
        {
            RegReplace(ref data, pattern, "");
        }
        /// <summary>
        /// search replace
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pattern"></param>
        /// <param name="replace"></param>
        public static void SearchReplace(ref string data, string stapattern, string endpattern, string replace)
        {
            int st = data.IndexOf(stapattern);
            if (st > 0)
            {
                int et = data.IndexOf(data, st);
                if (et > 0)
                {
                    data = data.Remove(st, et + endpattern.Length - st);
                }
            }
        }
        /// <summary>
        /// search remove
        /// </summary>
        /// <param name="data"></param>
        /// <param name="stapattern"></param>
        /// <param name="endpattern"></param>
        public static void SearchRemove(ref string data, string stapattern, string endpattern)
        {
            SearchReplace(ref data, stapattern, endpattern, "");
        }
        /// <summary>
        /// form
        /// </summary>
        /// <param name="name"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string Form(string name, string replace)
        {
            string value = HttpContext.Current.Request.Form[name];
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim();
            }
            else
            {
                if (!string.IsNullOrEmpty(replace))
                {
                    value = replace;
                }
                else
                {
                    value = string.Empty;
                }
            }
            return value;
        }
        /// <summary>
        /// form
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Form(string name)
        {
            return Form(name, "");
        }
        public static int FormInt(string name, int replace)
        {
            string data = Form(name);
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    return Convert.ToInt32(data);
                }
                catch
                {
                    return replace;
                }
            }
            return replace;
        }
        public static string QueryString(string name, string replace)
        {
            string value = HttpContext.Current.Request.QueryString[name];
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim();
            }
            else
            {
                if (!string.IsNullOrEmpty(replace))
                {
                    value = replace;
                }
                else
                {
                    value = string.Empty;
                }
            }
            return value;
        }
        public static string QueryString(string name)
        {
            return QueryString(name, "");
        }
        public static int QueryInt(string name, int replace)
        {
            string value = QueryString(name);
            if (!string.IsNullOrEmpty(value))
            {
                return Convert.ToInt32(value);
            }
            return replace;
        }
        public static int QueryInt(string name)
        {
            return QueryInt(name, 0);
        }
        public static int FormInt(string name)
        {
            string value = FormString(name);
            if (!string.IsNullOrEmpty(value))
            {
                return Convert.ToInt32(value);
            }
            return 0;
        }
        public static string FormString(string name)
        {
            return FormString(name, "");
        }
        public static string FormString(string name, string replace)
        {
            string value = HttpContext.Current.Request.Form[name];
            if (!string.IsNullOrEmpty(value))
            {
                return value.Trim();
            }
            else
            {
                if (!string.IsNullOrEmpty(replace))
                {
                    return replace;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// IsNullOrEmpty
        /// </summary>
        /// <param name="data"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string IsNullOrEmpty(string data, string replace)
        {
            if (string.IsNullOrEmpty(data))
            {
                data = replace;
            }
            return data;
        }

        public static int Rand(int min, int max)
        {
            return new Random(unchecked((int)DateTime.Now.Ticks)).Next(min, max);
        }

        public static string BuildLinkString(string url, string text, string target)
        {
            return string.Format("<a href=\"{0}\" target=\"{2}\">{1}</a>", url, text, target);
        }

        #endregion
    }
}