<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApplication.CreateAccount" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
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
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: inline-block;
            width: 160px;
            font-weight: bold;
            margin-right: 10px;
        }
        .form-control {
            padding: 8px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            width: 200px;
        }
        .button {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .button_blue {
            background-color: #3399ff;
        }
        .radio-list {
            margin: 15px 0;
            padding-left: 160px;
        }
        .notification {
            color: red;
            margin: 10px 0;
            padding: 10px;
            border-radius: 4px;
        }
        .captcha-image {
            border: 1px solid #ddd;
            padding: 10px;
            margin: 20px 0;
            max-width: 300px;
        }
        .caption {
            color: #666;
            font-size: 0.9em;
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Create an Account</h1>
        </div>

        <div class="form-section">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="notification"></asp:Label>
            </div>

            <div class="form-group">
                <label for="TextBox1">Username:</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TextBox2">Password:</label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control" MaxLength="16"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TextBox3">Confirm Password:</label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="form-control" MaxLength="16"></asp:TextBox>
            </div>

            <div class="caption">
                *16 character max for username & password
            </div>

            <div class="form-group">
                <h3>Select Account Type</h3>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio-list">
                    <asp:ListItem>Member</asp:ListItem>
                    <asp:ListItem>Staff</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="Label6" runat="server" CssClass="notification"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Image ID="capImage" runat="server" CssClass="captcha-image" />
            </div>

            <div class="form-group">
                <label for="capTextBox">Enter Captcha:</label>
                <asp:TextBox ID="capTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group" style="text-align: center; margin-top: 30px;">
                <asp:Button ID="Button1" runat="server" Text="Create Account" 
                    OnClick="Button1_Click" CssClass="button button_blue" />
            </div>
        </div>
    </form>
</body>
</html>