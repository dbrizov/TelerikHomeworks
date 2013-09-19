<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCountry.aspx.cs" Inherits="EarthDb.WebFormsApp.App.DeleteCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormDeleteCountry" runat="server">
        <div runat="server">Are you sure you want to delete the country?</div>
        <asp:Button Text="Yes" runat="server" OnClick="OnBtnYes_Click"/>
        <asp:Button Text="No" runat="server" OnClick="OnBtnNo_Click"/>
    </form>
</body>
</html>
