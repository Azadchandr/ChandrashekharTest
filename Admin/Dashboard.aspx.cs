using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChandrashekharTest.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {

        private readonly CandidateRepository _candidateRepository = new CandidateRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAdmin();
                LoadDashboard();
            }
        }
 
        private void CheckAdmin()
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            string role =
                Convert.ToString(Session["RoleName"]);

            if (!role.Equals(
                    "Admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                FormsAuthentication.SignOut();

                Session.Clear();
                Session.Abandon();

                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            string userName =
                Convert.ToString(Session["UserName"]);

            lblUserName.Text = userName;
            lblWelcomeName.Text = userName;
        }

        private void LoadDashboard()
        {
            DashboardStats stats =
                _candidateRepository.GetDashboardStats();

            if (stats == null)
            {
                lblTotalCandidates.Text = "0";
                lblSubmitted.Text = "0";
                lblApproved.Text = "0";
                lblRejected.Text = "0";

                return;
            }

            lblTotalCandidates.Text =
                stats.TotalCandidates.ToString();

           
            lblSubmitted.Text = stats.Submitted.ToString(); 

            lblApproved.Text =
                stats.Approved.ToString();

            lblRejected.Text =
                stats.Rejected.ToString();
        }

        protected void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            FormsAuthentication.SignOut();

            Response.Redirect(
                "~/Account/Login.aspx");
        }
    }
}