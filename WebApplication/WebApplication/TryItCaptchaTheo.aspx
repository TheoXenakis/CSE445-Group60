<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItCaptchaTheo.aspx.cs" Inherits="WebApplication.TryItCaptchaTheo" %>

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
        Theo Xenakis
    <p style="margin-left: 40px">
        Image Verification Service
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Enter length (default: 5)"></asp:TextBox>
            <asp:Button ID="genImageButton" runat="server" Text="Generate CAPTCHA" OnClick="gen_Image_Click" />
        <br />
            <asp:Image ID="Image1" runat="server" Visible="false" Style="border: 1px solid #ddd; margin-top: 10px; max-width: 300px;" />
        <br />
            <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>  
        <br />
        <label>What appears in the Image:</label>
            <asp:TextBox ID="answerBox" runat="server" Width="200px"></asp:TextBox>
            <asp:Button ID="captchaSubmitButton" runat="server" Text="Submit" OnClick="subCaptchaGuess"/>
        <br />
        <label>Captcha Result: </label>
        <asp:TextBox ID="captchaResult" runat="server" Visible="false" ReadOnly="true" Width="500px"></asp:TextBox>
</p>
        &nbsp;</p>

    </form>
</body>
</html>
