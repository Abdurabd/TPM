<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrainerPage.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="style.css" rel="stylesheet" />--%><link href="style1.css" rel="stylesheet" />
    <title></title>
    <script>
        function capLock(e) {
        kc = e.keyCode ? e.keyCode : e.which;
        sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
        if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk))
        document.getElementById('divCaps').style.visibility = 'visible';
        else
        document.getElementById('divCaps').style.visibility = 'hidden';
        }
    </script>
</head>

<body class="background-colour">
    <div>
    <header class="login-heading">
       Trainer Pool Management
    </header>
    <center>
        <form id="form1" runat="server">
        <table cellpadding="5px" class="table">
            <tr>
              <td colspan="2">
                  <img src="images/logionimage.jpg" class="img-adjusting"/>
              </td>  
            </tr>
            <tr>
                <th class="image-table"></th>
                <th class="colorfor-image">
                    USER LOGIN*
                </th>
            </tr>
            <tr class="user-right">
                <td></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="UserId"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="UserName" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ErrorMessage="*Enter UserId" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="user-right">
                <td></td>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Password" TextMode="Password"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="UserPass" runat="server" CssClass="textbox" TextMode="Password" onkeypress="capLock(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPass" ErrorMessage="*Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <div id="divCaps" style="visibility:hidden">
                    </div>
                </td>
                <td class="auto-style1">
                </td>
            </tr>
            <tr class="dropdown-adjust">
                 <td></td>
                 <td>
                     User Type :
                    <asp:DropDownList ID="DropDownList1" runat="server">
                         <asp:ListItem>Usertype</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                         <asp:ListItem>SME</asp:ListItem>
                         <asp:ListItem>Trainer</asp:ListItem>
                         <asp:ListItem>Requestor</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <%--  <tr>
                  <td></td>
                  <td>
                   <asp:LinkButton ID="LinkButton1" runat="server" CssClass="forgot-pass-link" OnClick="LinkButton1_Click">Forgot Password?</asp:LinkButton>
                  </td>
              </tr>--%>
             <tr>
                    <td></td>
                  <td class="log-button">
                    <asp:Button ID="Button1" runat="server" Text="LOGIN" CssClass="button" OnClick="Button1_Click"></asp:Button>
                  </td> 
             </tr>
             <tr>
                  <td></td>
                  <td>
                    <asp:Label ID="Label4" runat="server" Text="New User:"></asp:Label>
                      <a href="RegistrationPage.aspx" class="colorfor-image">SME|</a>
                     <a href="RegistrationPage.aspx" class="colorfor-image">Trainer|</a>
                      <a href="RegistrationPage.aspx" class="colorfor-image">Requetor</a>
                  </td>
             </tr>        
        </table>
            <br />
            <asp:Label ID="Msg" ForeColor="Red" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <%--<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="CapsLock is on" Visible="false"></asp:Label>--%>
    </form>
</center>
</div>
</body>
</html>
