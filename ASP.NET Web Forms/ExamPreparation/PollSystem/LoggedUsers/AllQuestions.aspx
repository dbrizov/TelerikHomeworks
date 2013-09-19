<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AllQuestions.aspx.cs"
    Inherits="PollSystem.LoggedUsers.AllQuestions"
    EnableEventValidation="false" %>

<asp:Content ID="AllQuestionsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Questions</h1>

    <asp:GridView ID="GridViewQuestions" runat="server"
        AutoGenerateColumns="false"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewQuestions_GetData"
        DataKeyNames="QuestionId"
        OnSelectedIndexChanged="GridViewQuestions_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Question" DataField="Text" SortExpression="Text" />
            <asp:CommandField ShowSelectButton="true" SelectText="Details" HeaderText="Action" />
        </Columns>
    </asp:GridView>
    <br />

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"
            ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li class="poll-answer">
                    <%#: Item.Text %>: <strong><%#: Item.Votes %></strong>
                    <asp:Button Text="Vote" runat="server"
                        CommandName="Vote"
                        CommandArgument="<%#: Item.AnswerId %>"
                        OnCommand="OnBtnVote_Command" />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
