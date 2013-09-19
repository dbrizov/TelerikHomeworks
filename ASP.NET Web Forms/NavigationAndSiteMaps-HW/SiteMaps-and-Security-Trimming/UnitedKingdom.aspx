<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="UnitedKingdom.aspx.cs" Inherits="SiteMap_and_Navigation.UnitedKingdom" %>

<asp:Content ID="ContentUnitedKingdomOffice" ContentPlaceHolderID="MainContent" runat="server">
    <h1>UK office</h1>
    <div>
        <h2>Town offices</h2>
        <ul>
            <li>
                <asp:HyperLink Text="London" NavigateUrl="London.aspx" runat="server" />
            </li>
            <li>
                <asp:HyperLink Text="Bristol" NavigateUrl="Bristol.aspx" runat="server" />
            </li>
            <li>
                <asp:HyperLink Text="Manchester" NavigateUrl="Manchester.aspx" runat="server" />
            </li>
        </ul>
    </div>
</asp:Content>
