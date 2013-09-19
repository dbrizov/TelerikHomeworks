<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="NumberSumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        First number:
        <asp:TextBox ID="TextBoxFirstNum" runat="server" />
        <br />
        Second number:
        <asp:TextBox ID="TextBoxSecondNum" runat="server" />
        <br />
        <asp:Button ID="BtnCalculateSum" OnClick="ButtonCalculateSum_Click" Text="Calculate Sum" runat="server" />
        <br />
        Result:
        <asp:TextBox ID="TextBoxtResult" ReadOnly="true" runat="server" />
    </form>
</body>
</html>
