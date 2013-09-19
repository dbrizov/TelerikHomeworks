<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02. RandomNumberServerControls.aspx.cs" Inherits="AspNetWebAndHtmlControls._02_RandomNumberServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <asp:Label Text="From:" runat="server" />
        <asp:TextBox id="FromRange" type="text" Text="0" runat="server" />

        <asp:Label Text="To" runat="server" />
        <asp:TextBox id="ToRange" type="text" Text="0" runat="server" />

        <asp:TextBox id="RandomNumberContainer" type="text" runat="server" />

        <asp:Button type="button"
            runat="server" Text="Generate"
            OnClick="BtnGenerateRandomNumber_Click" />
    </form>
</body>
</html>
