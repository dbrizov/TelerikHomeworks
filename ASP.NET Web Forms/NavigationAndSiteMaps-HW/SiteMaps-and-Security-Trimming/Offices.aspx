<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Offices.aspx.cs" 
    Inherits="SiteMap_and_Navigation.Offices" %>


<asp:Content ID="ContentOffices" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Offices</h1>
    <div>
        <ul>
            <li>
                <asp:HyperLink Text="Bulgaria" NavigateUrl="~/Bulgaria.aspx" runat="server" />
            </li>
            <li>
                <asp:HyperLink Text="United Kingdom" NavigateUrl="~/UnitedKingdom.aspx" runat="server" />
            </li>
        </ul>
    </div>
</asp:Content>
