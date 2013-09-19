<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="AspNetAjax.EmployeesAndOrders.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:ScriptManager runat="server" />

        <asp:UpdatePanel ID="UpdatePanelEmployees" runat="server">
            <ContentTemplate>
                <h2>Employees</h2>
                <asp:GridView ID="GridViewEmployees" runat="server"
                    AutoGenerateColumns="false"
                    PageSize="5" AllowPaging="true" AllowSorting="true"
                    SelectMethod="GridViewEmployees_GetData"
                    DataKeyNames="EmployeeID"
                    OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
                        <asp:BoundField HeaderText="Last Name" DataField="LastName" SortExpression="LastName" />
                        <asp:CommandField HeaderText="Action" SelectText="Orders" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanelOrders" runat="server">
            <ContentTemplate>
                <h2>Orders</h2>
                <asp:UpdateProgress runat="server">
                    <ProgressTemplate>
                        <img src="loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="GridViewOrders" runat="server"
                    AutoGenerateColumns="false"
                    PageSize="10" AllowPaging="true"
                    OnPageIndexChanging="GridViewOrders_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Order Date" DataField="OrderDate" SortExpression="OrderDate" />
                        <asp:BoundField HeaderText="Ship Name" DataField="ShipName" SortExpression="ShipName" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
