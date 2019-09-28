<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerProfile.aspx.cs" Inherits="WebApplication4.TrainerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style1.css" rel="stylesheet" />
    <script src="script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <header class="registraion-heading">
            Trainer Pool Management
          
            <span class="home">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="home-logout">Logout</asp:LinkButton>
                <a href="EditTrainerAvailability.aspx" class="home-logout">Edit Availability</a>
                <a href="TrainerProfile.aspx" class="home-logout">Edit Profile</a> 
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="home-logout" OnClick="LinkButton2_Click1">Home</asp:LinkButton>
            </span>
        </header>
        <article>
            <center>
            <table class="registratin-table" cellpadding="5px" cellspacing="10px">
                <tr>
                    <th colspan="2">Profile</th>
                </tr>
                <tr>
                    <td>Trainer Id</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>Last Name</td>
                     <td>
                         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td>Gender</td>
                    <td>
                       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> </td>
                </tr>
               <tr>
                   <td>Age</td>
                   <td>
                       <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
               </tr>
                <tr>
                    <td>Contact Number</td>
                    <td>
                       <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                       <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Skills</td>
                    <td>
                       <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" OnClientClick="return validateEdit()" CssClass="register-button"></asp:Button>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
                </center>
        </article>
    </div>
       
    </form>
     <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
</body>
    
   
</html>
