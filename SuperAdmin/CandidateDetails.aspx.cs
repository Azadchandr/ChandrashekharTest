using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChandrashekharTest.SuperAdmin
{
    public partial class CandidateDetails : System.Web.UI.Page
    {
            private readonly CandidateRepository _candidateRepository =  new CandidateRepository();

            protected void Page_Load(object sender, EventArgs e)
            {
                CheckSuperAdmin();

                if (!IsPostBack)
                {
                    LoadCandidate();
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
                }
            }

            // =====================================================
            // LOAD CANDIDATE
            // =====================================================

            private void LoadCandidate()
            {
                try
                {
                    string idValue =
                        Request.QueryString["id"];

                    int candidateId;

                    if (!int.TryParse(
                        idValue,
                        out candidateId))
                    {
                        ShowError("Invalid candidate ID.");
                        return;
                    }

                    Candidate candidate =
                        _candidateRepository.GetById(candidateId);

                    if (candidate == null)
                    {
                        ShowError(
                            "Candidate not found.");
                        return;
                    }

                    PopulateCandidate(candidate);
                }
                catch (Exception ex)
                {
                    ShowError(
                        "Error loading candidate: "
                        + ex.Message);
                }
            }

            // =====================================================
            // POPULATE DETAILS
            // =====================================================

            private void PopulateCandidate(
                Candidate candidate)
            {
                lblCandidateId.Text =
                    candidate.CandidateId.ToString();

                lblTitle.Text =
                    candidate.TitleName ?? "";

                lblName.Text =
                    candidate.Name ?? "";

                lblGender.Text =
                    candidate.Gender ?? "";

                lblEmail.Text =
                    candidate.Email ?? "";

                lblDOB.Text =
                    candidate.DOB.ToString("dd/MM/yyyy");

                lblEducation.Text =
                    candidate.EducationName ?? "";

                lblSubmittedDate.Text =
                    candidate.SubmittedDate
                        .ToString("dd/MM/yyyy");

                lblStatus.Text =
                    candidate.Status ?? "";

                // Permanent address

                lblPermanentState.Text =
                    candidate.PermanentStateName ?? "";

                lblPermanentDistrict.Text =
                    candidate.PermanentDistrictName ?? "";

                lblPermanentAddress.Text =
                    candidate.PermanentAddress ?? "";

                // Correspondence address

                lblCorrespondenceState.Text =
                    candidate.CorrespondenceStateName ?? "";

                lblCorrespondenceDistrict.Text =
                    candidate.CorrespondenceDistrictName ?? "";

                lblCorrespondenceAddress.Text =
                    candidate.CorrespondenceAddress ?? "";

                // Photo

                imgCandidate.ImageUrl =
                    GetPhotoUrl(candidate.PhotoPath);

                // Buttons according to status

                string status =
                    Convert.ToString(candidate.Status);

                if (status.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                }

                if (status.Equals(
                    "Rejected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                }
            }

            // =====================================================
            // PHOTO
            // =====================================================

            private string GetPhotoUrl(string photoPath)
            {
                if (string.IsNullOrWhiteSpace(photoPath))
                {
                    return ResolveUrl(
                        "~/Content/images/no-photo.png");
                }

                return ResolveUrl(
                    "~/" + photoPath.TrimStart(
                        '~',
                        '/'));
            }

            // =====================================================
            // APPROVE
            // =====================================================

            protected void btnApprove_Click(
                object sender,
                EventArgs e)
            {
                try
                {
                    int candidateId;

                    if (!TryGetCandidateId(
                        out candidateId))
                    {
                        return;
                    }

                    bool updated =
                        _candidateRepository.UpdateStatus(
                            candidateId,
                            "Approved");

                    if (updated)
                    {
                        Response.Redirect(
                            "~/SuperAdmin/Scrutiny.aspx",
                            false);

                        Context.ApplicationInstance
                            .CompleteRequest();
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
                        "Error approving candidate: "
                        + ex.Message);
                }
            }

            // =====================================================
            // REJECT
            // =====================================================

            protected void btnReject_Click(
                object sender,
                EventArgs e)
            {
                try
                {
                    int candidateId;

                    if (!TryGetCandidateId(
                        out candidateId))
                    {
                        return;
                    }

                    bool updated =
                        _candidateRepository.UpdateStatus(
                            candidateId,
                            "Rejected");

                    if (updated)
                    {
                        Response.Redirect(
                            "~/SuperAdmin/Scrutiny.aspx",
                            false);

                        Context.ApplicationInstance
                            .CompleteRequest();
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
                        "Error rejecting candidate: "
                        + ex.Message);
                }
            }

            // =====================================================
            // GET CANDIDATE ID
            // =====================================================

            private bool TryGetCandidateId(
                out int candidateId)
            {
                candidateId = 0;

                string idValue =
                    Request.QueryString["id"];

                if (!int.TryParse(
                    idValue,
                    out candidateId))
                {
                    ShowError(
                        "Invalid candidate ID.");

                    return false;
                }

                return true;
            }

            // =====================================================
            // BACK
            // =====================================================

            protected void btnBack_Click(
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
            // ERROR
            // =====================================================

            private void ShowError(string message)
            {
                pnlCandidate.Visible = false;

                lblMessage.Text = message;
                lblMessage.CssClass =
                    "message error";
            }
        }
    }
