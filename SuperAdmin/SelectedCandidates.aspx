<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectedCandidates.aspx.cs" Inherits="ChandrashekharTest.SuperAdmin.SelectedCandidates" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Selected Candidates</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
          rel="stylesheet" />

    <style>

        body {
            background-color: #f5f7fb;
            font-family: "Segoe UI", Arial, sans-serif;
        }

        .candidate-card {
            border: none;
            border-radius: 14px;
            overflow: hidden;
        }

        /* =========================================
           HEADER
        ========================================= */

        .page-header {
            position: relative;
            background: #172554;
            color: white;
            min-height: 120px;
            padding: 25px;

            display: flex;
            align-items: center;
            justify-content: center;
        }

        .header-content {
            text-align: center;
        }

        .page-title {
            font-size: 24px;
            font-weight: 600;
            margin: 0;
        }

        .page-subtitle {
            font-size: 13px;
            color: #cbd5e1;
            margin-top: 6px;
        }
        .header-button {
    position: absolute;
    right: 25px;
    top: 50%;
    transform: translateY(-50%);
}

.dashboard-btn {
    display: inline-block;
    background-color: #2563eb;
    color: #ffffff;
    border: 1px solid #2563eb;
    padding: 8px 18px;
    border-radius: 7px;
    text-decoration: none;
    font-size: 14px;
    font-weight: 500;
    transition: 0.2s;
}

