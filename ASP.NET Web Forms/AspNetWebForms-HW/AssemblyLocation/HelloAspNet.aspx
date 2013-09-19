<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="HelloAspNet.aspx.cs" 
    Inherits="AssemblyLocation.CodeBehind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%
            Response.Write("Hello ASP.NET - from Aspx\r\n");
        %>
    </form>
</body>
</html>
