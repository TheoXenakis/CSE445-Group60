<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApplication.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 120px">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Create an Account"></asp:Label>
        </div>
        <p style="margin-left: 160px">
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            Enter a Username:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            Enter a Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            Confirm Password:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <div style="margin-left: 160px">
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" style="height: 26px" Text="Submit" />
        </div>
    </form>
</body>
</html>
