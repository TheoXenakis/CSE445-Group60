<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Navigation"></asp:Label>
        </div>
        <p style="font-style: italic">
            &nbsp;</p>
        <p style="font-style: italic">
            Member Page</p>
        <p style="font-style: italic; margin-left: 80px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go To" style="font-weight: 700" />
        </p>
        <p style="font-style: italic">
            &nbsp;</p>
        <p style="font-style: italic">
            Staff Page</p>
        <p style="font-style: italic; margin-left: 80px; font-weight: 700;">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Go To" style="font-weight: 700" />
        </p>
        <div>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Service Directory"></asp:Label>
        </div>
        <p>
            Provider Name: ex. Theo Xenakis
        </p>
        <p>
            Component Type: (WSDL service, RESTful service, DLL function, user control)
        </p>
        <p>
            Operation/Service Name:
        </p>
        <p>
            Parameters and Types: 
        </p>
        <p>
            Return Type: 
        </p>
        <p>
            Description: 
        </p>
        <p>
            TryIt Page Link:
        </p>

    </form>
</body>
</html>
