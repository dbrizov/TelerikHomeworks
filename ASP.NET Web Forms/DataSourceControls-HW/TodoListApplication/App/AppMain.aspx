<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AppMain.aspx.cs"
    Inherits="TodoListApplication.App.AppMain"
    EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <h1>Categories</h1>
        <asp:ListBox ID="ListBoxCategories" runat="server" 
            OnSelectedIndexChanged="OnListBoxCategories_SelectedIndexChanged"
            DataTextField="Name"
            DataValueField="CategoryId"
            AutoPostBack="True"
            Rows="7"></asp:ListBox>
        <br />

        <%--Add Categories--%>
        <span>Category name:</span>
        <asp:TextBox ID="TextBoxCategoryName" runat="server" />
        <asp:Button runat="server" Text="Add Category" OnClick="OnBtnAddCategory_Click" />
        <br />

        <%--Delete categories--%>
        <asp:DropDownList ID="DropDownListCategories" runat="server"
            DataTextField="Name"
            DataValueField="CategoryId"
            AutoPostBack="False">
        </asp:DropDownList>
        <asp:Button Text="Delete Category" runat="server" OnClick="OnBtnDeleteCategory_Click" />

        <div>
            <h1>Todos</h1>
            <asp:ListView ID="ListViewTodos" runat="server"
                DataKeyNames="TodoId"
                ItemType="TodoListApplication.Database.Todo">
                <EmptyDataTemplate>
                    <span style="color:red">This todo list has not todos</span>
                </EmptyDataTemplate>
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="">
                        <asp:Label ID="TodoIdLabel" runat="server" Visible="false" Text="<%#: Item.TodoId %>"></asp:Label>
                        <strong><asp:Label ID="BodyLabel" runat="server" Text='<%#: Item.Body %>' /></strong>
                        <asp:CheckBox ID="IsDoneCheckBox" runat="server"
                            Checked='<%# Item.IsDone %>' Enabled="True" OnCheckedChanged="IsDoneCheckBox_CheckedChanged" AutoPostBack="true" />
                        <br />
                        <strong>DateOfLastChange: </strong>
                        <asp:Label ID="DateOfLastChangeLabel" runat="server" Text='<%#: Item.DateOfLastChange %>' />
                        <br />
                        <asp:Button Text="Delete" runat="server" OnClick="OnBtnDeleteTodo_Click" />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="">
                    </div>
                </LayoutTemplate>
            </asp:ListView>
            <br />

            <%--Add Todos--%>
            <span>Todo:</span>
            <asp:TextBox ID="TextBoxTodoBody" runat="server" />
            <asp:Button Text="Add Todo" runat="server" OnClick="OnBtnAddTodo_Click" />
        </div>
    </form>
</body>
</html>
