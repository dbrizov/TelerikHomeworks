<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ViewStateDemo.aspx.cs"
    Inherits="AspNetStateManagement.ViewStateDeleteWIthJavaScript.ViewStateDemo"
    EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>VIEWSTATE Demo</title>
    <script src="jquery-1.10.2.js"></script>
</head>

<body>
    <form id="formMain" runat="server">
        <h1>VIEWSTATE Demo</h1>

        <asp:Panel ID="Panel" runat="server" style="padding: 10px; border:1px solid black"
            EnableViewState="true">
            I am a panel. My color is stored in my VIEWSTATE.<br />
            If you disable the VIEWSTATE (at page or control level),
            my color will be lost at postback. 
        </asp:Panel>

        <p>
            I am a TextBox. My value will be preserved independently of the VIEWSTATE,
            bacause it is posted with the form body. My "width" will not be preserved
            only if the VIEWSTATE is anabled. <br />
            <asp:TextBox ID="TextBoxExample" runat="server" EnableViewState="true" />
        </p>

        <p>
            <asp:Button ID="ButtonChangePanelColor" runat="server" Text="Change Panel Color" 
                onclick="ButtonChangePanelColor_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonChangeTextBoxWidth" runat="server" Text="Change TextBox Width" 
                onclick="ButtonChangeTextBoxWidth_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonDoNothing" runat="server" Text="Do Nothing" />
        </p>

        <button id="btn-delete-view-state" >Delete View State</button>
    </form>
    <script>
        $("button#btn-delete-view-state").on("click", function () {
            $("input#__VIEWSTATE").remove();
        });
    </script>
</body>

</html>
