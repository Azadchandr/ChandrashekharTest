<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scrutiny.aspx.cs" Inherits="ChandrashekharTest.SuperAdmin.Scrutiny" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Candidate Scrutiny</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
          rel="stylesheet" />

    <style>

        /* =========================================
           BODY
           ========================================= */

        body {
            background-color: #f5f7fb;
            font-family: "Segoe UI", Arial, sans-serif;
            color: #334155;
        }


        /* =========================================
           MAIN CARD
           ========================================= */

        .scrutiny-card {
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


        /* =========================================
           HEADER CENTER CONTENT
           ========================================= */

        .header-content {
            text-align: center;
        }


        .page-title {
            font-size: 24px;
            font-weight: 600;
            margin: 0;
            color: #ffffff;
        }


        .page-subtitle {
            font-size: 13px;
            color: #cbd5e1;
            margin-top: 6px;
        }


        /* =========================================
           DASHBOARD BUTTON - RIGHT
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

            color: #ffffff;

            font-weight: 500;

            border-radius: 7px;

            padding: 8px 18px;

            cursor: pointer;
        }


        .dashboard-btn:hover {
            background-color: #1d4ed8;
            border-color: #1d4ed8;
            color: #ffffff;
        }


        /* =========================================
           FILTER BOX
           ========================================= */

        .filter-box {
            background: #ffffff;

            border: 1px solid #e5e7eb;

            border-radius: 10px;

            padding: 15px;
        }


        /* =========================================
           FORM
           ========================================= */

        .form-control,
        .form-select {
            min-height: 40px;

            border-radius: 7px;

            font-size: 13px;
        }


        .form-control:focus,
        .form-select:focus {
            border-color: #2563eb;

            box-shadow:
                0 0 0 0.15rem
                rgba(37, 99, 235, 0.15);
        }


        /* =========================================
           TABLE
           ========================================= */

        .table {
            margin-bottom: 0;
        }


        .table th {
            background-color: #f1f5f9;

            white-space: nowrap;

            font-size: 13px;

            color: #334155;

            font-weight: 600;

            vertical-align: middle;

            padding: 13px 10px;
        }


        .table td {
            vertical-align: middle;

            font-size: 13px;

            padding: 12px 10px;
        }


        .table tbody tr:hover {
            background-color: #f8fafc;
        }


        /* =========================================
           CANDIDATE NAME
           ========================================= */

        .candidate-name {
            font-weight: 600;

            color: #1e293b;
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
           ACTION
           ========================================= */

        .action-column {
            min-width: 260px;

            white-space: nowrap;
        }


        .action-column .btn {
            margin-bottom: 3px;
        }


        /* =========================================
           STATUS
           ========================================= */

        .status-pending {
            display: inline-block;

            background: #fff7ed;

            color: #c2410c;

            padding: 5px 10px;

            border-radius: 20px;

            font-size: 11px;

            font-weight: 600;
        }


        .status-selected {
            display: inline-block;

            background: #dcfce7;

            color: #15803d;

            padding: 5px 10px;

            border-radius: 20px;

            font-size: 11px;

            font-weight: 600;
        }


        .status-rejected {
            display: inline-block;

            background: #fee2e2;

            color: #b91c1c;

            padding: 5px 10px;

            border-radius: 20px;

            font-size: 11px;

            font-weight: 600;
        }


        /* =========================================
           SUCCESS MESSAGE
           ========================================= */

        .success-message {
            display: block;

            color: #15803d;

            background: #dcfce7;

            border: 1px solid #bbf7d0;

            padding: 10px 15px;

            border-radius: 7px;
        }


        /* =========================================
           ERROR MESSAGE
           ========================================= */

        .error-message {
            display: block;

            color: #b91c1c;

            background: #fee2e2;

            border: 1px solid #fecaca;

            padding: 10px 15px;

            border-radius: 7px;
        }


        /* =========================================
           EMPTY MESSAGE
           ========================================= */

        .empty-message {
            padding: 40px !important;

            text-align: center;

            color: #64748b;
        }


        /* =========================================
           MOBILE
           ========================================= */

        @media (max-width: 768px) {

            .page-header {
                padding: 20px;

                min-height: 150px;
            }


            .header-content {
                padding-top: 10px;
            }


            .page-title {
                font-size: 20px;
            }


            .page-subtitle {
                font-size: 12px;
            }


            .header-button {
                position: absolute;

                right: 15px;

                top: auto;

                bottom: 15px;

                transform: none;
            }


            .dashboard-btn {
                padding: 6px 12px;

                font-size: 12px;
            }


            .action-column {
                min-width: 230px;
            }

        }

    </style>

</head>


<body>

<form id="form1" runat="server">


    <div class="container-fluid px-4 py-4">


        <div class="card shadow-sm scrutiny-card">


            <!-- =================================================
                 HEADER
                 ================================================= -->

            <div class="page-header">


                <!-- CENTER TITLE -->

                <div class="header-content">

                    <h3 class="page-title">
                        List of Candidates for Review 
                    </h3>

                    <h1>Candidate Recruitment Management</h1>
                    <%--<div class="page-subtitle">
                        Super Admin - Review and verify candidate applications
                    </div>--%>

                </div>


                <!-- RIGHT BLUE BUTTON -->

                <div class="header-button">

                    <asp:Button
                        ID="btnBack"
                        runat="server"
                        Text="← Dashboard"
                        CssClass="dashboard-btn"
                        OnClick="btnBack_Click" />

                </div>


            </div>


            <!-- =================================================
                 BODY
                 ================================================= -->

            <div class="card-body p-4">


                <!-- =================================================
                     MESSAGE
                     ================================================= -->

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block mb-3">
                </asp:Label>


                <!-- =================================================
                     FILTER
                     ================================================= -->

                <div class="filter-box mb-4">


                    <div class="row g-2 align-items-center">


                        <!-- SEARCH -->

                        <div class="col-lg-5 col-md-5">

                            <asp:TextBox
                                ID="txtSearch"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Search candidate name / email">
                            </asp:TextBox>

                        </div>


                        <!-- STATUS -->

                        <div class="col-lg-3 col-md-3">

                            <asp:DropDownList
                                ID="ddlStatus"
                                runat="server"
                                CssClass="form-select">

                                <asp:ListItem
                                    Text="All Status"
                                    Value="">
                                </asp:ListItem>

                                <asp:ListItem
                                    Text="Pending"
                                    Value="Pending">
                                </asp:ListItem>

                                <asp:ListItem
                                    Text="Approved"
                                    Value="Approved">
                                </asp:ListItem>

                                <asp:ListItem
                                    Text="Rejected"
                                    Value="Rejected">
                                </asp:ListItem>

                            </asp:DropDownList>

                        </div>


                        <!-- SEARCH BUTTON -->

                        <div class="col-lg-2 col-md-2">

                            <asp:Button
                                ID="btnSearch"
                                runat="server"
                                Text="Search"
                                CssClass="btn btn-primary w-100"
                                OnClick="btnSearch_Click" />

                        </div>


                        <!-- CLEAR BUTTON -->

                        <div class="col-lg-2 col-md-2">

                            <asp:Button
                                ID="btnClear"
                                runat="server"
                                Text="Clear"
                                CssClass="btn btn-secondary w-100"
                                OnClick="btnClear_Click" />

                        </div>


                    </div>

                </div>


                <!-- =================================================
                     GRID
                     ================================================= -->

                <div class="table-responsive">


                    <asp:GridView
                        ID="gvCandidates"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-bordered table-hover mb-0"
                        GridLines="None"
                        EmptyDataText="No candidates found for scrutiny."
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


                           


                            <asp:BoundField
                                DataField="SubmittedDate"
                                HeaderText="Submitted Date"
                                DataFormatString="{0:dd-MM-yyyy HH:mm}" />


                        


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

                                    <span class='<%# GetStatusClass(Eval("Status")) %>'>

                                        <%# Eval("Status") %>

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
                                        ID="btnApprove"
                                        runat="server"
                                        Text="Approve"
                                        CssClass="btn btn-sm btn-success me-1"
                                        CommandName="ApproveCandidate"
                                        CommandArgument='<%# Eval("CandidateId") %>'
                                        OnClientClick="return confirm('Are you sure you want to approve this candidate?');" />



                                    <asp:LinkButton
                                        ID="btnReject"
                                        runat="server"
                                        Text="Reject"
                                        CssClass="btn btn-sm btn-danger"
                                        CommandName="RejectCandidate"
                                        CommandArgument='<%# Eval("CandidateId") %>'
                                        OnClientClick="return confirm('Are you sure you want to reject this candidate?');" />


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


<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js">
</script>

</body>

</html>
