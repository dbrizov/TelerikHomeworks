<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="GreetingWebForm.aspx.cs" 
    Inherits="HelloName.GreetBot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Name:" runat="server" />
        <asp:TextBox ID="TextBoxName" runat="server" />
        <br />
        <asp:Button OnClick="ButtonHelloName_Click" Text="Click Me" runat="server" />
    </form>
</body>
</html>
