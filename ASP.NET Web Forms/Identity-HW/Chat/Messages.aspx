<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Messages.aspx.cs"
    Inherits="Chat.Messages" %>

<asp:Content ID="ContentMessages" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewMessages" runat="server"
        ItemType="Chat.Models.Message">
        <ItemSeparatorTemplate>
            <br />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <strong><%#: Item.User.UserName %>:</strong>
            <span class="message-text"><%#: Item.Text %></span>
        </ItemTemplate>
    </asp:ListView>

    <div>
        <asp:TextBox ID="TextBoxNewMessageText" runat="server" CssClass="tb-message-text" />
        <asp:Button ID="BtnSendMessage" runat="server"
            Text="Send" OnClick="OnBtnSendMessage_Click" />
    </div>
</asp:Content>
