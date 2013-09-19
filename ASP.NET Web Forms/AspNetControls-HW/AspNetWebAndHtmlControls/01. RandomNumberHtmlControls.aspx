<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="01. RandomNumberHtmlControls.aspx.cs" Inherits="AspNetWebAndHtmlControls.RandomNumberHtmlControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <label for="FromRange" runat="server">From:</label>
        <input id="FromRange" type="text" runat="server" />

        <label for="ToRange" runat="server">To:</label>
        <input id="ToRange" type="text" runat="server" />

        <input id="RandomNumberContainer" type="text" runat="server" />

        <input id="ButtonGenerator" type="button"
            runat="server" value="Generate"
            onserverclick="BtnGenerateRandomNumber_Click" />
    </form>
</body>
</html>
