using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Web.Security;

namespace ChandrashekharTest
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private readonly CandidateRepository _candidateRepository = new CandidateRepository();


            protected void Page_Load(object sender, EventArgs e)
            {
            //CheckSuperAdmin();

            //if (!IsPostBack)
            //{
            //    LoadDashboard();
            //}


            Response.Cache.SetCacheability(
            System.Web.HttpCacheability.NoCache);

            Response.Cache.SetNoStore();

            Response.Cache.SetExpires(
                DateTime.UtcNow.AddYears(-1));

            CheckSuperAdmin();

            LoadDashboard();
        }


            // =====================================================
            // CHECK SUPER ADMIN LOGIN
            // =====================================================

            private void CheckSuperAdmin()
            {
                if (Session["UserId"] == null)
                {
                    FormsAuthentication.SignOut();

                    Response.Redirect(
                        "~/Account/Login.aspx",
                        false);

                    Context.ApplicationInstance.CompleteRequest();

                    return;
                }


                string role =
                    Convert.ToString(Session["RoleName"]);


                if (!role.Equals(
                    "SuperAdmin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    FormsAuthentication.SignOut();

                    Session.Clear();
                    Session.Abandon();

                    Response.Redirect(
                        "~/Account/Login.aspx",
                        false);

                    Context.ApplicationInstance.CompleteRequest();

                    return;
                }
            }


            // =====================================================
            // LOAD DASHBOARD
            // =====================================================

            private void LoadDashboard()
            {
                try
                {
                    // =============================================
                    // USER NAME
                    // =============================================

                    string userName =
                        Convert.ToString(Session["UserName"]);


                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        userName = "Super Admin";
                    }


                    lblUserName.Text = Server.HtmlEncode(userName);

                    lblWelcome.Text = Server.HtmlEncode(userName);


                    // =============================================
                    // GET DASHBOARD COUNTS
                    // =============================================

                    DashboardStats stats =
                        _candidateRepository.GetDashboardStats();


                    if (stats != null)
                    {
                        lblTotalCandidates.Text =
                            Convert.ToString(
                                stats.TotalCandidates);

                        lblPending.Text =
                            Convert.ToString(
                                stats.PendingCandidates);

                        lblSelected.Text =
                            Convert.ToString(
                                stats.SelectedCandidates);

                        lblRejected.Text =
                            Convert.ToString(
                                stats.RejectedCandidates);
                    }
                    else
                    {
                        SetZeroCounts();
                    }
                }
                catch (Exception)
                {
                    SetZeroCounts();
                }
            }


            // =====================================================
            // SET ZERO COUNTS
            // =====================================================

            private void SetZeroCounts()
            {
                lblTotalCandidates.Text = "0";
                lblPending.Text = "0";
                lblSelected.Text = "0";
                lblRejected.Text = "0";
            }


            // =====================================================
            // CANDIDATE SCRUTINY
            // =====================================================

            protected void btnScrutiny_Click(
                object sender,
                EventArgs e)
            {
                Response.Redirect(
                    "~/SuperAdmin/Scrutiny.aspx",
                    false);

                Context.ApplicationInstance
                    .CompleteRequest();
            }


            // =====================================================
            // SELECTED / APPROVED CANDIDATES
            // =====================================================

            protected void btnSelected_Click(
                object sender,
                EventArgs e)
            {
                Response.Redirect(
                    "~/SuperAdmin/SelectedCandidates.aspx",
                    false);

                Context.ApplicationInstance
                    .CompleteRequest();
            }


            // =====================================================
            // REJECTED CANDIDATES
            // =====================================================

            protected void btnRejected_Click(
                object sender,
                EventArgs e)
            {
                Response.Redirect(
                    "~/SuperAdmin/RejectedCandidates.aspx",
                    false);

                Context.ApplicationInstance
                    .CompleteRequest();
            }


            // =====================================================
            // LOGOUT
            // =====================================================

            protected void btnLogout_Click(
                object sender,
                EventArgs e)
            {
                FormsAuthentication.SignOut();

                Session.Clear();
                Session.Abandon();

                Response.Redirect(
                    "~/Account/Login.aspx",
                    false);

                Context.ApplicationInstance
                    .CompleteRequest();
            }
        }
    }



