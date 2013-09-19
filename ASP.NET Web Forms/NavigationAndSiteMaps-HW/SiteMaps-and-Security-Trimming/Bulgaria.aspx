<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Bulgaria.aspx.cs" Inherits="SiteMap_and_Navigation.Bulgaria" %>

<asp:Content ID="ContentBulgarianOffice" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bulgarian office</h1>
    <div>
        <h2>Town offices</h2>
        <ul>
            <li>
                <asp:HyperLink Text="Sofia" NavigateUrl="Sofia.aspx" runat="server" />
            </li>
            <li>
                <asp:HyperLink Text="Varna" NavigateUrl="Varna.aspx" runat="server" />
            </li>
            <li>
                <asp:HyperLink Text="Plovdiv" NavigateUrl="Plovdiv.aspx" runat="server" />
            </li>
        </ul>
    </div>
</asp:Content>
