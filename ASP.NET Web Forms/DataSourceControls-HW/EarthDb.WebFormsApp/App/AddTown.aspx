<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTown.aspx.cs" Inherits="EarthDb.WebFormsApp.App.AddTown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormAddTown" runat="server">
        <h1>Add Town</h1>

        <span>Name:</span>
        <asp:TextBox ID="TextBoxTownName" runat="server" MaxLength="20"></asp:TextBox>
        <br />

        <span>Population:</span>
        <asp:TextBox ID="TextBoxTownPopulation" runat="server" MaxLength="20"></asp:TextBox>
        <br />

        <span>Country:</span>
        <asp:DropDownList ID="DropDownListCountries" runat="server"
            DataTextField="Name"
            DataValueField="CountryId"
            AutoPostBack="False">
        </asp:DropDownList>

        <asp:Button Text="Add" runat="server" OnClick="OnBtnAddTown_Click" />
    </form>
</body>
</html>
