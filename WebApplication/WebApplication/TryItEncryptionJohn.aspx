<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItEncryptionJohn.aspx.cs" Inherits="WebApplication.TryItEncryptionJohn" %>

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
        Encryption Decryption Services</p>
        <p style="margin-left: 80px">
            Encrypt &amp; Decrypt Text</p>
        <p style="margin-left: 80px">
            [Used for Password Storage on backend server]</p>
        <p style="margin-left: 120px">
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
        <p style="margin-left: 120px">
            <asp:Button ID="Button1" runat="server" Text="Encrypt" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Decrypt" OnClick="Button3_Click" />
        </p>
    <p>
        &nbsp;</p>
        <p>
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
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
