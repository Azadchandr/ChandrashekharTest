using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChandrashekharTest.SuperAdmin
{
    public partial class Scrutiny : System.Web.UI.Page
    {



            private readonly CandidateRepository _candidateRepository =   new CandidateRepository();

            protected void Page_Load(object sender, EventArgs e)
            {
                CheckSuperAdmin();

                if (!IsPostBack)
                {
                    LoadCandidates();
                }
            }


            // =====================================================
            // SUPER ADMIN SECURITY
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
            // LOAD CANDIDATES
            // =====================================================

            private void LoadCandidates()
            {
                try
                {
                    IEnumerable<Candidate> candidates =
                        _candidateRepository.GetAll();


                    // =================================================
                    // SEARCH
                    // =================================================

                    string search =
                        txtSearch.Text.Trim();


                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        candidates = candidates.Where(x =>
                            (!string.IsNullOrEmpty(x.Name) &&
                             x.Name.IndexOf(
                                 search,
                                 StringComparison.OrdinalIgnoreCase) >= 0)

                            ||

                            (!string.IsNullOrEmpty(x.Email) &&
                             x.Email.IndexOf(
                                 search,
                                 StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                    }


                    // =================================================
                    // STATUS FILTER
                    // =================================================

                    string status =
                        ddlStatus.SelectedValue;


                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        candidates = candidates.Where(x =>
                            string.Equals(
                                x.Status,
                                status,
                                StringComparison.OrdinalIgnoreCase));
                    }


                    gvCandidates.DataSource =
                        candidates.ToList();

                    gvCandidates.DataBind();
                }
                catch (Exception ex)
                {
                    ShowError(
                        "Error loading candidates: "
                        + ex.Message);
                }
            }


            // =====================================================
            // STATUS CSS
            // =====================================================

            protected string GetStatusClass(object status)
            {
                string value =
                    Convert.ToString(status);


                if (value.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase)
                    ||
                    value.Equals(
                    "Selected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return "status-selected";
                }


                if (value.Equals(
                    "Rejected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return "status-rejected";
                }


                return "status-pending";
            }


            // =====================================================
            // SEARCH
            // =====================================================

            protected void btnSearch_Click(
                object sender,
                EventArgs e)
            {
                LoadCandidates();
            }


            // =====================================================
            // CLEAR
            // =====================================================

            protected void btnClear_Click(
                object sender,
                EventArgs e)
            {
                txtSearch.Text = "";

                if (ddlStatus.Items.Count > 0)
                {
                    ddlStatus.SelectedIndex = 0;
                }

                LoadCandidates();
            }


            // =====================================================
            // GRID COMMAND
            // =====================================================

            protected void gvCandidates_RowCommand(
                object sender,
                GridViewCommandEventArgs e)
            {
                int candidateId;


                // =================================================
                // VALIDATE CANDIDATE ID
                // =================================================

                if (!int.TryParse(
                    Convert.ToString(e.CommandArgument),
                    out candidateId))
                {
                    ShowError(
                        "Invalid candidate ID.");

                    return;
                }


                // =================================================
                // VIEW CANDIDATE
                // =================================================

                if (e.CommandName == "ViewCandidate")
                {
                    Response.Redirect(
                        "~/SuperAdmin/CandidateDetails.aspx?id="
                        + candidateId,
                        false);

                    Context.ApplicationInstance.CompleteRequest();

                    return;
                }


                // =================================================
                // APPROVE CANDIDATE
                // =================================================

                if (e.CommandName == "ApproveCandidate")
                {
                    ApproveCandidate(candidateId);

                    return;
                }


                // =================================================
                // REJECT CANDIDATE
                // =================================================

                if (e.CommandName == "RejectCandidate")
                {
                    RejectCandidate(candidateId);

                    return;
                }
            }


            // =====================================================
            // APPROVE CANDIDATE
            // =====================================================

            private void ApproveCandidate(int candidateId)
            {
                try
                {
                    Candidate candidate =
                        _candidateRepository.GetById(candidateId);


                    if (candidate == null)
                    {
                        ShowError(
                            "Candidate not found.");

                        return;
                    }


                    // Already rejected

                    if (string.Equals(
                        candidate.Status,
                        "Rejected",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ShowError(
                            "Rejected candidate cannot be approved.");

                        return;
                    }


                    bool result =
                        _candidateRepository.UpdateStatus(
                            candidateId,
                            "Approved");


                    if (result)
                    {
                        ShowSuccess(
                            "Candidate approved successfully.");

                        LoadCandidates();
                    }
                    else
                    {
                        ShowError(
                            "Candidate could not be approved.");
                    }
                }
                catch (Exception ex)
                {
                    ShowError(
                        "Error while approving candidate: "
                        + ex.Message);
                }
            }


            // =====================================================
            // REJECT CANDIDATE
            // =====================================================

            private void RejectCandidate(int candidateId)
            {
                try
                {
                    Candidate candidate =
                        _candidateRepository.GetById(candidateId);


                    if (candidate == null)
                    {
                        ShowError(
                            "Candidate not found.");

                        return;
                    }


                    // Already approved

                    if (string.Equals(
                        candidate.Status,
                        "Approved",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ShowError(
                            "Approved candidate cannot be rejected.");

                        return;
                    }


                    bool result =
                        _candidateRepository.UpdateStatus(
                            candidateId,
                            "Rejected");


                    if (result)
                    {
                        ShowSuccess(
                            "Candidate rejected successfully.");

                        LoadCandidates();
                    }
                    else
                    {
                        ShowError(
                            "Candidate could not be rejected.");
                    }
                }
                catch (Exception ex)
                {
                    ShowError(
                        "Error while rejecting candidate: "
                        + ex.Message);
                }
            }


            // =====================================================
            // SUCCESS MESSAGE
            // =====================================================

            private void ShowSuccess(string message)
            {
                lblMessage.Text =
                    Server.HtmlEncode(message);

                lblMessage.CssClass =
                    "success-message d-block mb-3";
            }


            // =====================================================
            // ERROR MESSAGE
            // =====================================================

            private void ShowError(string message)
            {
                lblMessage.Text =
                    Server.HtmlEncode(message);

                lblMessage.CssClass =
                    "error-message d-block mb-3";
            }


            // =====================================================
            // PHOTO URL
            // =====================================================

            protected string GetPhotoUrl(object photoPath)
            {
                if (photoPath == null ||
                    photoPath == DBNull.Value)
                {
                    return ResolveUrl(
                        "~/Content/images/no-photo.png");
                }


                string path =
                    photoPath.ToString().Trim();


                if (string.IsNullOrWhiteSpace(path))
                {
                    return ResolveUrl(
                        "~/Content/images/no-photo.png");
                }


                return ResolveUrl(
                    "~/" + path.TrimStart('~', '/'));
            }


            // =====================================================
            // BACK TO DASHBOARD
            // =====================================================

            protected void btnBack_Click(
                object sender,
                EventArgs e)
            {
                Response.Redirect(
                    "~/SuperAdmin/Dashboard.aspx",
                    false);

                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }


//            protected void Page_Load(object sender, EventArgs e)
//            {
//                CheckSuperAdmin();

//                if (!IsPostBack)
//                {
//                    LoadCandidates();
//                }
//            }

//            // =====================================================
//            // SUPER ADMIN SECURITY
//            // =====================================================

//            private void CheckSuperAdmin()
//            {
//                if (Session["UserId"] == null)
//                {
//                    FormsAuthentication.SignOut();

//                    Response.Redirect(
//                        "~/Account/Login.aspx",
//                        false);

//                    Context.ApplicationInstance.CompleteRequest();
//                    return;
//                }

//                string role = Convert.ToString(Session["RoleName"]);

//                if (!role.Equals(
//                    "SuperAdmin",
//                    StringComparison.OrdinalIgnoreCase))
//                {
//                    FormsAuthentication.SignOut();

//                    Session.Clear();
//                    Session.Abandon();

//                    Response.Redirect(
//                        "~/Account/Login.aspx",
//                        false);

//                    Context.ApplicationInstance.CompleteRequest();
//                }
//            }

//            // =====================================================
//            // LOAD ACTUAL CANDIDATES FROM DATABASE
//            // =====================================================

//            private void LoadCandidates()
//            {
//                try
//                {
//                    IEnumerable<Candidate> candidates =
//                        _candidateRepository.GetAll();

//                    // Optional search
//                    string search = txtSearch.Text.Trim();

//                    if (!string.IsNullOrWhiteSpace(search))
//                    {
//                        candidates = candidates.Where(x =>
//                            (!string.IsNullOrEmpty(x.Name) &&
//                             x.Name.IndexOf(
//                                 search,
//                                 StringComparison.OrdinalIgnoreCase) >= 0)

//                            ||

//                            (!string.IsNullOrEmpty(x.Email) &&
//                             x.Email.IndexOf(
//                                 search,
//                                 StringComparison.OrdinalIgnoreCase) >= 0)
//                        );
//                    }

//                    // Optional status filter
//                    string status = ddlStatus.SelectedValue;

//                    if (!string.IsNullOrWhiteSpace(status) &&
//                        status != "All")
//                    {
//                        candidates = candidates.Where(x =>
//                            string.Equals(
//                                x.Status,
//                                status,
//                                StringComparison.OrdinalIgnoreCase));
//                    }

//                    gvCandidates.DataSource = candidates.ToList();
//                    gvCandidates.DataBind();
//                }
//                catch (Exception ex)
//                {
//                    // For development only.
//                    // You can replace this with logging later.
//                    Response.Write(
//                        "<div style='color:red;padding:10px;'>"
//                        + "Error loading candidates: "
//                        + Server.HtmlEncode(ex.Message)
//                        + "</div>");
//                }
//            }

//            // =====================================================
//            // STATUS CSS
//            // =====================================================

//            protected string GetStatusClass(object status)
//            {
//                string value = Convert.ToString(status);

//                if (value.Equals(
//                    "Selected",
//                    StringComparison.OrdinalIgnoreCase))
//                {
//                    return "selected";
//                }

//                if (value.Equals(
//                    "Approved",
//                    StringComparison.OrdinalIgnoreCase))
//                {
//                    return "selected";
//                }

//                if (value.Equals(
//                    "Rejected",
//                    StringComparison.OrdinalIgnoreCase))
//                {
//                    return "rejected";
//                }

//                return "pending";
//            }

//            // =====================================================
//            // SEARCH
//            // =====================================================

//            protected void btnSearch_Click(
//                object sender,
//                EventArgs e)
//            {
//                LoadCandidates();
//            }

//            // =====================================================
//            // CLEAR
//            // =====================================================

//            protected void btnClear_Click(
//                object sender,
//                EventArgs e)
//            {
//                txtSearch.Text = "";

//                if (ddlStatus.Items.Count > 0)
//                {
//                    ddlStatus.SelectedIndex = 0;
//                }

//                LoadCandidates();
//            }

//            // =====================================================
//            // GRID COMMAND
//            // =====================================================

//            protected void gvCandidates_RowCommand(
//                object sender,
//                GridViewCommandEventArgs e)
//            {
//                if (e.CommandName == "ViewCandidate")
//                {
//                    string candidateId =
//                        Convert.ToString(e.CommandArgument);

//                    Response.Redirect(
//                        "~/SuperAdmin/CandidateDetails.aspx?id="
//                        + candidateId,
//                        false);

//                    Context.ApplicationInstance.CompleteRequest();
//                }
//            }

//        // ==========================================
//        // PHOTO URL
//        // ==========================================

//        protected string GetPhotoUrl(object photoPath)
//        {
//            if (photoPath == null ||
//                photoPath == DBNull.Value)
//            {
//                return ResolveUrl(
//                    "~/Content/images/no-photo.png");
//            }

//            string path =
//                photoPath.ToString().Trim();

//            if (string.IsNullOrWhiteSpace(path))
//            {
//                return ResolveUrl(
//                    "~/Content/images/no-photo.png");
//            }

//            return ResolveUrl(
//                "~/" + path.TrimStart('~', '/'));
//        }

//        protected void btnBack_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("~/SuperAdmin/Scrutiny.aspx",false);
//        }
//    }
//}


