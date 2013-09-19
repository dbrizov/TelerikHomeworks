<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs"
    Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>

    <asp:GridView ID="GridViewBooks" runat="server"
        ItemType="LibrarySystem.Models.Book"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        AutoGenerateColumns="false"
        SelectMethod="GridViewBooks_GetData">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label runat="server" Text="<%#: CutString(Item.Title) %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <asp:Label runat="server" Text="<%#: CutString(Item.Author) %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <asp:Label runat="server" Text="<%#: CutString(Item.ISBN) %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Web site" SortExpression="WebSite">
                <ItemTemplate>
                    <a href="<%#: Item.WebSite %>" runat="server"><%#: CutString(Item.WebSite) %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label Text="<%#: CutString(Item.Category.Name) %>" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server"
                        Text="Edit"
                        CssClass="btn btn-default"
                        CommandArgument="<%# Item.BookId %>"
                        CommandName="EdiBook"
                        OnCommand="OnButtonShowEditBookPanel_Command" />
                    <asp:Button runat="server"
                        Text="Delete"
                        CssClass="btn btn-default"
                        CommandArgument="<%# Item.BookId %>"
                        CommandName="DeleteBook"
                        OnCommand="OnButtonShowDeleteBookPanel_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%-- Create Book Panel --%>
    <asp:Panel ID="PanelCreateBook" runat="server" Visible="false">
        <h2>Create New Book</h2>
        <div>
            Title:
            <asp:TextBox ID="TextBoxCreateBookTitle" runat="server"></asp:TextBox>
        </div>
        <div>
            Author(s):
            <asp:TextBox ID="TextBoxCreateBookAuthors" runat="server"></asp:TextBox>
        </div>
        <div>
            ISBN:
            <asp:TextBox ID="TextBoxCreateBookISBN" runat="server"></asp:TextBox>
        </div>
        <div>
            Web site:
            <asp:TextBox ID="TextBoxCreateBookWebSite" runat="server"></asp:TextBox>
        </div>
        <div>
            Description:
            <asp:TextBox ID="TextBoxCreateBookDescription" runat="server"
                TextMode="MultiLine" Columns="200" Rows="10"></asp:TextBox>
        </div>
        <div>
            Category:
            <asp:DropDownList ID="DropDownCreateCategories" runat="server"
                ItemType="LibrarySystem.Models.Category"
                DataTextField="Name"
                DataValueField="CategoryId">
            </asp:DropDownList>
        </div>
        <asp:Button ID="ButtonCreateBook" runat="server"
            Text="Create"
            CssClass="btn btn-default"
            CommandName="CreateBook"
            OnCommand="OnButtonCreateBook_Command" />
        <asp:Button ID="ButtonCancelCreate" runat="server"
            Text="Cancel"
            CssClass="btn btn-default"
            OnClick="OnButtonCancelCreate_Click" />
    </asp:Panel>

    <%-- Delete Book Panel --%>
    <asp:Panel ID="PanelDeleteBook" runat="server" Visible="false">
        <h2>Delete this book?</h2>
        Category:
        <asp:TextBox ID="TextBoxDeleteBookTitle" runat="server"
            ReadOnly="true" TextMode="MultiLine" Columns="200" />
        <br />
        <asp:Button ID="ButtonDeleteBook" Text="Yes" runat="server"
            CssClass="btn btn-default"
            CommandName="DeleteBook"
            OnCommand="OnButtonDeleteBook_Command" />
        <asp:Button id="ButtonCancelDelete" Text="No" runat="server"
            CssClass="btn btn-default"
            OnClick="OnButtonCancelDelete_Click" />
    </asp:Panel>

    <%-- Edit Book Panel --%>
    <asp:Panel ID="PanelEditBook" runat="server" Visible="false">
        <h2>Edit Book</h2>
        <div>
            Title:
            <asp:TextBox ID="TextBoxEditBookTitle" runat="server"></asp:TextBox>
        </div>
        <div>
            Author(s):
            <asp:TextBox ID="TextBoxEditBookAuthors" runat="server"></asp:TextBox>
        </div>
        <div>
            ISBN:
            <asp:TextBox ID="TextBoxEditBookISBN" runat="server"></asp:TextBox>
        </div>
        <div>
            Web site:
            <asp:TextBox ID="TextBoxEditBookWebSite" runat="server"></asp:TextBox>
        </div>
        <div>
            Description:
            <asp:TextBox ID="TextBoxEditBookDescription" runat="server"
                TextMode="MultiLine" Columns="200" Rows="10"></asp:TextBox>
        </div>
        <div>
            Category:
            <asp:DropDownList ID="DropDownEditCategories" runat="server"
                ItemType="LibrarySystem.Models.Category"
                DataTextField="Name"
                DataValueField="CategoryId">
            </asp:DropDownList>
        </div>
        <asp:Button ID="ButtonEditBook" runat="server"
            Text="Save"
            CssClass="btn btn-default"
            CommandName="EditBook"
            OnCommand="OnButtonEditBook_Command" />
        <asp:Button ID="ButtonCancelEdit" runat="server"
            Text="Cancel"
            CssClass="btn btn-default"
            OnClick="OnButtonCancelEdit_Click" />
    </asp:Panel>

    <asp:Button ID="ButtonShowCreateBookPanel" runat="server"
        Text="Create New"
        CssClass="btn btn-default"
        CommandName="DeleteCreateCategory"
        OnCommand="OnButtonShowCreateBookPanel_Command" />
    <br />
    <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server">Back to books</asp:HyperLink>
</asp:Content>
