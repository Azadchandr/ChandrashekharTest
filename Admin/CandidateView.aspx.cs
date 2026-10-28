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
    public partial class CandidateView : System.Web.UI.Page
    {
        private readonly CandidateRepository _candidateRepository = new CandidateRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAdmin();

            if (!IsPostBack)
            {
                LoadCandidate();
            }
        }

        // ==========================================
        // ADMIN CHECK
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
            }
        }

        // ==========================================
        // LOAD CANDIDATE
        // ==========================================
        private void LoadCandidate()
        {
            int candidateId;

            if (!int.TryParse(
                Request.QueryString["id"],
                out candidateId))
            {
                Response.Redirect(
                    "~/Admin/CandidateList.aspx");

                return;
            }

            try
            {
                Candidate candidate =
                    _candidateRepository.GetById(candidateId);

                if (candidate == null)
                {
                    lblMessage.Text =
                        "Candidate not found.";

                    lblMessage.CssClass =
                        "alert alert-warning d-block";

                    return;
                }

                lblName.Text =
                    candidate.TitleName + " " +
                    candidate.Name;

                lblEmail.Text =
                    candidate.Email;

                lblGender.Text =
                    candidate.Gender;

                lblDOB.Text =
                    candidate.DOB.ToString("dd-MM-yyyy");

                lblEducation.Text =
                    candidate.EducationName;

                lblStatus.Text =
                    candidate.Status;

                lblSubmittedDate.Text =
                    candidate.SubmittedDate
                    .ToString("dd-MM-yyyy HH:mm");

                lblPermanentState.Text =
                    candidate.PermanentStateName;

                lblPermanentDistrict.Text =
                    candidate.PermanentDistrictName;

                lblPermanentAddress.Text =
                    candidate.PermanentAddress;

                lblCorrespondenceState.Text =
                    candidate.CorrespondenceStateName;

                lblCorrespondenceDistrict.Text =
                    candidate.CorrespondenceDistrictName;

                lblCorrespondenceAddress.Text =
                    candidate.CorrespondenceAddress;

                // PHOTO

                if (string.IsNullOrWhiteSpace(
                    candidate.PhotoPath))
                {
                    imgPhoto.ImageUrl =
                        ResolveUrl(
                            "~/Content/images/no-photo.png");
                }
                else
                {
                    imgPhoto.ImageUrl =
                        ResolveUrl(
                            "~/" +
                            candidate.PhotoPath
                                .TrimStart('~', '/'));
                }

                // EDIT LINK

                lnkEdit.NavigateUrl =
                    "~/Admin/CandidateRegistration.aspx?id="
                    + candidateId;
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error loading candidate: "
                    + ex.Message;

                lblMessage.CssClass =
                    "alert alert-danger d-block";
            }
        }
    }
}