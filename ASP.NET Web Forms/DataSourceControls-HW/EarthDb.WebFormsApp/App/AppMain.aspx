<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AppMain.aspx.cs"
    Inherits="EarthDb.WebFormsApp.App.AppMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
            ConnectionString="name=EarthDbEntities"
            DefaultContainerName="EarthDbEntities"
            EnableFlattening="False"
            EntitySetName="Continents">
        </asp:EntityDataSource>

        <asp:Panel runat="server">Continents</asp:Panel>
        <asp:ListBox ID="ListBoxContinents" runat="server"
            AutoPostBack="True"
            DataSourceID="EntityDataSourceContinents"
            DataTextField="Name"
            DataValueField="ContinentId"
            Rows="7"></asp:ListBox>

        <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
            ConnectionString="name=EarthDbEntities"
            DefaultContainerName="EarthDbEntities"
            EnableFlattening="False" EnableDelete="true"
            EntitySetName="Countries"
            Include="Continent"
            Where="it.ContinentId=@ContId">
            <WhereParameters>
                <asp:ControlParameter Name="ContId" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:Panel runat="server">Countries</asp:Panel>
        <asp:GridView ID="GridViewCountries" runat="server"
            AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False"
            DataKeyNames="CountryId"
            DataSourceID="EntityDataSourceCountries">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Continent.Name" HeaderText="Continent" SortExpression="Continent.Name" />
                <asp:HyperLinkField Text="Add"
                    DataNavigateUrlFields="ContinentId" DataNavigateUrlFormatString="AddCountry.aspx?continentId={0}" />
                <asp:HyperLinkField Text="Edit"
                    DataNavigateUrlFields="CountryId" DataNavigateUrlFormatString="EditCountry.aspx?countryId={0}" />
                <asp:HyperLinkField Text="Delete"
                    DataNavigateUrlFields="CountryId" DataNavigateUrlFormatString="DeleteCountry.aspx?countryId={0}" />
            </Columns>
        </asp:GridView>

        <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
            ConnectionString="name=EarthDbEntities"
            DefaultContainerName="EarthDbEntities"
            EnableFlattening="False"
            EnableDelete="true" EnableUpdate="true"
            EntitySetName="Towns"
            Include="Country"
            Where="it.CountryId=@CountryIdentificator">
            <WhereParameters>
                <asp:ControlParameter Name="CountryIdentificator" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:Panel runat="server">Towns</asp:Panel>
        <asp:ListView ID="ListViewTowns" runat="server" 
            DataKeyNames="TownId" 
            DataSourceID="EntityDataSourceTowns">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">Name</th>
                                    <th runat="server">Population</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:HyperLink Text="Add Town" NavigateUrl="AddTown.aspx" runat="server" />
    </form>
</body>
</html>
