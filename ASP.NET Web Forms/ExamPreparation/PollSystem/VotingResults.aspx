<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="VotingResults.aspx.cs"
    Inherits="PollSystem.VotingResults" %>

<asp:Content ID="VotingResultsContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Voting Results</h1>
    <p class="lead">
        <asp:Label ID="LabelQuestionText" runat="server"></asp:Label>
    </p>

    <ul >
        <asp:Repeater ID="RepeaterAnswers" runat="server"
            ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li class="poll-answer">
                    <%#: Item.Text %>: <strong><%#: Item.Votes %></strong>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
