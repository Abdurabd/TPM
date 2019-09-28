<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTrainerAvailability.aspx.cs" Inherits="WebApplication4.EditTrainerAvailability" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="script.js"></script>
    <link href="style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <header class="registraion-heading">
            Trainer Pool Management
            <span class="home">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="home-logout">Logout</asp:LinkButton>
                
                <a href="TrainerProfile.aspx"  class="home-logout">Edit Profile</a> 
                <a href="TrainerHome.aspx"  class="home-logout">Home</a> 
                </span>
        </header>
        <article>
            <center>
            <table  class="registratin-table" cellpadding="10px" cellspacing="10px">
                <tr>
                    <th colspan="2">
                        Availability Details
                    </th>
                </tr>
                <tr>
                    <td>
                        Start Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        End Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Availability</td>
                    <td>
                        <asp:RadioButton ID="available" runat="server" Text="Available" GroupName="status"/><asp:RadioButton ID="busy" runat="server" Text="Busy" GroupName="status"/>
                    </td>
                </tr>
            </table>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" OnClientClick="return availability()" CssClass="register-button"/>
                <br />
                 <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </center>
        </article>
       <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>

    </div>
    </form>
</body>
</html>
