<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Caching.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">I am cached for an hour</p>
        <asp:Label ID="LabelDateTimeNow" runat="server" CssClass="lead"></asp:Label>
    </header>
</asp:Content>
