using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Security
{
  
 public static class SessionHelper
    {
        public static int UserId
        {
            get
            {
                return Convert.ToInt32(
                    HttpContext.Current.Session["UserId"]);
            }
        }

        public static string UserName
        {
            get
            {
                return Convert.ToString(
                    HttpContext.Current.Session["UserName"]);
            }
        }

        public static string RoleName
        {
            get
            {
                return Convert.ToString(
                    HttpContext.Current.Session["RoleName"]);
            }
        }
    }
}