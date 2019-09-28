<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body>
    <header class="main-heading">
       WeDirect Trainer Pool Management</header>
    <form id="form1" runat="server"  class="body">
    <div>
    <center>
         <table cellpadding="10px">
            <tr>
                <th>
                    USER LOGIN*
                </th>
            </tr>
            <tr class="user-right">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="UserId"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="UserName" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    </td>
            </tr>
            <tr class="user-right">
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Password" TextMode="Password"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="UserPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style1">
                </td>
            </tr>
             <tr>
                 <td>Remember me? <asp:CheckBox ID="chkboxPersist" runat="server"></asp:CheckBox></td>
             </tr>
              <tr>
                  <td class="forget-password">
                    <a href="#">Forgot Password ?</a>
                  </td>
              </tr>
                <tr>
                  <td class="log-button">
                    <asp:Button ID="Button1" runat="server" Text="LOGIN" CssClass="button" OnClick="Button1_Click"></asp:Button>
                  </td> 
              </tr>
              <tr>
                  <td>
                    <asp:Label ID="Label4" runat="server" Text="New User:"></asp:Label>
                    <a href="Registration.aspx">SME|</a>
                     <a href="RegistrationPage.aspx">Trainer</a>
                      <a href="RegistrationPage.aspx">Requetor</a>
                  </td>
              </tr>
             <tr>
                 <td>
                    <center> <asp:Label ID="Msg" ForeColor="Red" runat="server" Text="Label" Visible="false"></asp:Label></center>
                 </td>
             </tr>
        </table>
    
    </center>
       
    </div>
    </form>
</body>
</html>
