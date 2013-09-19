<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03. HtmlEscaping.aspx.cs" Inherits="AspNetWebAndHtmlControls._03_HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="MainForm" runat="server">
        Input: 
        <asp:TextBox id="TextBoxInput" runat="server" />
        <br />
        Output(textbox):
        <asp:TextBox id="TextBoxOutput" runat="server" />
        <br />
        Output(label):
        <asp:Label id="LabelOutput" Text="label" runat="server" />
        <br />
        <asp:Button onclick="BtnOutput_Click" Text="OK" runat="server" />
    </form>
</body>
</html>
