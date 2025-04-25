<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="WebApplication.MemberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Member:</strong>
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </div>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            View Books for Sale in Library</p>
        <p style="margin-left: 80px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Books For Sale" />
        </p>
        <p>
            &nbsp;</p>
        <p style="margin-left: 40px">
            View Purchased Books</p>
        <p style="margin-left: 80px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Purchased Books" />
        </p>
        <p style="margin-left: 80px">
            &nbsp;</p>
    </form>
</body>
</html>
