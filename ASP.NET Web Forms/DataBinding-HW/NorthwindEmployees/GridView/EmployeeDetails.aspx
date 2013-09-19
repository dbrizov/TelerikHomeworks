<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="NorthwindEmployees.GridView.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EmployeeDetails" runat="server">
        <div>
            <asp:DetailsView ID="EmployeeDetailsView" runat="server" AutoGenerateRows="true">
            </asp:DetailsView>
            <asp:HyperLink NavigateUrl="~/GridView/GridView.aspx" Text="Back to Employees" runat="server"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
