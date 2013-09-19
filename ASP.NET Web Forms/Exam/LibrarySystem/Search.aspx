<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Search.aspx.cs"
    Inherits="LibrarySystem.Search" %>

<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LabelSearchQueryHeader" runat="server"></asp:Label>
    </h1>

    <asp:ListView ID="ListViewBooks" runat="server"
        ItemType="LibrarySystem.Models.Book">
        <LayoutTemplate>
            <ul id="itemPlaceholder" runat="server"></ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="lead">
                <asp:HyperLink runat="server" Text='<%#: string.Format("{0} by {1}", Item.Title, Item.Author) %>'
                    NavigateUrl='<%#: string.Format("~/BookDetails.aspx?id={0}", Item.BookId) %>'></asp:HyperLink>
                <asp:Label runat="server" Text='<%#: string.Format("(Category: {0})", Item.Category.Name) %>'></asp:Label>
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
