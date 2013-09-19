<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="06. Calculator.aspx.cs" 
    Inherits="AspNetWebAndHtmlControls.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="calculator.css" rel="stylesheet" />
</head>
<body>
    <header>
        <h1>Works only with digits [0, 9]</h1>
    </header>
    <form id="MainForm" runat="server">
        <table>
            <tr>
                <td colspan="4">
                    <asp:TextBox id="TextBoxCalcDisplay" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button id="BtnOne" OnClick="OnBtnInput_Click" Text="1" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnTwo" OnClick="OnBtnInput_Click" Text="2" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnThree" OnClick="OnBtnInput_Click" Text="3" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnPlus" OnClick="OnBtnInput_Click" Text="+" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button id="BtnFour" OnClick="OnBtnInput_Click" Text="4" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnFive" OnClick="OnBtnInput_Click" Text="5" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnSix" OnClick="OnBtnInput_Click" Text="6" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnMinus" OnClick="OnBtnInput_Click" Text="-" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button id="BtnSeven" OnClick="OnBtnInput_Click" Text="7" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnEight" OnClick="OnBtnInput_Click" Text="8" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnNine" OnClick="OnBtnInput_Click" Text="9" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnMultiply" OnClick="OnBtnInput_Click" Text="*" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button id="BtnClear" OnClick="OnBtnClear_Click" Text="Clear" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnZero" OnClick="OnBtnInput_Click" Text="0" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnDivide" OnClick="OnBtnInput_Click" Text="/" runat="server" />
                </td>
                <td>
                    <asp:Button id="BtnSquareRoot" OnClick="OnBtnCalculateSqrt_Click" Text="&#x221a;" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button id="BtnCalculate" OnClick="OnBtnCalculate_Click" Text="=" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
