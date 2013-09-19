<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormRegister.aspx.cs" Inherits="Validation.FormRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Register Form</title>
        <link href="site.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form" runat="server">
            <div id="registerForm">
                <asp:ValidationSummary
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server"
                    CssClass="error"
                    ID="errorResult"
                    ValidationGroup="loginInfo"
                    />
                <asp:ValidationSummary
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server"
                    CssClass="error"
                    ID="PersonalInfoValidation"
                    ValidationGroup="personalInfo"
                    />
                <asp:ValidationSummary
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server"
                    CssClass="error"
                    ID="AdditionalInfo"
                    ValidationGroup="additinalInfo"
                    />
                <asp:ValidationSummary
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server"
                    CssClass="error"
                    ID="AcceptSummary"
                    ValidationGroup="accept"
                    />
                <fieldset>
                    <legend>Login Info:</legend>
                    <asp:Label Text="Username:" runat="server" CssClass="block"  />
                    <asp:TextBox runat="server" ID="username" />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Username Required!"
                        ControlToValidate="username"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="loginInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid username length (5 - 10)" 
                        ControlToValidate="username"
                        runat="server"
                        CssClass="error"
                        Display="None"
                        ValidationExpression="[\w+\d]{5,10}"
                        ValidationGroup="loginInfo" />
                    <asp:Label Text="Password:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="password"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Password Required!"
                        ControlToValidate="password"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="loginInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid password length (5 - 10)" 
                        ControlToValidate="password"
                        runat="server"
                        CssClass="error"
                        Display="None"
                        ValidationExpression="[\w+\d]{5,10}"
                        ValidationGroup="loginInfo" />
                    <asp:Label Text="Repeat password:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="passwordRepeat"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Password Required!"
                        ControlToValidate="passwordRepeat"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="loginInfo" />
                    <asp:CompareValidator ID="CompareValidator" 
                                          runat="server" 
                                          ErrorMessage="Passwords didnt match" 
                                          ControlToValidate="passwordRepeat"
                                          ControlToCompare="password"
                                          CssClass="error"
                                          Display="None"
                                          ValidationGroup="loginInfo"/><br />
                    <asp:Button Text="Validate" runat="server" ID="loginValidate"
                                OnClick="LoginValidate_Click" />
                </fieldset>
                <fieldset>
                    <legend>Personal Info</legend>
                    <asp:Label Text="FirstName:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="firstName"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="First Name Required!"
                        ControlToValidate="firstName"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="personalInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid name length (5 - 20)" 
                        ControlToValidate="firstName"
                        runat="server"
                        CssClass="error"
                        Display="None"
                        ValidationExpression="[\w]{2,10}"
                        ValidationGroup="personalInfo" />
                    <asp:Label Text="LastName:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="lastName"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Last Name Required!"
                        ControlToValidate="lastName"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="personalInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid name length (5 - 20)" 
                        ControlToValidate="lastName"
                        runat="server"
                        CssClass="error"
                        Display="None"
                        ValidationExpression="[\w]{2,10}"
                        ValidationGroup="personalInfo" />

                    <asp:Label Text="Age:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="age"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Age Required!"
                        ControlToValidate="age"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="personalInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid Age (18-81)" 
                        ControlToValidate="age"
                        runat="server"
                        CssClass="error"
                        ValidationExpression="[\d]{2}"
                        Id="regexAge"
                        Display="None"
                        ValidationGroup="personalInfo"/><br />
                    <asp:Button Text="Validate" runat="server" ID="personInfoBtn"
                                OnClick="PersonInfoBtn_Click" />
                </fieldset>
                <fieldset>
                    <legend>Additional Info</legend>
                    <asp:Label Text="Email:" runat="server" CssClass="block"/>
                    <asp:TextBox runat="server" ID="email"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Email Required!"
                        ControlToValidate="email"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="additinalInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid Email" 
                        ControlToValidate="email"
                        runat="server"
                        CssClass="error"
                        Display="None"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="additinalInfo" />

                    <asp:Label Text="Local Addres:" runat="server"  CssClass="block"/>
                    <asp:TextBox runat="server" ID="addres" />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Local Adress Required!"
                        ControlToValidate="addres"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="additinalInfo" />

                    <asp:Label Text="Phone:" runat="server" CssClass="block" />
                    <asp:TextBox runat="server" ID="phone"  />
                    <asp:RequiredFieldValidator 
                        ErrorMessage="Phone Required!"
                        ControlToValidate="phone"
                        runat="server"
                        Display="None"
                        CssClass="error"
                        ValidationGroup="additinalInfo" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Invalid Phone ([6-9]XXXXXXXX)" 
                        ControlToValidate="phone"
                        runat="server"
                        CssClass="error" 
                        Display="None"
                        ValidationExpression="[6-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"
                        ValidationGroup="additinalInfo"
                        /><br />
                    <asp:Button Text="Validate" runat="server" ID="additinalInfoBtn"
                                OnClick="AdditinalInfoBtn_Click"
                                />
                </fieldset>

                <asp:CheckBox Text="I accept" runat="server" ID="accept"  />
                <asp:CustomValidator
                    ErrorMessage="Accept is Required"
                    runat="server"
                    id="acceptValidator"
                    ValidationGroup="accept"
                    Display="None" />

                <asp:Button Text="Register" runat="server" ID="registerBtn" OnClick="RegisterBtn_Click"
                            />
            </div>
        </form>
    </body>
</html>
