<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItDatabaseJohn.aspx.cs" Inherits="WebApplication.TryItDatabase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p style="font-style: italic;">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="TryIt Page #2"></asp:Label>
        </p>
        <p style="font-style: italic;">
            &nbsp;</p>
        <p style="margin-left: 40px; font-style: italic;">
        Create Account &amp; Login Services</p>
        <p style="margin-left: 80px">
            Create an account to be stored on the backend server &amp; be able to log into that account. </p>
        <p style="margin-left: 80px">
            CreateAccount page will redirect the user to the Login Page upon a successful account creation. </p>
        <p style="margin-left: 80px">
            Upon redirect the user&#39;s data will be entered into the LoginPage&#39;s text fields for them automatically via Cookies.</p>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 280px">
            <asp:Button ID="Button2" runat="server" Text="Create a New Account" OnClick="Button2_Click" style="font-weight: 700" />
        </p>
        <p style="margin-left: 280px">
            &nbsp;</p>
        <div style="margin-left: 280px">
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" style="font-weight: 700" Text="Log into Account" />
        </div>
    </form>
</body>
</html>
