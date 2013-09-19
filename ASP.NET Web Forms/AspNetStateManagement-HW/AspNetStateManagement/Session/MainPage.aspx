<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="MainPage.aspx.cs"
    Inherits="AspNetStateManagement.Session.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:Label id="LabelContainer" Text="" runat="server" />
        <br />
        <asp:TextBox id="TextBoxInput" runat="server" />
        <asp:Button Text="Click" runat="server" OnClick="OnBtnAddText_Click" />
    </form>
</body>
</html>
