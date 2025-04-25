<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="WebApplication.StaffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Staff:</strong>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </div>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            View Books for Sale in Library</p>
        <p style="margin-left: 120px">
            <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p style="margin-left: 40px">
            Add New Books To Library for Sale</p>
        <p style="margin-left: 120px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p style="margin-left: 120px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            Remove Books from Library</p>
        <p style="margin-left: 120px">
            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
