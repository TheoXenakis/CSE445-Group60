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
                &nbsp;&nbsp;
                Log into your account</p>
        </div>
        <p style="margin-left: 160px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            Username:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 160px">
            <asp:Label ID="Label2" runat="server" style="font-weight: 700"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            Password:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 160px">
            <asp:Label ID="Label3" runat="server" style="font-weight: 700"></asp:Label>
        </p>
        <p style="margin-left: 160px">
            &nbsp;<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" style="font-weight: 700" />
        </p>
        <p>
            &nbsp;</p>
        <p style="margin-left: 80px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Don&#39;t have an account? </p>
        <p style="margin-left: 120px">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create an Account</asp:LinkButton>
        </p>
    </form>
</body>
</html>
