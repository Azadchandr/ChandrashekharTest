using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;



namespace ChandrashekharTest
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_PostAuthenticateRequest(object sender,EventArgs e)
        {
            HttpCookie authCookie =Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null)
                return;

            FormsAuthenticationTicket ticket;

            try
            {
                ticket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return;
            }

            if (ticket == null || ticket.Expired)
                return;

            string role = ticket.UserData;

            if (string.IsNullOrWhiteSpace(role))
                return;

            FormsIdentity identity =new FormsIdentity(ticket);

            GenericPrincipal principal = new GenericPrincipal(identity, new[] { role });

            Context.User = principal;
        }
    }
}









