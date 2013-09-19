<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="MainPage.aspx.cs" Inherits="MobileBg.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MobileBG</title>
</head>
<body>
    <form id="FormMain" runat="server">
        
        <div>Brand: </div>
        <asp:DropDownList id="DropDownBrands" runat="server"
            OnSelectedIndexChanged="OnBindModels"
            DataTextField="Name" DataValueField="Id" AutoPostBack="true">
        </asp:DropDownList>

        <div>Model: </div>
        <asp:DropDownList ID="DropDownModels" runat="server"
            DataTextField="Name" DataValueField="Name" AutoPostBack="true">
        </asp:DropDownList>

        <div>Extras: </div>
        <asp:CheckBoxList id="CheckBoxListExtras" runat="server"
            DataTextField="Name" DataValueField="Name" AutoPostBack="true">
        </asp:CheckBoxList>

        <asp:Button OnClick="BtnSearchCars_Click" Text="Search" runat="server" />

        <asp:Label  ID="LabelChoise" Text="" runat="server" />
    </form>
</body>
</html>
