<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs"
    Inherits="PollSystem.LoggedUsers.EditQuestion" %>

<asp:Content ID="EditQuestionContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Question</h1>

    <span class="question-text">Question text: </span>
    <asp:TextBox ID="TextBoxQuestionText" runat="server" Width="100%" />
    <br />

    <div class="lead">Answers</div>
    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"
            ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li class="poll-answer">
                    <asp:Label id="TextBoxAnswerText" runat="server" Text="<%#: Item.Text %>" />

                    <span>Votes:</span>
                    <asp:Label ID="TextBoxAnswerVotes" runat="server" Text="<%# Item.Votes %>" />

                    <a href="EditAnswer.aspx?answerId=<%# Item.AnswerId %>">Edit</a>
                    <asp:LinkButton ID="LinkButtonDeleteAnswer" Text="Delete" runat="server"
                        CommandName="DeleteAnswer"
                        CommandArgument="<%#: Item.AnswerId %>"
                        OnCommand="OnLinkButtonDeleteAnswer_Command" />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:Button Text="Save Changes" runat="server" OnClick="OnBtnSaveChanges_Click"/>
</asp:Content>
