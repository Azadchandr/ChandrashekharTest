<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateView.aspx.cs" Inherits="ChandrashekharTest.Admin.CandidateView" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Candidate Details</title>

    <meta name="viewport"
          content="width=device-width, initial-scale=1" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
          rel="stylesheet" />

    <style>

        body {
            background-color: #f5f7fb;
        }

        .candidate-card {
            border: none;
            border-radius: 14px;
        }

        .candidate-photo {
            width: 150px;
            height: 180px;
            object-fit: cover;
            border-radius: 10px;
        }

        .field-label {
            font-weight: 600;
            color: #475569;
        }

        .field-value {
            color: #111827;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="container mt-4 mb-5">

        <div class="card shadow candidate-card">

            <div class="card-header bg-primary text-white">

                <div class="d-flex justify-content-between align-items-center">

                    <h4 class="mb-0">
                        Candidate Details
                    </h4>

                    <a href="CandidateList.aspx"
                       class="btn btn-light btn-sm">
                        Back to List
                    </a>

                </div>

            </div>


            <div class="card-body">

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block mb-3">
                </asp:Label>


                <div class="row">

                    <!-- PHOTO -->

                    <div class="col-md-3 text-center mb-4">

                        <asp:Image
                            ID="imgPhoto"
                            runat="server"
                            CssClass="candidate-photo img-thumbnail"
                            AlternateText="Candidate Photo" />

                    </div>


                    <!-- BASIC DETAILS -->

                    <div class="col-md-9">

                        <div class="row g-3">

                            <div class="col-md-6">

                                <div class="field-label">
                                    Name
                                </div>

                                <asp:Label
                                    ID="lblName"
                                    runat="server"
                                    CssClass="field-value">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Email
                                </div>

                                <asp:Label
                                    ID="lblEmail"
                                    runat="server"
                                    CssClass="field-value">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Gender
                                </div>

                                <asp:Label
                                    ID="lblGender"
                                    runat="server">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Date of Birth
                                </div>

                                <asp:Label
                                    ID="lblDOB"
                                    runat="server">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Education
                                </div>

                                <asp:Label
                                    ID="lblEducation"
                                    runat="server">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Status
                                </div>

                                <asp:Label
                                    ID="lblStatus"
                                    runat="server"
                                    CssClass="badge bg-primary">
                                </asp:Label>

                            </div>


                            <div class="col-md-6">

                                <div class="field-label">
                                    Submitted Date
                                </div>

                                <asp:Label
                                    ID="lblSubmittedDate"
                                    runat="server">
                                </asp:Label>

                            </div>

                        </div>

                    </div>

                </div>


                <hr class="my-4" />


                <!-- PERMANENT ADDRESS -->

                <h5 class="text-primary">
                    Permanent Address
                </h5>

                <div class="row g-3 mt-1">

                    <div class="col-md-6">

                        <div class="field-label">
                            State
                        </div>

                        <asp:Label
                            ID="lblPermanentState"
                            runat="server">
                        </asp:Label>

                    </div>


                    <div class="col-md-6">

                        <div class="field-label">
                            District
                        </div>

                        <asp:Label
                            ID="lblPermanentDistrict"
                            runat="server">
                        </asp:Label>

                    </div>


                    <div class="col-md-12">

                        <div class="field-label">
                            Address
                        </div>

                        <asp:Label
                            ID="lblPermanentAddress"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <hr class="my-4" />


                <!-- CORRESPONDENCE ADDRESS -->

                <h5 class="text-primary">
                    Correspondence Address
                </h5>

                <div class="row g-3 mt-1">

                    <div class="col-md-6">

                        <div class="field-label">
                            State
                        </div>

                        <asp:Label
                            ID="lblCorrespondenceState"
                            runat="server">
                        </asp:Label>

                    </div>


                    <div class="col-md-6">

                        <div class="field-label">
                            District
                        </div>

                        <asp:Label
                            ID="lblCorrespondenceDistrict"
                            runat="server">
                        </asp:Label>

                    </div>


                    <div class="col-md-12">

                        <div class="field-label">
                            Address
                        </div>

                        <asp:Label
                            ID="lblCorrespondenceAddress"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <hr class="my-4" />


                <!-- ACTIONS -->

                <div class="text-end">

                    <asp:HyperLink
                        ID="lnkEdit"
                        runat="server"
                        Text="Edit Candidate"
                        CssClass="btn btn-warning me-2" />

                    <asp:HyperLink
                        ID="lnkBack"
                        runat="server"
                        NavigateUrl="~/Admin/CandidateList.aspx"
                        Text="Back to List"
                        CssClass="btn btn-secondary" />

                </div>

            </div>

        </div>

    </div>

</form>

</body>

</html>
