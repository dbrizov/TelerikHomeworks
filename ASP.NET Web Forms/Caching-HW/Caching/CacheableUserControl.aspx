<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CacheableUserControl.aspx.cs"
    Inherits="Caching.CacheableUserControl1" %>

<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="my" TagName="CacheableUserControl" %>

<asp:Content ID="CacheableUserControlContent" ContentPlaceHolderID="MainContent" runat="server">
    <my:CacheableUserControl runat="server" />
</asp:Content>
