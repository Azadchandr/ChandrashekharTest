<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChandrashekharTest.Account.Login" %>


<!DOCTYPE html>

<%--<html>
<head runat="server">

    <title>Login</title>

    <style>

        body {
            font-family: Arial;
            background: #f5f5f5;
        }

        .login-box {
            width: 400px;
            margin: 100px auto;
            padding: 30px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 0 10px #ccc;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
        }

        .btn-login {
            width: 100%;
            padding: 10px;
        }

        .message {
            color: red;
            margin-bottom: 15px;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="login-box">

        <h2>Login</h2>

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="message">
        </asp:Label>

        <asp:TextBox
            ID="txtUsername"
            runat="server"
            CssClass="form-control"
            placeholder="Username">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvUsername"
            runat="server"
            ControlToValidate="txtUsername"
            ErrorMessage="Username is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <asp:TextBox
            ID="txtPassword"
            runat="server"
            TextMode="Password"
            CssClass="form-control"
            placeholder="Password">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvPassword"
            runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="Password is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />

        <asp:Button
            ID="btnLogin"
            runat="server"
            Text="Login"
            CssClass="btn-login"
            OnClick="btnLogin_Click" />

    </div>

</form>

</body>
</html>--%>




<!DOCTYPE html>

<html>
<head runat="server">

    <title>Login - Candidate Interview System</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"  rel="stylesheet" />

</head>

<body class="bg-light">

<form id="form1" runat="server">

    <div class="container">

        <div class="row justify-content-center mt-5">

            <div class="col-md-5">

                <div class="card shadow">

                    <div class="card-header text-center bg-primary text-white">
                       <h4 class="fw-bold mb-1">Candidate Interview System</h4>
                         <small class="fw-bold text-uppercase">Login</small>
                         </div>

                    <div class="card-body">

                        <div class="mb-3">

                            <label class="form-label">
                                User Name
                            </label>

                            <asp:TextBox
                                ID="txtUserName"
                                runat="server"
                                CssClass="form-control" />

                        </div>

                        <div class="mb-3">

                            <label class="form-label">
                                Password
                            </label>

                            <asp:TextBox
                                ID="txtPassword"
                                runat="server"
                                TextMode="Password"
                                CssClass="form-control" />

                        </div>

                        <asp:Label
                            ID="lblMessage"
                            runat="server"
                            CssClass="text-danger" />

                        <div class="d-grid mt-3">

                            <asp:Button
                                ID="btnLogin"
                                runat="server"
                                Text="Login"
                                CssClass="btn btn-primary"
                                OnClick="btnLogin_Click" />

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

</form>

</body>
</html>






