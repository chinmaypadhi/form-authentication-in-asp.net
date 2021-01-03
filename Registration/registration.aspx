<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="form_authentication.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>registration paage</h1>
            <table>
                <tr>
                    <td>
                        enter the user name
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server">

                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="pleaseenter the user name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        enter the password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" >

                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="please enter password here"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td>
                        enter the confirm password
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPasswoord" runat="server" >

                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPasswoord" Display="Dynamic" ErrorMessage="please enter a confirm password"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPasswoord" ErrorMessage="password and confirm passwordare not same"></asp:CompareValidator>
                    </td>
                </tr>
                                <tr>
                    <td>
                        enter the email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server">

                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="please enter a valid email adress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                                <tr>
                  
                    <td>
                      <asp:Button ID="btnregister" Text="register" runat="server" OnClick="btnregister_Click" />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
