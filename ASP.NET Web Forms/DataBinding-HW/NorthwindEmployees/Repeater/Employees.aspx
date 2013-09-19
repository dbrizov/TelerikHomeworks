<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployees.Repeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        p {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater id="RepeaterEmployees" runat="server" ItemType="NorthwindEmployees.Repeater.EmployeeModel">
            <ItemTemplate>
                <p>
                    <strong><%#: string.Format("{0} {1}", Item.FirstName, Item.LastName) %></strong>
                    <br />
                    <strong>Job Title: </strong><span><%#: Item.Title %></span>
                    <br />
                    <strong>City: </strong><span><%#: Item.City %></span>
                    <br />
                    <strong>Address: </strong><span><%#: Item.Address %></span>
                    <br />
                    <strong>Notes: </strong><span><%#: Item.Notes %></span>
                </p>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
