<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 80px">
            <p style="margin-left: 40px">
                Login Template</p>
        </div>
        <p style="margin-left: 120px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            Username</p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            Password</p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 120px">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Don&#39;t have an account? Create one here</p>
        <p style="margin-left: 80px">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create an Account</asp:LinkButton>
        </p>
    </form>
</body>
</html>
