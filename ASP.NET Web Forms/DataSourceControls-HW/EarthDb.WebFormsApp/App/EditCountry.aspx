<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCountry.aspx.cs" Inherits="EarthDb.WebFormsApp.App.EditCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormEditCountry" runat="server">
        <h1>Edit Country</h1>
        <asp:Label Text="Name:" runat="server" />
        <asp:TextBox id="TextBoxCountryName" runat="server" MaxLength="20"/>
        <br />
        <asp:Label Text="Language" runat="server" />
        <asp:TextBox id="TextBoxCountryLanguage" runat="server" MaxLength="20" />
        <br />
        <asp:Label Text="Population" runat="server" />
        <asp:TextBox id="TextBoxCountryPopulation" runat="server" MaxLength="20" />
        <br />
        <asp:Button Text="Edit" runat="server" OnClick="OnBtnEditCountry_Click" />
    </form>
</body>
</html>
