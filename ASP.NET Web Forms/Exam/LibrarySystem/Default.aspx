<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <div class="search-box">
        <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server"
            Text="Search"
            CssClass="btn btn-default"
            OnClick="OnButtonSearch_Click" />
    </div>

    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="LibrarySystem.Models.Category">
        <ItemTemplate>
            <ul class="books">
                <p class="lead">
                    <asp:Label runat="server"><%#: Item.Name %></asp:Label>
                </p>
                <asp:Repeater ID="RepeaterBooks" runat="server"
                    ItemType="LibrarySystem.Models.Book"
                    DataSource="<%# CategoryBooks(Item.CategoryId) %>">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" Text="<%#: Item.Title %>"
                                NavigateUrl='<%#: string.Format("~/BookDetails.aspx?id={0}", Item.BookId) %>'></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
