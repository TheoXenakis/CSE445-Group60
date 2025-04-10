<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PublicPages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            font-weight: 700;
        }
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <p class="auto-style1">
            <em>Member Pages</em></p>
        <div style="margin-left: 80px">
            <strong>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </strong>
        </div>
        <br />
        <br />
        <span class="auto-style1"><em>Staff Page</em></span><br />
        <div style="margin-left: 80px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
