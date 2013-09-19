<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployees.FormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form View</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="FormMain" runat="server">
        <div>
            <asp:FormView ID="EmployeesFormView" runat="server" AllowPaging="true" ItemType="NorthwindEmployees.FormView.EmployeeModel" OnPageIndexChanging="EmployeesFormView_PageIndexChanging">
                <ItemTemplate>
                    <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
                    <table>
                        <tr>
                            <td>Job Title:</td>
                            <td><%#: Item.Title %></td>
                        </tr>
                        <tr>
                            <td>City</td>
                            <td><%#: Item.City %></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td><%#: Item.Address %></td>
                        </tr>
                        <tr>
                            <td>Notes</td>
                            <td><%#: Item.Notes %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
