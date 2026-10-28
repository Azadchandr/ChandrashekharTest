<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ChandrashekharTest.Admin.Dashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title> Admin Dashboard - Candidate Management</title>

    <meta name="viewport"
          content="width=device-width, initial-scale=1" />

    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
        rel="stylesheet" />

    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css"
        rel="stylesheet" />

    <style>

        body {
            margin: 0;
            background: #f5f7fb;
            font-family: "Segoe UI", Arial, sans-serif;
            color: #263238;
        }

        /* Sidebar */

        .sidebar {
            position: fixed;
            left: 0;
            top: 0;
            bottom: 0;
            width: 245px;
            background: #172554;
            color: white;
            padding: 24px 15px;
        }

        .brand {
          display: flex;
          align-items: center;
          gap: 10px;
          white-space: nowrap;

        }

        .brand i {
                  font-size: 24px;
        }

        .brand span {
             font-size: 20px;
             font-weight: 600;
}
        .brand {
           display: flex;
           align-items: center;
           gap: 6px;
           white-space: nowrap;
}

        .brand {
            font-size: 21px;
            font-weight: 600;
            padding: 0 12px 30px;
        }

        .brand i {
            color: #60a5fa;
            margin-right: 8px;
        }

        .menu-title {
            font-size: 11px;
            color: #94a3b8;
            text-transform: uppercase;
            letter-spacing: 1px;
            padding: 0 12px;
            margin-bottom: 8px;
        }

        .sidebar-link {
            display: flex;
            align-items: center;
            gap: 12px;
            color: #cbd5e1;
            text-decoration: none;
            padding: 12px 14px;
            border-radius: 8px;
            margin-bottom: 5px;
            transition: 0.2s;
        }

        .sidebar-link:hover,
        .sidebar-link.active {
            background: #2563eb;
            color: white;
        }

        .sidebar-link i {
            font-size: 17px;
        }

        /* Main */

        .main {
            margin-left: 245px;
            min-height: 100vh;
        }

        /* Topbar */

        .topbar {
            height: 72px;
            background: white;
            border-bottom: 1px solid #e5e7eb;
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 0 32px;
        }

        .page-title {
            font-size: 21px;
            font-weight: 600;
            margin: 0;
        }

        .welcome {
            color: #64748b;
            font-size: 14px;
        }

        .user-box {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .user-icon {
            width: 38px;
            height: 38px;
            border-radius: 50%;
            background: #dbeafe;
            color: #2563eb;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 18px;
        }

        /* Content */

        .content {
            padding: 30px 32px;
        }

        .welcome-heading {
            margin-bottom: 25px;
        }

        .welcome-heading h3 {
            font-size: 24px;
            font-weight: 600;
            margin-bottom: 5px;
        }

        .welcome-heading p {
            color: #64748b;
            margin: 0;
        }

        /* Stats */

        .stat-card {
            background: white;
            border: 1px solid #e8ecf2;
            border-radius: 12px;
            padding: 20px;
            height: 100%;
            box-shadow: 0 2px 8px rgba(15, 23, 42, 0.03);
        }

        .stat-icon {
            width: 45px;
            height: 45px;
            border-radius: 10px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 20px;
            margin-bottom: 15px;
        }

        .icon-blue {
            background: #dbeafe;
            color: #2563eb;
        }

        .icon-orange {
            background: #ffedd5;
            color: #ea580c;
        }

        .icon-green {
            background: #dcfce7;
            color: #16a34a;
        }

        .icon-red {
            background: #fee2e2;
            color: #dc2626;
        }

        .stat-title {
            color:#09fa49;
            font-size: 14px;
            margin-bottom: 4px;
        }

        .stat-value {
            font-size: 27px;
            font-weight: 600;
            color: #172033;
        }

        /* Quick Actions */

        .section-title {
            font-size: 18px;
            font-weight: 600;
            margin-bottom: 15px;
        }

        .action-card {
            background: white;
            border: 1px solid #e8ecf2;
            border-radius: 12px;
            padding: 24px;
            height: 100%;
            transition: 0.2s;
        }

        .action-card:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 18px rgba(15, 23, 42, 0.08);
        }

        .action-icon {
            width: 48px;
            height: 48px;
            border-radius: 10px;
            background: #eff6ff;
            color: #2563eb;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 21px;
            margin-bottom: 15px;
        }

        .action-card h5 {
            font-size: 17px;
            font-weight: 600;
        }

        .action-card p {
            color: #64748b;
            font-size: 14px;
            min-height: 42px;
        }

        .btn-dashboard {
            background: #2563eb;
            border: none;
            color: white;
            padding: 9px 18px;
            border-radius: 7px;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
        }

        .btn-dashboard:hover {
            background: #1d4ed8;
            color: white;
        }

        .btn-outline-dashboard {
            border: 1px solid #d1d5db;
            color: #374151;
            padding: 8px 17px;
            border-radius: 7px;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
        }

        .btn-outline-dashboard:hover {
            background: #f8fafc;
            color: #111827;
        }

        /* Responsive */

        @media (max-width: 768px) {

            .sidebar {
                width: 70px;
                padding: 20px 8px;
            }

            .brand span,
            .menu-title,
            .sidebar-link span {
                display: none;
            }

            .sidebar-link {
                justify-content: center;
            }

            .main {
                margin-left: 70px;
            }

            .topbar {
                padding: 0 15px;
            }

            .content {
                padding: 20px 15px;
            }
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <!-- SIDEBAR -->

    <aside class="sidebar">

        <div class="brand">

            <i class="bi bi-person-vcard"></i>

             

            <span>
                Admin Portal
            </span>

        </div>
          

        <a href="Dashboard.aspx" class="sidebar-link active">

            <i class="bi bi-grid-1x2-fill"></i>

            <span>Dashboard</span>
           

        </a>

        <a href="CandidateRegistration.aspx"
           class="sidebar-link">

            <i class="bi bi-person-plus"></i>

            <span>Register Candidate</span>

        </a>

        <a href="CandidateList.aspx"
           class="sidebar-link">

            <i class="bi bi-people"></i>

            <span>Candidate List</span>

        </a>

        <div class="menu-title mt-4">
            Account
        </div>

        <asp:LinkButton
            ID="btnLogout"
            runat="server"
            CssClass="sidebar-link border-0 w-100 text-start"
            OnClick="btnLogout_Click">

            <i class="bi bi-box-arrow-right"></i>

            <span>Logout</span>

        </asp:LinkButton>

    </aside>


    <!-- MAIN -->

    <main class="main">

        <!-- TOPBAR -->

        <header class="topbar">

            <div>

                <h1 class="page-title">
                    Dashboard
                </h1>

            </div>

            <div class="user-box">

                <div class="user-icon">

                    <i class="bi bi-person"></i>

                </div>

                <div>

                    <div class="welcome">
                        Welcome
                    </div>

                    <strong>
                        <asp:Label
                            ID="lblUserName"
                            runat="server" />
                    </strong>

                </div>

            </div>

        </header>


        <!-- CONTENT -->

        <section class="content">

            <!-- Welcome -->

            <div class="welcome-heading">

                <h3>
                    Welcome back,
                    <asp:Label
                        ID="lblWelcomeName"
                        runat="server" />
                </h3>

                <p>
                    Manage candidate registrations and information
                    from your dashboard.
                </p>

            </div>


            <!-- STATISTICS -->

            <div class="row g-4 mb-4">

                <div class="col-xl-3 col-md-6">

                    <div class="stat-card">

                        <div class="stat-icon icon-blue">

                            <i class="bi bi-people-fill"></i>

                        </div>

                        <div class="stat-title">
                            Total Candidates
                        </div>

                        <div class="stat-value">
                            <asp:Label
                                ID="lblTotalCandidates"
                                runat="server"
                                Text="0" />
                        </div>

                    </div>

                </div>


                <div class="col-xl-3 col-md-6">

                    <div class="stat-card">

                        <div class="stat-icon icon-orange">

                            <i class="bi bi-hourglass-split"></i>

                        </div>

                        <div class="stat-title">
                            Submitted
                        </div>

                        <div class="stat-value">
                            <asp:Label
                                ID="lblSubmitted"
                                runat="server"
                                Text="0" />
                        </div>

                    </div>

                </div>


                <div class="col-xl-3 col-md-6">

                    <div class="stat-card">

                        <div class="stat-icon icon-green">

                            <i class="bi bi-check-circle"></i>

                        </div>

                        <div class="stat-title">
                            Approved
                        </div>

                        <div class="stat-value">
                            <asp:Label
                                ID="lblApproved"
                                runat="server"
                                Text="0" />
                        </div>

                    </div>

                </div>


                <div class="col-xl-3 col-md-6">

                    <div class="stat-card">

                        <div class="stat-icon icon-red">

                            <i class="bi bi-x-circle"></i>

                        </div>

                        <div class="stat-title">
                            Rejected
                        </div>

                        <div class="stat-value">
                            <asp:Label
                                ID="lblRejected"
                                runat="server"
                                Text="0" />
                        </div>

                    </div>

                </div>

            </div>


            <!-- QUICK ACTIONS -->

            <div class="section-title">
                Quick Actions
            </div>

            <div class="row g-4">

                <div class="col-md-6">

                    <div class="action-card">

                        <div class="action-icon">

                            <i class="bi bi-person-plus-fill"></i>

                        </div>

                        <h5>
                            Register Candidate
                        </h5>

                        <p>
                            Add a new candidate and enter
                            personal, education and address details.
                        </p>

                        <a href="CandidateRegistration.aspx"
                           class="btn-dashboard">

                            <i class="bi bi-plus-lg"></i>
                            New Registration

                        </a>

                    </div>

                </div>


                <div class="col-md-6">

                    <div class="action-card">

                        <div class="action-icon">

                            <i class="bi bi-list-ul"></i>

                        </div>

                        <h5>
                            Candidate List
                        </h5>

                        <p>
                            View registered candidates,
                            see details, edit records or delete candidates.
                        </p>

                        <a href="CandidateList.aspx"
                           class="btn-outline-dashboard">

                            <i class="bi bi-arrow-right"></i>
                            View Candidates

                        </a>

                    </div>

                </div>

            </div>

        </section>

    </main>

</form>

</body>

</html>
