<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
    Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>

    <h3>
        <asp:Label ID="LabelBookTitle" runat="server"></asp:Label>
    </h3>
    <h5>
        <asp:Label id="LabelAuthor" runat="server" ></asp:Label>
    </h5>
    <div>
        <asp:Label ID="LabelIsbn" runat="server"></asp:Label>
    </div>
    <div>
        Web site:
        <asp:HyperLink ID="LabelWebSite" runat="server"></asp:HyperLink>
    </div>
    <p>
        <asp:Label ID="LabelDescription" runat="server"></asp:Label>
    </p>

    <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server">Back to books</asp:HyperLink>
</asp:Content>
