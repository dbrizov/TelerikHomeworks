<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditDeleteQuestions.aspx.cs"
    Inherits="PollSystem.LoggedUsers.EditDeleteQuestions" %>

<asp:Content ID="EditDeleteQuestionsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Questions</h1>

    <asp:GridView ID="GridViewQuestions" runat="server"
        AutoGenerateColumns="false"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        ItemType="PollSystem.Models.Question"
        SelectMethod="GridViewQuestions_GetData"
        DataKeyNames="QuestionId">
        <Columns>
            <asp:BoundField HeaderText="Question" DataField="Text" SortExpression="Text" />
            <asp:HyperLinkField Text="Edit"
                DataNavigateUrlFields="QuestionId"
                DataNavigateUrlFormatString="~/LoggedUsers/EditQuestion.aspx?questionId={0}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDeleteQuestion" Text="Delete" runat="server"
                        CommandName="DeleteQuestion"
                        CommandArgument="<%#: Item.QuestionId %>"
                        OnCommand="OnLinkButtonDeleteQuestion_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
