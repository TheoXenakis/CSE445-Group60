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

                	<style>
		        table {
			        border:1px solid #b3adad;
			        border-collapse:collapse;
			        padding:5px;
		        }
		        table th {
			        border:1px solid #b3adad;
			        padding:5px;
			        background: #f0f0f0;
			        color: #313030;
		        }
		        table td {
			        border:1px solid #b3adad;
			        text-align:center;
			        padding:5px;
			        background: #ffffff;
			        color: #313030;
		        }
	        </style>
        </head>

        <h2>Service Directory</h2>

	    <table>
		    <thead>
			    <tr>
                    <th>Service provider name</th>
				    <th>Service name, with input and output types</th>
				    <th>Try It Page</th>
				    <th>Sercice description</th>
				    <th>Planned resources need to implement the service</th>
			    </tr>
		    </thead>
		    <tbody>
			    <tr>
                    <td>Roen Wainscoat</td>
                    <td>TODO</td>
				    <td>TotalAndTaxSvc <br /> calculateTotal(ArrayList prices) : float <br /> calculateTax(float subtotal, float taxRate) : float</td>
				    <td>This service is used in the cart/checkout process of the website where the total (addition of all the product prices) and total with tax are calculated by calling the calculateTotal and calculateTax methods respectively.</td>
				    <td>Will need to implement a rudimentary WCF service with the basic methods described previously. calculateTotal will include a loop/iterator which iterates through the products and adds the total.</td>
			    </tr>
		    </tbody>
		    <tbody>
			    <tr>
                    <td>John Bostater</td>
                    <td>DataBase Services</td>
				    <td>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">TryItPage Link</asp:LinkButton>
                    </td>
				    <td>This service is used for creating staff and member accounts as well as being able to sign into those respective accounts.</td>
				    <td>Need to have a WCF service, with the functions able to be called between the WebApplication and this backend service.</td>
			    </tr>
		    </tbody>
	    </table>

		<p style="margin-left: 40px">
            &nbsp;</p>

    </form>
</body>
</html>
