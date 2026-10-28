<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ChandrashekharTest.Dashboard" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Super Admin Dashboard</title>

    <meta name="viewport"
        content="width=device-width, initial-scale=1" />

    <style>

        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            font-family: "Segoe UI", Arial, sans-serif;
            background: #f4f7fb;
            color: #1e293b;
        }

        /* =========================
           SIDEBAR
        ========================= */

        .sidebar {
            position: fixed;
            top: 0;
            left: 0;
            bottom: 0;
            width: 250px;
            background: #172554;
            color: #fff;
            padding: 22px 15px;
            z-index: 1000;
        }

        .logo {
            display: flex;
            align-items: center;
            padding: 8px 10px 25px;
            border-bottom: 1px solid rgba(255,255,255,.08);
            margin-bottom: 20px;
        }

        .logo-icon {
            width: 44px;
            height: 44px;
            background: #2563eb;
            border-radius: 11px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 15px;
            font-weight: 700;
            margin-right: 11px;
            box-shadow: 0 5px 15px rgba(37,99,235,.3);
        }

        .logo-text {
            font-size: 16px;
            font-weight: 700;
        }

        .logo-subtitle {
            margin-top: 3px;
            font-size: 10px;
            color: #93c5fd;
            letter-spacing: 1px;
        }

        .menu-title {
            padding: 8px 10px;
            margin-bottom: 7px;
            color: #94a3b8;
            font-size: 10px;
            font-weight: 700;
            letter-spacing: 1px;
        }

        .menu {
            display: flex;
            align-items: center;
            width: 100%;
            padding: 12px 13px;
            margin-bottom: 5px;
            border: none;
            border-radius: 9px;
            background: transparent;
            color: #cbd5e1;
            text-decoration: none;
            font-size: 14px;
            cursor: pointer;
            text-align: left;
            transition: .2s ease;
        }

        .menu:hover,
        .menu.active {
            background: #2563eb;
            color: #fff;
            box-shadow: 0 5px 14px rgba(37,99,235,.22);
        }

        .menu-icon {
            width: 30px;
            font-size: 17px;
        }

        .menu-text {
            flex: 1;
        }

        /* =========================
           LOGOUT
        ========================= */

        .logout-area {
            position: absolute;
            left: 15px;
            right: 15px;
            bottom: 20px;
        }

        .logout {
            width: 100%;
            padding: 11px;
            border: 1px solid #334155;
            border-radius: 9px;
            background: transparent;
            color: #cbd5e1;
            font-size: 13px;
            cursor: pointer;
            transition: .2s ease;
        }

        .logout:hover {
            background: #dc2626;
            border-color: #dc2626;
            color: #fff;
        }

        /* =========================
           MAIN
        ========================= */

        .main {
            margin-left: 250px;
            min-height: 100vh;
        }

        /* =========================
           TOPBAR
        ========================= */

        .topbar {
            height: 75px;
            padding: 0 20px;
            background:#e5e7eb;
            border-bottom: 1px solid #e5e7eb;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }

        .top-title {
            font-size: 21px;
            font-weight: 700;
           /* color: #0f172a;*/
          
        }

        .top-subtitle {
            margin-top: 3px;
            font-size: 12px;
            color: #64748b;
        }

        .profile {
            display: flex;
            align-items: center;
        }

        .avatar {
            width: 40px;
            height: 40px;
            margin-right: 10px;
            border-radius: 50%;
            background: #2563eb;
            color: #fff;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 13px;
            font-weight: 700;
        }

        .profile-name {
            font-size: 13px;
            font-weight: 700;
            color: #1e293b;
        }

        .profile-role {
            margin-top: 2px;
            font-size: 10px;
            color: #64748b;
        }

        /* =========================
           CONTENT
        ========================= */

        .content {
            padding: 8px 10px;
        }

        /* =========================
           WELCOME
        ========================= */

        .welcome {
            position: relative;
            overflow: hidden;
            margin-bottom: 24px;
            padding: 25px 28px;
            border-radius: 14px;
            background: linear-gradient(
                135deg,
                #1d4ed8,
                #2563eb
            );
            color: #fff;
            box-shadow: 0 8px 25px rgba(37,99,235,.15);
        }

        .welcome:after {
            content: "";
            position: absolute;
            width: 180px;
            height: 180px;
            right: -50px;
            top: -80px;
            border-radius: 50%;
            background: rgba(255,255,255,.08);
        }

        .welcome h2 {
            position: relative;
            z-index: 1;
            margin: 0;
            font-size: 23px;
            font-weight: 700;
            text-align:center;
        }

        .welcome p {
            position: relative;
            z-index: 1;
            margin: 8px 0 0;
            color: #dbeafe;
            font-size: 13px;
        }

        /* =========================
           STATISTICS
        ========================= */

        .stats {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            gap: 17px;
            margin-bottom: 24px;
        }

        .stat-card {
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 20px;
            min-height: 115px;
            background: #fff;
            border: 1px solid #e5e7eb;
            border-radius: 12px;
            transition: .2s ease;
        }

        .stat-card:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 22px rgba(15,23,42,.07);
        }

        .stat-title {
            font-size: 12px;
            color: #64748b;
            font-weight: 600;
        }

        .stat-value {
            margin-top: 6px;
            font-size: 28px;
            font-weight: 750;
            color: #0f172a;
        }

        .stat-icon {
            width: 48px;
            height: 48px;
            border-radius: 11px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 19px;
        }

        .blue {
            background: #dbeafe;
            color: #2563eb;
        }

        .orange {
            background: #ffedd5;
            color: #ea580c;
        }

        .green {
            background: #dcfce7;
            color: #16a34a;
        }

        .red {
            background: #fee2e2;
            color: #dc2626;
        }

        /* =========================
           GRID
        ========================= */

        .dashboard-grid {
            display: grid;
            grid-template-columns: 1.7fr 1fr;
            gap: 20px;
        }

        .card {
            background: #fff;
            border: 1px solid #e5e7eb;
            border-radius: 12px;
            overflow: hidden;
        }

        .card-header {
            padding: 17px 20px;
            border-bottom: 1px solid #e5e7eb;
            font-size: 15px;
            font-weight: 700;
            color: #0f172a;
        }

        .card-body {
            padding: 18px;
        }

        /* =========================
           ACTIONS
        ========================= */

        .action {
            display: flex;
            align-items: center;
            width: 100%;
            margin-bottom: 11px;
            padding: 14px;
            border: 1px solid #e5e7eb;
            border-radius: 10px;
            background: #fff;
            color: inherit;
            text-decoration: none;
            text-align: left;
            cursor: pointer;
            transition: .2s ease;
        }

        .action:last-child {
            margin-bottom: 0;
        }

        .action:hover {
            border-color: #93c5fd;
            background: #f8fbff;
            transform: translateX(2px);
        }

        .action-icon {
            width: 44px;
            height: 44px;
            flex-shrink: 0;
            margin-right: 13px;
            border-radius: 9px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 18px;
        }

        .action-content {
            flex: 1;
        }

        .action-title {
            font-size: 13px;
            font-weight: 700;
            color: #1e293b;
        }

        .action-description {
            margin-top: 4px;
            color: #64748b;
            font-size: 11px;
        }

        .arrow {
            color: #94a3b8;
            font-size: 19px;
        }

        /* =========================
           WORKFLOW
        ========================= */

        .activity {
            position: relative;
            padding: 0 0 17px 18px;
            margin-bottom: 17px;
            border-left: 2px solid #dbeafe;
        }

        .activity:last-child {
            padding-bottom: 0;
            margin-bottom: 0;
            border-left: none;
        }

        .activity:before {
            content: "";
            position: absolute;
            left: -6px;
            top: 0;
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background: #2563eb;
            border: 2px solid #dbeafe;
        }

        .activity-title {
            font-size: 12px;
            font-weight: 700;
            color: #1e293b;
        }

        .activity-text {
            margin-top: 4px;
            color: #64748b;
            font-size: 11px;
            line-height: 1.5;
        }

        /* =========================
           RESPONSIVE
        ========================= */

        @media(max-width: 1100px) {

            .stats {
                grid-template-columns: repeat(2, 1fr);
            }

            .dashboard-grid {
                grid-template-columns: 1fr;
            }
        }

        @media(max-width: 700px) {

            .sidebar {
                width: 70px;
                padding: 15px 10px;
            }

            .logo {
                justify-content: center;
                padding: 8px 0 20px;
            }

            .logo-icon {
                margin: 0;
            }

            .logo-text,
            .logo-subtitle,
            .menu-title,
            .menu-text {
                display: none;
            }

            .menu {
                justify-content: center;
                padding: 12px 5px;
            }

            .menu-icon {
                width: auto;
            }

            .logout-area {
                left: 10px;
                right: 10px;
            }

            .logout {
                font-size: 0;
            }

            .logout:first-letter {
                font-size: 16px;
            }

            .main {
                margin-left: 70px;
            }

            .topbar {
                height: auto;
                min-height: 70px;
                padding: 12px 15px;
            }

            .top-title {
                font-size: 17px;
            }

            .top-subtitle {
                font-size: 10px;
            }

            .profile-role {
                display: none;
            }

            .content {
                padding: 18px 15px;
            }

            .welcome {
                padding: 20px;
            }

            .welcome h2 {
                font-size: 19px;
            }

            .stats {
                grid-template-columns: 1fr;
            }
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <!-- ================= SIDEBAR ================= -->

    <aside class="sidebar">

        <div class="logo">

            <div class="logo-icon">
                SA
            </div>

            <div>
                <div class="logo-text">
                    Recruitment Portal
                </div>

                <div class="logo-subtitle">
                    SUPER ADMIN
                </div>
            </div>

        </div>

        <div class="menu-title">
            MAIN MENU
        </div>

        <!-- Dashboard -->

        <a href="Dashboard.aspx"
           class="menu active">

            <span class="menu-icon">⌂</span>

            <span class="menu-text">
                Dashboard
            </span>

        </a>

        <!-- Candidate Lists -->

        <asp:LinkButton
            ID="lnkScrutiny"
            runat="server"
            CssClass="menu"
            OnClick="btnScrutiny_Click">

            <span class="menu-icon">📋</span>

            <span class="menu-text">
                Candidate Lists
            </span>

        </asp:LinkButton>

        <!-- Selected -->

        <asp:LinkButton
            ID="lnkSelected"
            runat="server"
            CssClass="menu"
            OnClick="btnSelected_Click">

            <span class="menu-icon">✓</span>

            <span class="menu-text">
                Selected Candidates
            </span>

        </asp:LinkButton>

        <!-- Rejected -->

        <asp:LinkButton
            ID="lnkRejected"
            runat="server"
            CssClass="menu"
            OnClick="btnRejected_Click">

            <span class="menu-icon">✕</span>

            <span class="menu-text">
                Rejected Candidates
            </span>

        </asp:LinkButton>

        <!-- Logout -->

        <div class="logout-area">

            <asp:Button
                ID="btnLogout"
                runat="server"
                Text="↪  Logout"
                CssClass="logout"
                OnClick="btnLogout_Click" />

        </div>

    </aside>


    <!-- ================= MAIN ================= -->

    <main class="main">

        <!-- TOP BAR -->

        <header class="topbar">

            <div>

                <div class="top-title">
                    Super Admin Dashboard
                </div>

                <div class="top-subtitle">
                    Candidate Recruitment Management
                </div>

            </div>

            <div class="profile">

                <div class="avatar">
                    SA
                </div>

                <div>

                    <div class="profile-name">

                        <asp:Label
                            ID="lblUserName"
                            runat="server"
                            Text="Super Admin">
                        </asp:Label>

                    </div>

                    <div class="profile-role">
                        Super Administrator
                    </div>

                </div>

            </div>

        </header>


        <!-- ================= CONTENT ================= -->

        <section class="content">

            <!-- WELCOME -->

            <div class="welcome">

                <h2>

                    Welcome To
                    <asp:Label
                        ID="lblWelcome"
                        runat="server"
                        Text="Super Admin">
                    </asp:Label>
                    </h2>
            </div>


            <!-- ================= STATISTICS ================= -->

            <div class="stats">

                <!-- TOTAL -->

                <div class="stat-card">

                    <div>

                        <div class="stat-title">
                            Total Candidates
                        </div>

                        <div class="stat-value">

                            <asp:Label
                                ID="lblTotalCandidates"
                                runat="server"
                                Text="0">
                            </asp:Label>

                        </div>

                    </div>

                    <div class="stat-icon blue">
                        👥
                    </div>

                </div>


                <!-- PENDING -->

                <asp:LinkButton
                    ID="btnPendingCandidates"
                    runat="server"
                    CssClass="stat-card"
                    OnClick="btnScrutiny_Click"
                    Style="text-decoration:none; color:inherit;">

                    <div>

                        <div class="stat-title">
                            Pending Scrutiny
                        </div>

                        <div class="stat-value">

                            <asp:Label
                                ID="lblPending"
                                runat="server"
                                Text="0">
                            </asp:Label>

                        </div>

                    </div>

                    <div class="stat-icon orange">
                        ⏳
                    </div>

                </asp:LinkButton>


                <!-- SELECTED -->

                <asp:LinkButton
                    ID="btnSelectedStat"
                    runat="server"
                    CssClass="stat-card"
                    OnClick="btnSelected_Click"
                    Style="text-decoration:none; color:inherit;">

                    <div>
                        <div class="stat-title">
                            Selected Candidates
                        </div>

                        <div class="stat-value">

                            <asp:Label
                                ID="lblSelected"
                                runat="server"
                                Text="0">
                            </asp:Label>

                        </div>

                    </div>

                    <div class="stat-icon green">
                        ✓
                    </div>

                </asp:LinkButton>


                <!-- REJECTED -->

                <asp:LinkButton
                    ID="btnRejectedStat"
                    runat="server"
                    CssClass="stat-card"
                    OnClick="btnRejected_Click"
                    Style="text-decoration:none; color:inherit;">

                    <div>

                        <div class="stat-title">
                            Rejected Candidates
                        </div>

                        <div class="stat-value">

                            <asp:Label
                                ID="lblRejected"
                                runat="server"
                                Text="0">
                            </asp:Label>

                        </div>

                    </div>

                    <div class="stat-icon red">
                        ✕
                    </div>

                </asp:LinkButton>

            </div>


            <!-- ================= LOWER GRID ================= -->

            <div class="dashboard-grid">

                <!-- QUICK ACTIONS -->

                <div class="card">

                    <div class="card-header">
                        Quick Actions
                    </div>

                    <div class="card-body">

                        <!-- SCRUTINY -->

                        <asp:LinkButton
                            ID="btnScrutiny"
                            runat="server"
                            CssClass="action"
                            OnClick="btnScrutiny_Click">

                            <div class="action-icon blue">
                                📋
                            </div>

                            <div class="action-content">

                                <div class="action-title">
                                    Candidate List
                                </div>

                                <div class="action-description">
                                    Review candidate applications
                                    submitted by Admin.
                                </div>

                            </div>

                            <div class="arrow">
                                →
                            </div>

                        </asp:LinkButton>


                        <!-- SELECTED -->

                        <asp:LinkButton
                            ID="btnSelectedCandidates"
                            runat="server"
                            CssClass="action"
                            OnClick="btnSelected_Click">

                            <div class="action-icon green">
                                ✓
                            </div>

                            <div class="action-content">

                                <div class="action-title">
                                    Selected Candidates
                                </div>

                                <div class="action-description">
                                    View approved candidates
                                    and interview status.
                                </div>

                            </div>

                            <div class="arrow">
                                →
                            </div>

                        </asp:LinkButton>


                        <!-- REJECTED -->

                        <asp:LinkButton
                            ID="btnRejectedCandidates"
                            runat="server"
                            CssClass="action"
                            OnClick="btnRejected_Click">

                            <div class="action-icon red">
                                ✕
                            </div>

                            <div class="action-content">

                                <div class="action-title">
                                    Rejected Candidates
                                </div>

                                <div class="action-description">
                                    View rejected candidates
                                    and rejection reasons.
                                </div>

                            </div>

                            <div class="arrow">
                                →
                            </div>

                        </asp:LinkButton>

                    </div>

                </div>


                <!-- WORKFLOW -->

                <div class="card">

                    <div class="card-header">
                        Recruitment Workflow
                    </div>

                    <div class="card-body">

                        <div class="activity">

                            <div class="activity-title">
                                01. Candidate Submitted
                            </div>

                            <div class="activity-text">
                                Admin registers candidate
                                information.
                            </div>

                        </div>

                        <div class="activity">

                            <div class="activity-title">
                                02. Candidate List
                            </div>

                            <div class="activity-text">
                                Super Admin verifies
                                candidate details.
                            </div>

                        </div>

                        <div class="activity">

                            <div class="activity-title">
                                03. Approve / Reject
                            </div>

                            <div class="activity-text">
                                Eligible candidates are
                                selected or rejected.
                            </div>

                        </div>

                        <div class="activity">

                            <div class="activity-title">
                                04. Interview Message
                            </div>

                            <div class="activity-text">
                                Selected candidates receive
                                interview notification.
                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </section>

    </main>

</form>

</body>

</html>




