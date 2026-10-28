using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ChandrashekharTest.SuperAdmin
{
    public partial class RejectedCandidates : System.Web.UI.Page
    {
        private readonly CandidateRepository _candidateRepository =
            new CandidateRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSuperAdmin();

            if (!IsPostBack)
            {
                LoadRejectedCandidates();
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
        // LOAD REJECTED CANDIDATES
        // =====================================================

        private void LoadRejectedCandidates()
        {
            try
            {
                IEnumerable<Candidate> candidates =
                    _candidateRepository.GetAll();

                // Only Rejected candidates
                candidates = candidates.Where(x =>
                    string.Equals(
                        x.Status,
                        "Rejected",
                        StringComparison.OrdinalIgnoreCase));

                gvCandidates.DataSource =
                    candidates.ToList();

                gvCandidates.DataBind();

                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error loading rejected candidates: "
                    + Server.HtmlEncode(ex.Message);

                lblMessage.CssClass =
                    "error-message";
            }
        }

        // =====================================================
        // VIEW CANDIDATE
        // =====================================================

        protected void btnView_Click(
            object sender,
            EventArgs e)
        {
            LinkButton btn =
                (LinkButton)sender;

            string candidateId =
                btn.CommandArgument;

            Response.Redirect(
                "~/SuperAdmin/CandidateDetails.aspx?id="
                + candidateId,
                false);

            Context.ApplicationInstance.CompleteRequest();
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
    }
}


