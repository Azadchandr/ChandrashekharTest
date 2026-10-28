<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateList.aspx.cs" Inherits="ChandrashekharTest.Admin.CandidateList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Candidate List</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>

        body {
            background-color: #f5f7fb;
        }

        .candidate-card {
            border: none;
            border-radius: 12px;
        }

        .candidate-photo {
            width: 70px;
            height: 80px;
            object-fit: cover;
        }

        .table th {
            background-color: #f1f5f9;
            white-space: nowrap;
        }

        .table td {
            vertical-align: middle;
        }

        .action-column {
            min-width: 210px;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="container mt-4">

        <div class="card shadow candidate-card">

            <!-- HEADER -->

            <div class="card-header bg-primary text-white
                        d-flex justify-content-between
                        align-items-center">

                <asp:Button
                    ID="btnback"
                    runat="server"
                    Text="← Dashboard"
                    CssClass="btn btn-light"
                    OnClick="btnback_Click" />

                <h4 class="mb-0">
                    Candidate List
                </h4>

                <asp:HyperLink
                    ID="lnkAddCandidate"
                    runat="server"
                    NavigateUrl="~/Admin/CandidateRegistration.aspx"
                    CssClass="btn btn-success">

                    + Add Candidate

                </asp:HyperLink>

            </div>


            <!-- BODY -->

            <div class="card-body">

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    EnableViewState="false"
                    CssClass="d-block mb-3">
                </asp:Label>


                <div class="table-responsive">

      <%--              <asp:GridView
                        ID="gvCandidate"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-bordered table-hover"
                        EmptyDataText="No candidates found."
                        GridLines="None"
                        OnRowCommand="gvCandidate_RowCommand">

                       <Columns>

    <asp:BoundField
        DataField="CandidateId"
        HeaderText="CandidateId"
        Visible="false" />

    <asp:BoundField
        DataField="Name"
        HeaderText="Name" />

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

    <asp:TemplateField HeaderText="Photo">

        <ItemTemplate>

            <asp:Image
                ID="imgPhoto"
                runat="server"
                Width="70px"
                Height="80px"
                CssClass="img-thumbnail candidate-photo"
                ImageUrl='<%# GetPhotoUrl(Eval("PhotoPath")) %>'
                AlternateText="Candidate Photo" />

        </ItemTemplate>

    </asp:TemplateField>

    <asp:TemplateField HeaderText="Action">

    <ItemStyle CssClass="action-column" />

    <ItemTemplate>

        <asp:LinkButton
            ID="btnView"
            runat="server"
            Text="View"
            CssClass="btn btn-sm btn-info text-white me-1"
            CommandName="ViewCandidate"
            CommandArgument='<%# Eval("CandidateId") %>' />

        <asp:HyperLink
            ID="btnEdit"
            runat="server"
            Text="Edit"
            CssClass="btn btn-sm btn-warning me-1"
            NavigateUrl='<%# "~/Admin/CandidateRegistration.aspx?id=" + Eval("CandidateId") %>' />

        <asp:LinkButton
            ID="btnDelete"
            runat="server"
            Text="Delete"
            CssClass="btn btn-sm btn-danger"
            CommandName="DeleteCandidate"
            CommandArgument='<%# Eval("CandidateId") %>'
            OnClientClick="return confirm('Are you sure you want to delete this candidate?');" />

    </ItemTemplate>

</asp:TemplateField>

</Columns>

                    </asp:GridView>--%>   




                    <asp:GridView
    ID="gvCandidate"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table table-bordered table-hover"
    EmptyDataText="No candidates found."
    GridLines="None"
    OnRowCommand="gvCandidate_RowCommand">

    <Columns>

        <asp:BoundField
            DataField="CandidateId"
            HeaderText="CandidateId"
            Visible="false" />

        <asp:BoundField
            DataField="Name"
            HeaderText="Name" />

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

        <asp:TemplateField HeaderText="Photo">

            <ItemTemplate>

                <asp:Image
                    ID="imgPhoto"
                    runat="server"
                    Width="70px"
                    Height="80px"
                    CssClass="img-thumbnail candidate-photo"
                    ImageUrl='<%# GetPhotoUrl(Eval("PhotoPath")) %>'
                    AlternateText="Candidate Photo" />

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Action">

            <ItemStyle CssClass="action-column" />

            <ItemTemplate>

                <asp:LinkButton
                    ID="btnView"
                    runat="server"
                    Text="View"
                    CssClass="btn btn-sm btn-info text-white me-1"
                    CommandName="ViewCandidate"
                    CommandArgument='<%# Eval("CandidateId") %>' />

                <asp:HyperLink
                    ID="btnEdit"
                    runat="server"
                    Text="Edit"
                    CssClass="btn btn-sm btn-warning me-1"
                    NavigateUrl='<%# "~/Admin/CandidateRegistration.aspx?id=" + Eval("CandidateId") %>' />

                <asp:LinkButton
                    ID="btnDelete"
                    runat="server"
                    Text="Delete"
                    CssClass="btn btn-sm btn-danger"
                    CommandName="DeleteCandidate"
                    CommandArgument='<%# Eval("CandidateId") %>'
                    OnClientClick="return confirm('Are you sure you want to delete this candidate?');" />

            </ItemTemplate>

        </asp:TemplateField>

    </Columns>

</asp:GridView>

                </div>

            </div>

        </div>

    </div>


</form>

</body>

</html>