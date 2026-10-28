using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using Dapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ChandrashekharTest.Admin
{
    public partial class CandidateRegistration : System.Web.UI.Page
    {
           private readonly AppDbConnection _db;
            private readonly CandidateRepository _candidateRepository;

            public CandidateRegistration()
            {
                _db = new AppDbConnection();
                _candidateRepository = new CandidateRepository();
            }

           protected void Page_Load(object sender, EventArgs e)
            {
                CheckAdmin();

                if (!IsPostBack)
                {
                    LoadTitles();
                    LoadEducation();
                    LoadStates();

                    int candidateId = GetCandidateId();

                    if (candidateId > 0)
                    {
                        LoadCandidate(candidateId);

                        btnSave.Text = "Update Candidate";
                    }
                    else
                    {
                        btnSave.Text = "Save Candidate";
                    }
                }
            }

            private void CheckAdmin()
            {
                if (Session["UserId"] == null)
                {
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
                    Response.Redirect(
                        "~/Account/Login.aspx",
                        false);

                    Context.ApplicationInstance.CompleteRequest();
                }
            }

            private int GetCandidateId()
            {
                string id = Request.QueryString["id"];

                int candidateId;

                if (int.TryParse(id, out candidateId))
                {
                    return candidateId;
                }

                return 0;
            }

            // =====================================================
            // LOAD TITLE
            // =====================================================

            private void LoadTitles()
            {
                using (var con = _db.CreateConnection())
                {
                    var data = con.Query<Title>(
                        "dbo.sp_Title_GetAll",
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    ddlTitle.DataSource = data;
                    ddlTitle.DataTextField = "TitleName";
                    ddlTitle.DataValueField = "TitleId";
                    ddlTitle.DataBind();

                    ddlTitle.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select Title --",
                            ""));
                }
            }

            // =====================================================
            // LOAD EDUCATION
            // =====================================================

            private void LoadEducation()
            {
                using (var con = _db.CreateConnection())
                {
                    var data = con.Query<Education>(
                        "dbo.sp_Education_GetAll",
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    ddlEducation.DataSource = data;
                    ddlEducation.DataTextField = "EducationName";
                    ddlEducation.DataValueField = "EducationId";
                    ddlEducation.DataBind();

                    ddlEducation.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select Education --",
                            ""));
                }
            }

            // =====================================================
            // LOAD STATES
            // =====================================================

            private void LoadStates()
            {
                using (var con = _db.CreateConnection())
                {
                    var data = con.Query<State>(
                        "dbo.sp_State_GetAll",
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    ddlPermanentState.DataSource = data;
                    ddlPermanentState.DataTextField = "StateName";
                    ddlPermanentState.DataValueField = "StateId";
                    ddlPermanentState.DataBind();

                    ddlPermanentState.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select State --",
                            ""));

                    ddlCorrespondenceState.DataSource = data;
                    ddlCorrespondenceState.DataTextField = "StateName";
                    ddlCorrespondenceState.DataValueField = "StateId";
                    ddlCorrespondenceState.DataBind();

                    ddlCorrespondenceState.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select State --",
                            ""));
                }
            }

            // =====================================================
            // LOAD PERMANENT DISTRICT
            // =====================================================

            protected void ddlPermanentState_SelectedIndexChanged(
                object sender,
                EventArgs e)
            {
                int stateId;

                if (!int.TryParse(
                    ddlPermanentState.SelectedValue,
                    out stateId))
                {
                    ddlPermanentDistrict.Items.Clear();

                    ddlPermanentDistrict.Items.Add(
                        new ListItem(
                            "-- Select District --",
                            ""));

                    return;
                }

                LoadPermanentDistrict(stateId);
            }

            private void LoadPermanentDistrict(int stateId)
            {
                using (var con = _db.CreateConnection())
                {
                    var data = con.Query<District>(
                        "dbo.sp_District_GetByState",
                        new
                        {
                            StateId = stateId
                        },
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    ddlPermanentDistrict.DataSource = data;
                    ddlPermanentDistrict.DataTextField =
                        "DistrictName";

                    ddlPermanentDistrict.DataValueField =
                        "DistrictId";

                    ddlPermanentDistrict.DataBind();

                    ddlPermanentDistrict.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select District --",
                            ""));
                }
            }

            // =====================================================
            // LOAD CORRESPONDENCE DISTRICT
            // =====================================================

            protected void ddlCorrespondenceState_SelectedIndexChanged(
                object sender,
                EventArgs e)
            {
                int stateId;

                if (!int.TryParse(
                    ddlCorrespondenceState.SelectedValue,
                    out stateId))
                {
                    ddlCorrespondenceDistrict.Items.Clear();

                    ddlCorrespondenceDistrict.Items.Add(
                        new ListItem(
                            "-- Select District --",
                            ""));

                    return;
                }

                LoadCorrespondenceDistrict(stateId);
            }

            private void LoadCorrespondenceDistrict(int stateId)
            {
                using (var con = _db.CreateConnection())
                {
                    var data = con.Query<District>(
                        "dbo.sp_District_GetByState",
                        new
                        {
                            StateId = stateId
                        },
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    ddlCorrespondenceDistrict.DataSource = data;

                    ddlCorrespondenceDistrict.DataTextField =
                        "DistrictName";

                    ddlCorrespondenceDistrict.DataValueField =
                        "DistrictId";

                    ddlCorrespondenceDistrict.DataBind();

                    ddlCorrespondenceDistrict.Items.Insert(
                        0,
                        new ListItem(
                            "-- Select District --",
                            ""));
                }
            }

            // =====================================================
            // LOAD EXISTING CANDIDATE FOR EDIT
            // =====================================================

            private void LoadCandidate(int candidateId)
            {
                try
                {
                    Candidate candidate =
                        _candidateRepository.GetById(candidateId);

                    if (candidate == null)
                    {
                        ShowMessage(
                            "Candidate not found.",
                            false);

                        return;
                    }

                    // TITLE

                    ddlTitle.SelectedValue =
                        candidate.TitleId.ToString();

                    // NAME

                    txtName.Text =
                        candidate.Name;

                    // GENDER

                    ddlGender.SelectedValue =
                        candidate.Gender;

                    // EMAIL

                    txtEmail.Text =
                        candidate.Email;

                    // DOB

                    if (candidate.DOB != null)
                    {
                        txtDOB.Text =
                            Convert.ToDateTime(
                                candidate.DOB)
                            .ToString("yyyy-MM-dd");
                    }

                    // EDUCATION

                    ddlEducation.SelectedValue =
                        candidate.EducationId.ToString();

                    // PERMANENT STATE

                    ddlPermanentState.SelectedValue =
                        candidate.PermanentStateId.ToString();

                    LoadPermanentDistrict(
                        candidate.PermanentStateId);

                    // PERMANENT DISTRICT

                    ddlPermanentDistrict.SelectedValue =
                        candidate.PermanentDistrictId.ToString();

                    // PERMANENT ADDRESS

                    txtPermanentAddress.Text =
                        candidate.PermanentAddress;

                    // CORRESPONDENCE STATE

                    ddlCorrespondenceState.SelectedValue =
                        candidate.CorrespondenceStateId.ToString();

                    LoadCorrespondenceDistrict(
                        candidate.CorrespondenceStateId);

                    // CORRESPONDENCE DISTRICT

                    ddlCorrespondenceDistrict.SelectedValue =
                        candidate.CorrespondenceDistrictId.ToString();

                    // CORRESPONDENCE ADDRESS

                    txtCorrespondenceAddress.Text =
                        candidate.CorrespondenceAddress;

                    lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    ShowMessage(
                        "Error loading candidate: " +
                        ex.Message,
                        false);
                }
            }

            // =====================================================
            // SAVE / UPDATE
            // =====================================================

            protected void btnSave_Click(object sender,EventArgs e)
            {
                try
                {
                // ----------------------------
                // CHECK LOGIN
                // ----------------------------

                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx", false);

                    return;
                }

                int userId;

                if (!int.TryParse(Session["UserId"].ToString(), out userId))
                {
                    ShowMessage("Invalid logged-in user.", false);

                    return;
                }


                // =================================================
                // VALIDATION
                // =================================================

                if (string.IsNullOrWhiteSpace(ddlTitle.SelectedValue))
                {
                    ShowMessage("Please select Title.", false);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    ShowMessage("Please enter Name.", false);

                    return;
                }

                if (string.IsNullOrWhiteSpace(ddlGender.SelectedValue))
                {
                    ShowMessage("Please select Gender.", false);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    ShowMessage("Please enter Email.", false);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDOB.Text))
                    {
                        ShowMessage("Please enter Date of Birth.",false);

                        return;
                    }

                    DateTime dob;

                    if (!DateTime.TryParse(txtDOB.Text, out dob))
                    {
                        ShowMessage("Please enter a valid Date of Birth.", false);

                        return;
                    }

                    // =================================================
                    // AGE 18 VALIDATION
                    // =================================================

                    DateTime today = DateTime.Today;

                    int age = today.Year - dob.Year;

                    if (dob.Date > today.AddYears(-age))
                    {
                        age--;
                    }

                    if (age < 18)
                    {
                        ShowMessage("Candidate must be at least 18 years old.", false);

                        return;
                    }

                    if (dob.Date > today)
                    {
                        ShowMessage("Date of Birth cannot be in the future.",false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(ddlEducation.SelectedValue))
                    {
                        ShowMessage("Please select Education.", false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(ddlPermanentState.SelectedValue))
                    {
                        ShowMessage("Please select Permanent State.",false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace( ddlPermanentDistrict.SelectedValue))
                    {
                        ShowMessage("Please select Permanent District.", false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtPermanentAddress.Text))
                    {
                        ShowMessage("Please enter Permanent Address.", false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(ddlCorrespondenceState.SelectedValue))
                    {
                        ShowMessage("Please select Correspondence State.",false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(ddlCorrespondenceDistrict.SelectedValue))
                    {
                        ShowMessage("Please select Correspondence District.",false);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtCorrespondenceAddress.Text))
                    {
                        ShowMessage("Please enter Correspondence Address.",false);

                        return;
                    }

                    // =================================================
                    // CANDIDATE ID
                    // =================================================

                    int candidateId = GetCandidateId();

                    // =================================================
                    // EXISTING PHOTO
                    // =================================================

                    string photoPath = null;

                    if (candidateId > 0)
                    {
                        Candidate existing = _candidateRepository.GetById(candidateId);

                        if (existing != null)
                        {
                            photoPath =
                                existing.PhotoPath;
                        }
                    }

                // =================================================
                // NEW PHOTO
                // =================================================

                //if (fuPhoto.HasFile)
                //{
                //    string extension =
                //        Path.GetExtension(
                //            fuPhoto.FileName)
                //        .ToLower();

                //    string[] allowedExtensions =
                //    {
                //    ".jpg",
                //    ".jpeg",
                //    ".png"
                //};

                //    if (!allowedExtensions.Contains(
                //        extension))
                //    {
                //        ShowMessage(
                //            "Only JPG, JPEG and PNG photos are allowed.",
                //            false);

                //        return;
                //    }

                //    if (fuPhoto.PostedFile.ContentLength >
                //        2 * 1024 * 1024)
                //    {
                //        ShowMessage(
                //            "Photo size must not exceed 2 MB.",
                //            false);

                //        return;
                //    }

                //    string folder =
                //        Server.MapPath(
                //            "~/Uploads/Candidate/");

                //    if (!Directory.Exists(folder))
                //    {
                //        Directory.CreateDirectory(folder);
                //    }

                //    string fileName =
                //        Guid.NewGuid()
                //        .ToString("N") +
                //        extension;

                //    string fullPath =
                //        Path.Combine(
                //            folder,
                //            fileName);

                //    fuPhoto.SaveAs(fullPath);

                //    photoPath =
                //        "~/Uploads/Candidate/" +
                //        fileName;
                //}


                if (fuPhoto.HasFile)
                {
                    string extension = Path.GetExtension(fuPhoto.FileName).ToLower();

                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                    if (!allowedExtensions.Contains(extension))
                    {
                        ShowMessage("Only JPG, JPEG and PNG photos are allowed.", false);

                        return;
                    }

                    if (fuPhoto.PostedFile.ContentLength > 2 * 1024 * 1024)
                    {
                        ShowMessage("Photo size must not exceed 2 MB.", false);

                        return;
                    }

                    string folder = Server.MapPath("~/Uploads/Candidate/");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid().ToString("N") + extension;

                    string fullPath = Path.Combine(folder, fileName);

                    fuPhoto.SaveAs(fullPath);

                    photoPath = "~/Uploads/Candidate/" + fileName;
                }

                // =================================================
                // CREATE CANDIDATE OBJECT
                // =================================================

                Candidate candidate =
                        new Candidate
                        {
                            CandidateId = candidateId,

                            TitleId =
                                Convert.ToInt32(
                                    ddlTitle.SelectedValue),

                            Name =
                                txtName.Text.Trim(),

                            Gender =
                                ddlGender.SelectedValue,

                            Email =
                                txtEmail.Text.Trim(),

                            DOB = dob,

                            EducationId =
                                Convert.ToInt32(
                                    ddlEducation.SelectedValue),

                            PermanentStateId =
                                Convert.ToInt32(
                                    ddlPermanentState.SelectedValue),

                            PermanentDistrictId =
                                Convert.ToInt32(
                                    ddlPermanentDistrict.SelectedValue),

                            PermanentAddress =
                                txtPermanentAddress.Text.Trim(),

                            CorrespondenceStateId =
                                Convert.ToInt32(
                                    ddlCorrespondenceState.SelectedValue),

                            CorrespondenceDistrictId =
                                Convert.ToInt32(
                                    ddlCorrespondenceDistrict.SelectedValue),

                            CorrespondenceAddress =
                                txtCorrespondenceAddress.Text.Trim(),

                            PhotoPath =  photoPath,

                            CreatedBy = userId
                        };

                    // =================================================
                    // UPDATE
                    // =================================================

                    if (candidateId > 0)
                    {
                        bool result =
                            _candidateRepository.Update(
                                candidate);

                        if (result)
                        {
                            Response.Redirect(
                                "~/Admin/CandidateList.aspx",
                                false);

                            Context.ApplicationInstance
                                .CompleteRequest();

                            return;
                        }

                        ShowMessage(
                            "Candidate update failed.",
                            false);

                        return;
                    }

                    // =================================================
                    // INSERT
                    // =================================================

                    int newCandidateId =
                        _candidateRepository.Insert(candidate);

                    Response.Redirect("~/Admin/CandidateList.aspx",false);

                    Context.ApplicationInstance
                        .CompleteRequest();
                }
                catch (Exception ex)
                {
                    ShowMessage(
                        "Error while saving candidate: " +
                        ex.Message,
                        false);
                }
            }

            // =====================================================
            // CLEAR
            // =====================================================

            protected void btnClear_Click(
                object sender,
                EventArgs e)
            {
                ClearForm();
            }

            private void ClearForm()
            {
                ddlTitle.SelectedIndex = 0;

                txtName.Text = "";

                ddlGender.SelectedIndex = 0;

                txtEmail.Text = "";

                txtDOB.Text = "";

                ddlEducation.SelectedIndex = 0;

                ddlPermanentState.SelectedIndex = 0;

                ddlPermanentDistrict.Items.Clear();

                ddlPermanentDistrict.Items.Add(
                    new ListItem(
                        "-- Select District --",
                        ""));

                txtPermanentAddress.Text = "";

                chkSameAddress.Checked = false;

                ddlCorrespondenceState.SelectedIndex = 0;

                ddlCorrespondenceDistrict.Items.Clear();

                ddlCorrespondenceDistrict.Items.Add(
                    new ListItem(
                        "-- Select District --",
                        ""));

                txtCorrespondenceAddress.Text = "";

                lblMessage.Text = "";
            }

            // =====================================================
            // SAME ADDRESS
            // =====================================================

            protected void chkSameAddress_CheckedChanged(
                object sender,
                EventArgs e)
            {
                if (chkSameAddress.Checked)
                {
                    txtCorrespondenceAddress.Text = txtPermanentAddress.Text;

                    if (!string.IsNullOrEmpty(ddlPermanentState.SelectedValue))
                    {
                        ddlCorrespondenceState.SelectedValue =ddlPermanentState.SelectedValue;

                        int stateId =Convert.ToInt32(ddlPermanentState.SelectedValue);

                        LoadCorrespondenceDistrict(stateId);

                        if (!string.IsNullOrEmpty(ddlPermanentDistrict.SelectedValue))
                        {
                            ddlCorrespondenceDistrict.SelectedValue =ddlPermanentDistrict.SelectedValue;
                        }
                    }
                }
                else
                {
                    txtCorrespondenceAddress.Text = "";

                    ddlCorrespondenceState.SelectedIndex = 0;

                    ddlCorrespondenceDistrict.Items.Clear();

                    ddlCorrespondenceDistrict.Items.Add(
                        new ListItem(
                            "-- Select District --",
                            ""));
                }
            }

            // =====================================================
            // MESSAGE
            // =====================================================

            private void ShowMessage(string message,bool success)
            {
                lblMessage.Text = message;

                lblMessage.CssClass = success
                        ? "alert alert-success d-block"
                        : "alert alert-danger d-block";
            }

            // =====================================================
            // BACK DASHBOARD
            // =====================================================

            protected void btnback_Click(object sender,EventArgs e)
            {
                Response.Redirect("~/Admin/Dashboard.aspx",false);

                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
