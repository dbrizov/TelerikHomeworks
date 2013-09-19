<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="04. StudentRegistration.aspx.cs" Inherits="AspNetWebAndHtmlControls._04_StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>First name:</span>
            <asp:TextBox ID="TextBoxFirstName" runat="server" />
            <br />
            <span>Last name:</span>
            <asp:TextBox ID="TextBoxLastName" runat="server" />
            <br />
            <span>Faculty number:</span>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server" />
            <br />
            <span>University:</span>
            <asp:DropDownList ID="DropDownUniversities" runat="server">
                <asp:ListItem Text="Sofia University" />
                <asp:ListItem Text="Sofia Technical University" />
                <asp:ListItem Text="New Bulgarian University" />
            </asp:DropDownList>
            <br />
            <div>Courses:</div>
            <asp:ListBox ID="ListBoxCourses" SelectionMode="Multiple" runat="server">
                <asp:ListItem Text="C#" />
                <asp:ListItem Text="JavaScript" />
                <asp:ListItem Text="ASP.NET Web Forms" />
                <asp:ListItem Text="ASP.NET MVC" />
            </asp:ListBox>
            <asp:Button OnClick="BtnRegister_Click" Text="Register" runat="server" />

            <div id="Summary" runat="server">
                <h1 id="SummaryHeader" runat="server"></h1>
                <div>
                    <div id="StudentFirstName" runat="server"></div>
                    <div id="StudentLastName" runat="server"></div>
                    <div id="StudentFacultyNumber" runat="server"></div>
                    <div id="StudentUniversity" runat="server"></div>
                    <div id="StudentCourses" runat="server"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
