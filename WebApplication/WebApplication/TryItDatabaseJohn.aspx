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
            Create an account to be stored on the backend server &amp; be able to log into that account.</p>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 120px">
            Input </p>
        <p style="margin-left: 120px">
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 120px">
            &nbsp;</p>
        <p style="margin-left: 120px">
            Output</p>
        <p style="margin-left: 120px">
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 200px">
            <asp:Button ID="Button2" runat="server" Text="Test" />
        </p>
    </form>
</body>
</html>
