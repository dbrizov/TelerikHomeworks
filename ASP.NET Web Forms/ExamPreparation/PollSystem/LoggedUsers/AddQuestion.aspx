<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" 
    Inherits="PollSystem.LoggedUsers.AddQuestion" %>

<asp:Content ID="AddQuestionContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add Question</h1>
    <span class="question-text">Question text: </span>
    <asp:TextBox ID="TextBoxQuestionText" runat="server" />
    <br />
    <span class="answer-text">Answer text: </span>
    <asp:TextBox ID="TextBoxAnswerText" runat="server" />
    <asp:Button Text="Add Answer" runat="server" OnClick="OnBtnAddAnswer_Click" />
    <asp:Button Text="Create Question" runat="server" OnClick="OnBtnCreateQuestion_Click" />
    <asp:Panel ID="PanelAnswers" runat="server">
        <div class="lead">Answers</div>
    </asp:Panel>
    <asp:Button Text="Clear Answers" runat="server" OnClick="OnBtnClearAnswers_Click" />
</asp:Content>
