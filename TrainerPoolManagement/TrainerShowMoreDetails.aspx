<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerShowMoreDetails.aspx.cs" Inherits="TrainerPage.TrainerShowMoreDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <header class="registraion-heading">
        Trainer Pool Management
         
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="home-logout" OnClick="LinkButton2_Click">Logout</asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="home-logout" OnClick="LinkButton1_Click">Home</asp:LinkButton>
    </header>
    
    <div style="text-align: left">
        <center >
              <h2>Trainer Details</h2>
    <table cellpadding="10px" class="registratin-table">
      
        <tr>
            <td>Trainer Id</td>         
            <td>  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>First Name</td>         
            <td>  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Last Name</td>         
            <td>  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Gender</td>         
            <td>  <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        </tr>
          <tr>
            <td>Age</td>         
            <td>  <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Contact Number</td>         
            <td>  <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
        </tr>
          <tr>
            <td>Email</td>         
            <td>  <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="TextBox11" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>           
            <td>Skillset</td>         
            <td><asp:DropDownList ID="DropDownList1" runat="server" OnLoad="Page_Load"></asp:DropDownList></td>
        </tr>
         <tr>
            <td>Availability</td>         
            <td>  <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Start Date</td>         
            <td>  <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>End Date</td>         
            <td>  <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
        </tr>
    </table>

</center>
    </div>
    </form>
     <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
</body>
</html>
