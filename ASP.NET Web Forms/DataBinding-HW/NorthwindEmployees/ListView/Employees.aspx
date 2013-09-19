<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployees.ListView.Employees" %>

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
        <div>
            <asp:ListView ID="ListViewEmployees" runat="server" ItemType="NorthwindEmployees.Repeater.EmployeeModel">
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
            </asp:ListView>

            <asp:DataPager ID="DataPagerCustomers" runat="server"
                PagedControlID="ListViewEmployees" PageSize="3"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </form>
</body>
</html>
