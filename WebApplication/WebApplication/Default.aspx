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

        <br />
        <br />

        <p>
            <u>Application Description:</u> This will be a simple E-Commerce website for a bookstore. Users will be able to register, login, and add books to their cart and checkout to place an order.
        </p>

		<br />

		<p>
			Percentage of overall contribution: <br />
				Roen Wainscoat: 33.33333% <br />
				Theo Xenakis: 33.33333% <br />
				John Bostater: 33.33333% <br />
		</p>

		<style>
			table {
				border:1px solid #000000;
				border-collapse:collapse;
				padding:5px;
			}
			table th {
				border:1px solid #000000;
				padding:5px;
				background: #f0f0f0;
				color: #313030;
			}
			table td {
				border:1px solid #000000;
				text-align:center;
				padding:5px;
				background: #ffffff;
				color: #313030;
			}
		</style>

		<div>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Service Directory"></asp:Label>
        </div>

		<table>
			<thead>
				<tr>
					<th>Provider Name</th>
					<th>Page and component type, e.g. aspx, DLL, SVC, etc.</th>
					<th>Component Description: what does the component do? What are the inputs/parameters and output/return value?</th>
					<th>Actual resources and methods used to implement the component and where this component is used.</th>
					<th>Try It</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Roen Wainscoat</td>
					<td>Cookies</td>
					<td>Uses getUserType() in DatabaseServices to fetch user type and stores it in cookie to redirect user to proper page upon login .</td>
					<td>Modified DatabaseServices to implement getUserType(str) method; modified LoginPage C# code to set user cookie.</td>
					<td><a href="LoginPage.aspx">LoginPage.aspx</a></td>
				</tr>
				<tr>
					<td>Roen Wainscoat</td>
					<td>User Control</td>
					<td>The component now shows a CAPTCHA that must be solved properly to use the create account function. It displays a CAPTCHA image on the page and asks for the text and verifies the text input upon form submission.</td>
					<td>Modified the CreateAccount C# code and CreateAccount ASPX (GUI) code to implement the image and text box for the challenge.</td>
					<td><a href="CreateAccount.aspx">CreateAccount.aspx</a></td>
				</tr>
				<tr>
					<td>Roen Wainscoat</td>
					<td></td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>TODO</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</tbody>
		</table>
        <p style="font-style: italic; font-weight: 700;">
            &nbsp;</p>
        <div>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Services Directory"></asp:Label>
        </div>
        <p>
            &nbsp;</p>
        <p style="margin-left: 40px">
            Provider Name: ex. Theo Xenakis
        </p>
        <p style="margin-left: 40px">
            Component Type: (WSDL service, RESTful service, DLL function, user control)
        </p>
        <p style="margin-left: 40px">
            Operation/Service Name:
        </p>
        <p style="margin-left: 40px">
            Parameters and Types: 
        </p>
        <p style="margin-left: 40px">
            Return Type: 
        </p>
        <p style="margin-left: 40px">
            Description: 
        </p>
        <p style="margin-left: 40px">
            TryIt Page Link:
        </p>

        <p>
            &nbsp;</p>
        <p style="margin-left: 40px">
            <strong>[Provider Name]:</strong> John Bostater</p>
        <p style="margin-left: 40px">
            <strong>[Component Type]:</strong> DLL function</p>
        <p style="margin-left: 40px">
            <strong>[Operation/Service Name]: </strong>ServiceReference1</p>
        <p style="margin-left: 40px">
            <strong>[Parameters and Types]:</strong> String : userData</p>
        <p style="margin-left: 40px">
            <strong>[Return Type]:</strong> String : encryptedData&nbsp; or String : decryptedData</p>
        <p style="margin-left: 40px">
            <strong>[Description]:</strong> Encryption &amp; Decryption functions, used for storing sensitive data. This is an externally called upon service via: venus</p>
        <p style="margin-left: 120px">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">TryItPage Link</asp:LinkButton>
        </p>

        <p style="margin-left: 120px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            <strong>[Provider Name]:</strong> John Bostater</p>
        <p style="margin-left: 40px">
            <strong>[Component Type]:</strong> Cookies</p>
        <p style="margin-left: 40px">
            <strong>[Operation/Service Name]:</strong> DatabaseServices / ServiceReference2</p>
        <p style="margin-left: 40px">
            <strong>[Parameters and Types]:</strong> String : userName&nbsp; String : password&nbsp;&nbsp; String: accountType</p>
        <p style="margin-left: 40px">
            <strong>[Return Type]:</strong> bool : successfulOperation</p>
        <p style="margin-left: 40px">
            <strong>[Description]:</strong> Create an Account &amp; Log into account functionality for getting and setting user data.</p>
        <p style="margin-left: 120px">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">TryItPage Link</asp:LinkButton>
        </p>

    </form>
</body>
</html>
