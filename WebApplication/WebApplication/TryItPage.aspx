<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItPage.aspx.cs" Inherits="WebApplication.TryItPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="TryIt Page"></asp:Label>
        </div>
    <p>
        &nbsp;</p>
    <p>
        John Bostater</p>
    <p style="margin-left: 40px; font-style: italic;">
        Debug!</p>
        <p style="margin-left: 80px">
            Service Description</p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 120px">
            Input </p>
        <p style="margin-left: 120px">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 120px">
            &nbsp;</p>
        <p style="margin-left: 120px">
            Output</p>
        <p style="margin-left: 120px">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 200px">
            <asp:Button ID="Button1" runat="server" Text="Test" />
        </p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        Theo Xenakis
    </p>
    <p style="margin-left: 40px">
        //List &amp; implement services you have developed here</p>
    <p>
        &nbsp;</p>
    <p>
        Roen Wainscoat</p>
    <p style="margin-left: 40px">
        //List &amp; implement services you have developed here</p>
    <p>
        &nbsp;</p>
</body>
</html>
