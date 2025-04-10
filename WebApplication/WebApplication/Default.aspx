<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        //Name of WebApp here<br />
        <br />
        <br />
        <br />
        <strong>Member Page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <p style="margin-left: 40px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
&nbsp;&nbsp;&nbsp;
        </p>
        <strong>Staff Page<br />
        </strong>
        <div style="margin-left: 40px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        </div>
    </form>
</body>
</html>
