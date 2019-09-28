<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestorProfile.aspx.cs" Inherits="WebApplication4.RequestorProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="style1.css" rel="stylesheet" />
    <script src="script.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 102px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <header class="registraion-heading">
        Trainer Pool Management        
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="home-logout">Home</asp:LinkButton>
          <a href="Myrequests.aspx" class="home-logout">Pending Requests</a>
         <a href="ApprovedRequests.aspx" class="home-logout">Approved Requests</a>
         <a href="RequestorProfile.aspx" class="home-logout">Edite Profile</a>
    </header>
    
    <div>
        <center>
        <article>
            <table class="registratin-table" cellpadding="5px" cellspacing="10px">
                <tr>
                    <th colspan="2">Profile</th>
                </tr>
                <tr>
                    <td class="auto-style1">Requestor Id</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">First Name</td>
                  <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td class="auto-style1">Last Name</td>
                   <td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> </td>
                </tr>
                <tr><td class="auto-style1">Gender</td>
                  <td> <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> </td>
                </tr>
               <tr>
                   <td class="auto-style1">Age</td>
                 <td> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> </td>
               </tr>
                <tr>
                    <td class="auto-style1">Contact Number</td>
                  <td> <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td class="auto-style1">Email</td>
                   <td> <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">Description</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
               
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" Text="SAVE" OnClick="Button1_Click" placeholder="Enter Description" OnClientClick="return validateEdit()" CssClass="register-button"></asp:Button>
        </article>
        <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
            </center>
       <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
    </div>
    </form>
</body>
</html>
