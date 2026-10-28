<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateDetails.aspx.cs" Inherits="ChandrashekharTest.SuperAdmin.CandidateDetails" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Candidate Details</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f4f6f9;
            margin: 0;
            padding: 30px;
        }

        .container {
            max-width: 1000px;
            margin: auto;
            background: #ffffff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,.10);
        }

        h2 {
            margin-top: 0;
            color: #222;
            border-bottom: 2px solid #eee;
            padding-bottom: 15px;
        }

        .candidate-header {
            display: flex;
            gap: 30px;
            margin-bottom: 30px;
            align-items: flex-start;
        }

        .photo {
            width: 150px;
            height: 180px;
            object-fit: cover;
            border: 1px solid #ddd;
            border-radius: 8px;
        }

        .details {
            flex: 1;
        }

        .row {
            display: flex;
            padding: 10px 0;
            border-bottom: 1px solid #eee;
        }

        .label {
            width: 220px;
            font-weight: bold;
            color: #555;
        }

        .value {
            flex: 1;
            color: #222;
        }

        .section-title {
            margin-top: 30px;
            margin-bottom: 10px;
            color: #333;
            font-size: 18px;
            font-weight: bold;
        }

        .actions {
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #ddd;
        }

        .btn {
            padding: 10px 22px;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
            margin-right: 10px;
            font-size: 14px;
        }

        .btn-approve {
            background: #198754;
        }

        .btn-reject {
            background: #dc3545;
        }

        .btn-back {
            background: #6c757d;
        }

        .message {
            display: block;
            margin-top: 15px;
            padding: 10px;
            border-radius: 5px;
        }

        .success {
            background: #d1e7dd;
            color: #0f5132;
        }

        .error {
            background: #f8d7da;
            color: #842029;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="container">

        <h1>Candidate Recruitment Management</h1>
        <h2>Candidate Details</h2>

        <asp:Panel ID="pnlCandidate" runat="server">

            <div class="candidate-header">

                <asp:Image
                    ID="imgCandidate"
                    runat="server"
                    CssClass="photo" />

                <div class="details">

                    <div class="row">
                        <div class="label">Candidate ID</div>
                        <div class="value">
                            <asp:Label ID="lblCandidateId" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Title</div>
                        <div class="value">
                            <asp:Label ID="lblTitle" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Name</div>
                        <div class="value">
                            <asp:Label ID="lblName" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Gender</div>
                        <div class="value">
                            <asp:Label ID="lblGender" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Email</div>
                        <div class="value">
                            <asp:Label ID="lblEmail" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Date of Birth</div>
                        <div class="value">
                            <asp:Label ID="lblDOB" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Education</div>
                        <div class="value">
                            <asp:Label ID="lblEducation" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Submitted Date</div>
                        <div class="value">
                            <asp:Label ID="lblSubmittedDate" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label">Status</div>
                        <div class="value">
                            <asp:Label ID="lblStatus" runat="server" />
                        </div>
                    </div>

                </div>
            </div>


            <div class="section-title">
                Permanent Address
            </div>

            <div class="row">
                <div class="label">State</div>
                <div class="value">
                    <asp:Label ID="lblPermanentState" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="label">District</div>
                <div class="value">
                    <asp:Label ID="lblPermanentDistrict" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="label">Address</div>
                <div class="value">
                    <asp:Label ID="lblPermanentAddress" runat="server" />
                </div>
            </div>


            <div class="section-title">
                Correspondence Address
            </div>

            <div class="row">
                <div class="label">State</div>
                <div class="value">
                    <asp:Label ID="lblCorrespondenceState" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="label">District</div>
                <div class="value">
                    <asp:Label ID="lblCorrespondenceDistrict" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="label">Address</div>
                <div class="value">
                    <asp:Label ID="lblCorrespondenceAddress" runat="server" />
                </div>
            </div>


            <div class="actions">

                <asp:Button
                    ID="btnApprove"
                    runat="server"
                    Text="Approve"
                    CssClass="btn btn-approve"
                    OnClick="btnApprove_Click"
                    OnClientClick="return confirm('Are you sure you want to approve this candidate?');" />

                <asp:Button
                    ID="btnReject"
                    runat="server"
                    Text="Reject"
                    CssClass="btn btn-reject"
                    OnClick="btnReject_Click"
                    OnClientClick="return confirm('Are you sure you want to reject this candidate?');" />

                <asp:Button
                    ID="btnBack"
                    runat="server"
                    Text="Back to Scrutiny"
                    CssClass="btn btn-back"
                    OnClick="btnBack_Click" />

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="message" />

            </div>

        </asp:Panel>

    </div>

</form>

</body>
</html>

