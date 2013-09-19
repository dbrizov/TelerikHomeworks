<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="NorthwindEmployees.GridView.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormGridView" runat="server">
        <div>
            <asp:GridView ID="EmployeesGrid" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}" DataTextField="FullName" HeaderText="Full Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
