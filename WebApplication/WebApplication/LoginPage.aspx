<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication.LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            margin: 20px;
            background-color: #f8f9fa;
        }
        .header {
            background-color: #3D7169;
            color: white;
            padding: 20px;
            margin-bottom: 30px;
            border-radius: 5px;
            text-align: center;
        }
        .form-section {
            max-width: 400px;
            margin: 0 auto;
            padding: 30px;
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .form-group {
            margin-bottom: 20px;
        }
        label {
            display: block;
            font-weight: bold;
            margin-bottom: 8px;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .button {
            width: 100%;
            padding: 12px;
            background-color: #3399ff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .link-button {
            display: block;
            text-align: center;
            margin-top: 20px;
            color: #3399ff;
            text-decoration: none;
        }
        .notification {
            color: red;
            text-align: center;
            margin: 15px 0;
            padding: 10px;
            border-radius: 4px;
        }
        .footer-text {
            text-align: center;
            margin-top: 25px;
            color: #666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Welcome Back</h1>
            <p>Please log in to continue</p>
        </div>

        <div class="form-section">
            <asp:Label ID="Label1" runat="server" CssClass="notification"></asp:Label>
            
            <div class="form-group">
                <label for="TextBox1">Username</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" CssClass="notification"></asp:Label>
            </div>

            <div class="form-group">
                <label for="TextBox2">Password</label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" CssClass="notification"></asp:Label>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Sign In" 
                OnClick="Button1_Click" CssClass="button" />

            <div class="footer-text">
                Don't have an account?<br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" 
                    CssClass="link-button">Create New Account</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>