<%@ Page Title="Home Page" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PollSystem.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Poll System</h1>

    <asp:ListView ID="ListViewPollQuestions" runat="server"
        ItemType="PollSystem.Models.Question">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="poll-question">
                <strong><%#: Item.Text %></strong>
                <ul>
                    <asp:Repeater runat="server"
                        ItemType="PollSystem.Models.Answer"
                        DataSource="<%# Item.Answers %>">
                        <ItemTemplate>
                            <li class="poll-answer">
                                <%#: Item.Text %>
                                <asp:Button Text="Vote" runat="server" 
                                    CommandName="Vote"
                                    CommandArgument="<%#: Item.AnswerId %>"
                                    OnCommand="OnBtnVote_Command" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
