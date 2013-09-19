<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs"
    Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="ContentEditCategories" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <asp:GridView ID="GridViewCategories" runat="server" 
        ItemType="LibrarySystem.Models.Category"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        AutoGenerateColumns="false"
        SelectMethod="GridViewCategories_GetData">
        <Columns>
            <asp:BoundField HeaderText="Category Name" DataField="Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server"
                        Text="Edit"
                        CssClass="btn btn-default"
                        CommandArgument="<%# Item.CategoryId %>"
                        CommandName="EditCategory"
                        OnCommand="OnButtonShowEditCategory_Command" />
                    <asp:Button runat="server"
                        Text="Delete"
                        CssClass="btn btn-default"
                        CommandArgument="<%# Item.CategoryId %>"
                        CommandName="DeleteCategory"
                        OnCommand="OnButtonShowDeleteCategory_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%-- Edit Panel --%>
    <asp:Panel id="PanelEditCategory" runat="server" Visible="false">
        <h2>Edit Category</h2>
        Category:
        <asp:TextBox ID="TextBoxEditCategoryName" runat="server" />
        <br />
        <asp:Button ID="ButtonSaveCategory" Text="Save" runat="server"
            CssClass="btn btn-default"
            CommandName="SaveCategory"
            OnCommand="OnButtonSaveCategory_Command" />
        <asp:Button id="ButtonCancelEdit" Text="Cancel" runat="server"
            CssClass="btn btn-default"
            OnClick="OnButtonCancelEdit_Click" />
    </asp:Panel>

    <%-- Create Panel --%>
    <asp:Panel id="PanelCreateCategory" runat="server" Visible="false">
        <h2>Create Category</h2>
        Category:
        <asp:TextBox ID="TextBoxCreateCategoryName" runat="server" />
        <br />
        <asp:Button ID="ButtonCreateCategory" Text="Create" runat="server"
            CssClass="btn btn-default"
            CommandName="CreateCategory"
            OnCommand="OnButtonCreateCategory_Command" />
        <asp:Button id="ButtonCancelCreate" Text="Cancel" runat="server"
            CssClass="btn btn-default"
            OnClick="OnButtonCancelCreate_Click" />
    </asp:Panel>

    <%-- Delete Panel --%>
    <asp:Panel id="PanelDeleteCategory" runat="server" Visible="false">
        <h2>Delete this category?</h2>
        Category:
        <asp:TextBox ID="TextBoxDeleteCategoryName" runat="server" ReadOnly="true" />
        <br />
        <asp:Button ID="ButtonDeleteCategory" Text="Yes" runat="server"
            CssClass="btn btn-default"
            CommandName="SaveCategory"
            OnCommand="OnButtonDeleteCategory_Command" />
        <asp:Button id="ButtonCancelDelete" Text="No" runat="server"
            CssClass="btn btn-default"
            OnClick="OnButtonDontDelete_Click" />
    </asp:Panel>

    <%-- Create new button --%>
    <asp:Button ID="ButtonShowCreateCategory" runat="server"
        Text="Create new"
        CssClass="btn btn-default"
        CommandName="DeleteCreateCategory"
        OnCommand="OnButtonShowCreateCategory_Command" />
    <br />
    <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server">Back to books</asp:HyperLink>
</asp:Content>
