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
    public partial class CandidateList : System.Web.UI.Page
    {

        private readonly CandidateRepository _candidateRepository = new CandidateRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAdmin();
                LoadCandidates();
            }
        }
            // ==========================================
            // CHECK ADMIN
            // ==========================================

            private void CheckAdmin()
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
                    "Admin",
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

            // ==========================================
            // LOAD CANDIDATES
            // ==========================================

            private void LoadCandidates()
            {
                try
                {
                    var candidates =
                        _candidateRepository.GetAll();

                    gvCandidate.DataSource = candidates;
                    gvCandidate.DataBind();
                }
                catch (Exception ex)
                {
                    lblMessage.Text =
                        "Error loading candidates: " +
                        ex.Message;

                    lblMessage.CssClass =
                        "alert alert-danger d-block";
                }
            }

            // ==========================================
            // PHOTO URL
            // ==========================================

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

            // ==========================================
            // VIEW / DELETE
            // ==========================================

            protected void gvCandidate_RowCommand(
                object sender,
                GridViewCommandEventArgs e)
            {
                if (e.CommandArgument == null)
                    return;

                int candidateId;

                if (!int.TryParse(
                    e.CommandArgument.ToString(),
                    out candidateId))
                {
                    lblMessage.Text =
                        "Invalid candidate ID.";

                    lblMessage.CssClass =
                        "alert alert-danger d-block";

                    return;
                }

                switch (e.CommandName)
                {
                    // ==================================
                    // VIEW
                    // ==================================

                    case "ViewCandidate":

                        Response.Redirect(
                            "~/Admin/CandidateView.aspx?id="
                            + candidateId,
                            false);

                        Context.ApplicationInstance
                            .CompleteRequest();

                        break;


                    // ==================================
                    // DELETE
                    // ==================================

                    case "DeleteCandidate":

                        DeleteCandidate(candidateId);

                        break;
                }
            }

            // ==========================================
            // DELETE CANDIDATE
            // ==========================================

            private void DeleteCandidate(int candidateId)
            {
                try
                {
                    bool result =
                        _candidateRepository.Delete(candidateId);

                    if (result)
                    {
                        lblMessage.Text =
                            "Candidate deleted successfully.";

                        lblMessage.CssClass =
                            "alert alert-success d-block";

                        LoadCandidates();
                    }
                    else
                    {
                        lblMessage.Text =
                            "Candidate not found.";

                        lblMessage.CssClass =
                            "alert alert-warning d-block";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text =
                        "Delete error: " +
                        ex.Message;

                    lblMessage.CssClass =
                        "alert alert-danger d-block";
                }
            }

            // ==========================================
            // BACK TO DASHBOARD
            // ==========================================

            protected void btnback_Click(
                object sender,
                EventArgs e)
            {
                Response.Redirect(
                    "~/Admin/Dashboard.aspx",
                    false);

                Context.ApplicationInstance
                    .CompleteRequest();
            }
        }
    }

    