.dashboard-btn:hover {
    background-color: #1d4ed8;
    border-color: #1d4ed8;
    color: #ffffff;
    text-decoration: none;
}


        /* =========================================
           DASHBOARD BUTTON
        ========================================= */

        .header-button {
            position: absolute;
            right: 25px;
            top: 50%;
            transform: translateY(-50%);
        }

        .dashboard-btn {
            background-color: #2563eb;
            border: 1px solid #2563eb;
            color: white;
            font-weight: 500;
            border-radius: 7px;
            padding: 8px 18px;
        }

        .dashboard-btn:hover {
            background-color: #1d4ed8;
            border-color: #1d4ed8;
            color: white;
        }

        /* =========================================
           FILTER
        ========================================= */

        .filter-box {
            background: #ffffff;
            border: 1px solid #e5e7eb;
            border-radius: 10px;
            padding: 15px;
        }

        /* =========================================
           PHOTO
        ========================================= */

        .candidate-photo {
            width: 65px;
            height: 75px;
            object-fit: cover;
            border-radius: 6px;
        }

        /* =========================================
           TABLE
        ========================================= */

        .table th {
            background-color: #f1f5f9;
            white-space: nowrap;
            font-size: 13px;
            color: #334155;
            vertical-align: middle;
        }

        .table td {
            vertical-align: middle;
            font-size: 13px;
        }

        .candidate-name {
            font-weight: 600;
            color: #1e293b;
        }

        /* =========================================
           STATUS
        ========================================= */

        .status-selected {
            background: #dcfce7;
            color: #15803d;
            padding: 5px 10px;
            border-radius: 20px;
            font-size: 11px;
            font-weight: 600;
        }

        /* =========================================
           ACTION
        ========================================= */

        .action-column {
            min-width: 170px;
            white-space: nowrap;
        }

        /* =========================================
           MESSAGE
        ========================================= */

        .success-message {
            display: block;
            color: #15803d;
            background: #dcfce7;
            border: 1px solid #bbf7d0;
            padding: 10px 15px;
            border-radius: 7px;
        }

        .error-message {
            display: block;
            color: #b91c1c;
            background: #fee2e2;
            border: 1px solid #fecaca;
            padding: 10px 15px;
            border-radius: 7px;
        }

        /* =========================================
           EMPTY
        ========================================= */

        .empty-message {
            padding: 40px !important;
            text-align: center;
            color: #64748b;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="container-fluid px-4 py-4">

        <div class="card shadow-sm candidate-card">

            <!-- =========================================
                 HEADER
            ========================================== -->

            <div class="page-header">

                <div class="header-content">
                    <h1>Candidate Recruitment Management</h1>
                    <h3 class="page-title">
                        List of Selected Candidates
                    </h3>
                    
                </div>


                <!-- DASHBOARD BUTTON -->

               <%-- <div class="header-button">

                 <asp:Button ID="btnBack" runat="server" Text="← Dashboard" CssClass="dashboard-btn" OnClick="btnBack_Click" />

                 </div>--%>

                <!-- DASHBOARD BUTTON -->

     <div class="header-button">

    <a href="Dashboard.aspx" class="dashboard-btn">
        ← Dashboard
    </a>

</div>


            </div>


            <!-- =========================================
                 BODY
            ========================================== -->

            <div class="card-body p-4">


                <!-- MESSAGE -->

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block mb-3">
                </asp:Label>


                <!-- =========================================
                     SEARCH
                ========================================== -->

                <div class="filter-box mb-4">

                    <div class="row g-2">

                        <div class="col-md-5">

                            <asp:TextBox
                                ID="txtSearch"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Search candidate name / email">
                            </asp:TextBox>

                        </div>


                        <div class="col-md-2">

                            <asp:Button
                                ID="btnSearch"
                                runat="server"
                                Text="Search"
                                CssClass="btn btn-primary w-100"
                                OnClick="btnSearch_Click" />

                        </div>


                        <div class="col-md-2">

                            <asp:Button
                                ID="btnClear"
                                runat="server"
                                Text="Clear"
                                CssClass="btn btn-secondary w-100"
                                OnClick="btnClear_Click" />

                        </div>

                    </div>

                </div>


                <!-- =========================================
                     GRID
                ========================================== -->

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvCandidates"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-bordered table-hover mb-0"
                        GridLines="None"
                        EmptyDataText="No selected candidates found."
                        OnRowCommand="gvCandidates_RowCommand">

                        <Columns>


                            <asp:BoundField
                                DataField="CandidateId"
                                HeaderText="Candidate ID" />


                            <asp:TemplateField
                                HeaderText="Candidate Name">

                                <ItemTemplate>

                                    <span class="candidate-name">
                                        <%# Eval("Name") %>
                                    </span>

                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:BoundField
                                DataField="Email"
                                HeaderText="Email" />

                            <asp:BoundField
                                DataField="DOB"
                                HeaderText="DOB"
                                DataFormatString="{0:dd-MM-yyyy}" />

                            <asp:BoundField
                                DataField="EducationName"
                                HeaderText="Education" />

                            <asp:TemplateField
                                HeaderText="Photo">

                                <ItemTemplate>

                                    <asp:Image
                                        ID="imgPhoto"
                                        runat="server"
                                        Width="65px"
                                        Height="75px"
                                        CssClass="candidate-photo img-thumbnail"
                                        ImageUrl='<%# GetPhotoUrl(Eval("PhotoPath")) %>'
                                        AlternateText="Candidate Photo" />

                                </ItemTemplate>

                            </asp:TemplateField>


                            <asp:TemplateField
                                HeaderText="Status">

                                <ItemTemplate>

                                    <span class="status-selected">
                                        Selected
                                    </span>

                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField
                                HeaderText="Action">

                                <ItemStyle
                                    CssClass="action-column" />

                                <ItemTemplate>


                                    <asp:LinkButton
                                        ID="btnView"
                                        runat="server"
                                        Text="View"
                                        CssClass="btn btn-sm btn-info text-white me-1"
                                        CommandName="ViewCandidate"
                                        CommandArgument='<%# Eval("CandidateId") %>' />


                                    <asp:LinkButton
                                        ID="btnReject"
                                        runat="server"
                                        Text="Reject"
                                        CssClass="btn btn-sm btn-danger"
                                        CommandName="RejectCandidate"
                                        CommandArgument='<%# Eval("CandidateId") %>'
                                        OnClientClick="return confirm('Are you sure you want to reject this selected candidate?');" />

                                </ItemTemplate>

                            </asp:TemplateField>


                        </Columns>


                        <EmptyDataRowStyle
                            CssClass="empty-message" />

                    </asp:GridView>

                </div>

            </div>

        </div>

    </div>

</form>

</body>

</html>

