using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ChandrashekharTest.SuperAdmin
{
    public partial class SelectedCandidates : System.Web.UI.Page
    {
        private readonly CandidateRepository _candidateRepository =
            new CandidateRepository();


        // =====================================================
        // PAGE LOAD
        // =====================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSuperAdmin();

            // Prevent browser caching
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache);

            Response.Cache.SetNoStore();

            Response.Cache.SetExpires(
                DateTime.UtcNow.AddYears(-1));


            if (!IsPostBack)
            {
                LoadSelectedCandidates();
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
        // LOAD SELECTED CANDIDATES
        // =====================================================

        private void LoadSelectedCandidates()
        {
            try
            {
                IEnumerable<Candidate> candidates =
                    _candidateRepository.GetAll();


                // =================================================
                // IMPORTANT
                //
                // Database Status:
                // Approved = Selected
                // =================================================

                candidates = candidates.Where(x =>
                    string.Equals(
                        x.Status,
                        "Approved",
                        StringComparison.OrdinalIgnoreCase));


                // =================================================
                // SEARCH
                // =================================================

                string search =
                    txtSearch.Text.Trim();


                if (!string.IsNullOrWhiteSpace(search))
                {
                    candidates = candidates.Where(x =>
                        (
                            !string.IsNullOrEmpty(x.Name) &&
                            x.Name.IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase) >= 0
                        )
                        ||
                        (
                            !string.IsNullOrEmpty(x.Email) &&
                            x.Email.IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase) >= 0
                        )
                    );
                }


                // =================================================
                // SORT
                // =================================================

                candidates = candidates
                    .OrderByDescending(x => x.ApprovedDate);


                // =================================================
                // GRID BIND
                // =================================================

                gvCandidates.DataSource =
                    candidates.ToList();

                gvCandidates.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(
                    "Error loading selected candidates: "
                    + ex.Message);
            }
        }


        // =====================================================
        // GRID COMMAND
        // =====================================================

        protected void gvCandidates_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            int candidateId;


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
            // REJECT CANDIDATE
            // =================================================

            if (e.CommandName == "RejectCandidate")
            {
                RejectCandidate(candidateId);

                return;
            }
        }


        // =====================================================
        // REJECT SELECTED CANDIDATE
        // =====================================================

        private void RejectCandidate(int candidateId)
        {
            try
            {
                Candidate candidate =
                    _candidateRepository.GetById(candidateId);


                // =================================================
                // CANDIDATE NOT FOUND
                // =================================================

                if (candidate == null)
                {
                    ShowError(
                        "Candidate not found.");

                    return;
                }


                // =================================================
                // MAKE SURE CANDIDATE IS SELECTED
                // =================================================

                if (!string.Equals(
                    candidate.Status,
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    ShowError(
                        "This candidate is no longer selected.");

                    LoadSelectedCandidates();

                    return;
                }


                // =================================================
                // UPDATE STATUS
                // =================================================

                bool result =
                    _candidateRepository.UpdateStatus(
                        candidateId,
                        "Rejected");


                // =================================================
                // SUCCESS
                // =================================================

                if (result)
                {
                    ShowSuccess(
                        "Candidate rejected successfully.");

                    // Refresh grid
                    LoadSelectedCandidates();
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
        // SEARCH
        // =====================================================

        protected void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadSelectedCandidates();
        }


        // =====================================================
        // CLEAR
        // =====================================================

        protected void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text = "";

            LoadSelectedCandidates();
        }


        // =====================================================
        // BACK TO DASHBOARD
        // =====================================================

        //protected void btnBack_Click(
        //    object sender,
        //    EventArgs e)
        //{
        //    Response.Redirect(
        //        "~/Dashboard.aspx",
        //        false);

        //    Context.ApplicationInstance.CompleteRequest();
        //}


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

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}

