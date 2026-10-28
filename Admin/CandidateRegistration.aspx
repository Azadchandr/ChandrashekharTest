<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateRegistration.aspx.cs" Inherits="ChandrashekharTest.Admin.CandidateRegistration" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Candidate Registration</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>

<body>

<form id="form1"
      runat="server"
      enctype="multipart/form-data">

    <div class="container mt-4">

        <div class="card shadow">

           <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center position-relative">
    <!-- Centered: Title -->
    <h4 class="mb-0 mx-auto">Candidate Registration</h4>
    
    <!-- Right corner: Button -->
    <asp:Button ID="btnback" runat="server" Text="Back DashBoard" CssClass="btn btn-success position-absolute" style="right: 15px;" OnClick="btnback_Click" />
</div>



            <div class="card-body">

                <asp:Label ID="lblMessage" runat="server"  EnableViewState="false" />

                <!-- Title -->

                <div class="row mb-3">

                    <div class="col-md-3">

                        <label class="form-label">
                            Title
                        </label>

                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                            <asp:ListItem Text="-- Select Title --" Value="" />

                        </asp:DropDownList>

                    </div>

                    <!-- Name -->

                    <div class="col-md-9">

                        <label class="form-label">
                            Name
                        </label>

                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="100" />

                    </div>

                </div>


                <!-- Gender / Email / DOB -->

                <div class="row mb-3">

                    <div class="col-md-4">

                        <label class="form-label">
                            Gender
                        </label>

                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">

                            <asp:ListItem Text="-- Select Gender --" Value="" />

                            <asp:ListItem Text="Male" Value="Male" />

                            <asp:ListItem Text="Female" Value="Female" />

                            <asp:ListItem Text="Other"  Value="Other" />

                        </asp:DropDownList>

                    </div>

                    <div class="col-md-4">

                        <label class="form-label">
                            Email
                        </label>

                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="150" TextMode="Email" />

                    </div>

                    <div class="col-md-4">

                        <label class="form-label">
                            Date of Birth
                        </label>

                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date" />

                    </div>

                </div>


                <!-- Education -->

                <div class="row mb-3">

                    <div class="col-md-6">

                        <label class="form-label">
                            Education
                        </label>

                        <asp:DropDownList
                            ID="ddlEducation" runat="server" CssClass="form-control">

                            <asp:ListItem Text="-- Select Education --" Value="" />

                        </asp:DropDownList>

                    </div>

                </div>


                <!-- Permanent Address -->

                <h5 class="border-bottom pb-2 mt-4">
                    Permanent Address
                </h5>

                <div class="mb-3">

                    <label class="form-label">
                        Address
                    </label>

                    <asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" TextMode="MultiLine" ows="3" MaxLength="500" />

                </div>

                <div class="row mb-3">

                    <div class="col-md-4">

                        <label class="form-label">
                            State
                        </label>

                        <asp:DropDownList ID="ddlPermanentState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPermanentState_SelectedIndexChanged">

                            <asp:ListItem Text="-- Select State --" Value="" />
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-4">

                        <label class="form-label">
                            District
                        </label>

                        <asp:DropDownList
                            ID="ddlPermanentDistrict" runat="server" CssClass="form-control">

                            <asp:ListItem Text="-- Select District --" Value="" />

                        </asp:DropDownList>

                    </div>

                </div>


                <!-- Correspondence Address -->

               
                <h5 class="border-bottom pb-2 mt-4">
                    Correspondence Address
                </h5>
                   
                <asp:CheckBox  ID="chkSameAddress" runat="server" Text=" Same as Permanent Address" AutoPostBack="true" OnCheckedChanged="chkSameAddress_CheckedChanged" />
                <div class="mb-3">

                    <label class="form-label">
                        Address
                    </label>

                    <asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="500" />

                </div>

                <div class="row mb-3">

                    <div class="col-md-4">

                        <label class="form-label">
                            State
                        </label>

                        <asp:DropDownList ID="ddlCorrespondenceState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCorrespondenceState_SelectedIndexChanged">

                            <asp:ListItem Text="-- Select State --" Value="" />

                        </asp:DropDownList>

                    </div>

                    <div class="col-md-4">

                        <label class="form-label">
                            District
                        </label>

                        <asp:DropDownList ID="ddlCorrespondenceDistrict" runat="server" CssClass="form-control">

                            <asp:ListItem Text="-- Select District --" Value="" />

                        </asp:DropDownList>

                    </div>

                </div>

                <!-- Photo -->

                <div class="mb-3">

                    <label class="form-label">
                        Photo
                    </label>

                    <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" />

                </div>


                <!-- Buttons -->

                <div class="mt-4">

                    <asp:Button ID="btnSave" runat="server" Text="Save Candidate" CssClass="btn btn-primary" OnClick="btnSave_Click" />

                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary ms-2" CausesValidation="false" OnClick="btnClear_Click" />


                    <%--<asp:Button ID="btnback" runat="server" Text="Back DashBoard" CssClass="btn btn-success" OnClick="btnback_Click" />--%>

                </div>

            </div>

        </div>

    </div>

</form>

</body>
</html>







