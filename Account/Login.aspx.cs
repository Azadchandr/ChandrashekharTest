using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using ChandrashekharTest.Security;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web;
using System.Web.Security;

namespace ChandrashekharTest.Account
{
    public partial class Login : System.Web.UI.Page
    {
            private readonly UserRepository _userRepository =
                new UserRepository();

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    txtUserName.Focus();
                }
            }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName))
            {
                lblMessage.Text = "Please enter username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Please enter password.";
                return;
            }

            User user = _userRepository.Login(
                userName,
                password);

            if (user == null)
            {
                lblMessage.Text = "Invalid username or password.";
                return;
            }

            // ============================
            // SESSION
            // ============================

            Session["UserId"] = user.UserId;
            Session["UserName"] = user.Username;
            Session["RoleName"] = user.RoleName;

            // ============================
            // FORMS AUTHENTICATION
            // ============================

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
            (
                    1,
                    user.Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    user.RoleName
            );

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,encryptedTicket));

            // ============================
            // REDIRECT BY ROLE
            // ============================

            if (user.RoleName.Equals("Admin",StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Admin/Dashboard.aspx");
                

            }
            else if (user.RoleName.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SuperAdmin/Dashboard.aspx");
            }
            else
            {
                Session.Clear();
                Session.Abandon();

                FormsAuthentication.SignOut();

                lblMessage.Text = "Invalid user role.";
            }
        }

    }
    }




    

