<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="AspNetAjax.WebChat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:ScriptManager runat="server" />

        <asp:UpdatePanel ID="UpdatePanelMessages" runat="server">
            <ContentTemplate>
                <asp:ListView ID="ListViewMessages" runat="server" ItemType="AspNetAjax.WebChat.Message">
                    <ItemSeparatorTemplate>
                        <hr />
                    </ItemSeparatorTemplate>
                    <ItemTemplate>
                        <asp:Label Text="<%#: Item.Text %>" runat="server" />
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdatePanel id="UpdatePanelSendMessage" runat="server"
            UpdateMode="Conditional">
            <ContentTemplate>
                <hr />
                <div>
                    <asp:TextBox ID="TextBoxNewMessageText" runat="server" />
                    <asp:Button ID="BtnSendMessage" runat="server" Text="Send" OnClick="OnBtnSendMessage_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Timer ID="TimerRefresh" runat="server" OnTick="TimerRefresh_Tick" Interval="500"></asp:Timer>
    </form>
</body>
</html>
