<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditSmeAvailability.aspx.cs" Inherits="WebApplication4.EditSmeAvailability" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JavaScript.js"></script>
    <link href="style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="registraion-heading">
        Trainer Pool Management
        <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="home-logout" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
        <a href="SmeProfile.aspx" class="home-logout">Edit Profile</a>
        <a href="SmeHome.aspx" class="home-logout">Home</a> 
    </header>
    <div>
        <center>
        <article>
            <table class="registratin-table" cellpadding="10px" cellspacing="10px">
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
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" OnClientClick="return availability()" CssClass="register-button" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
        </article>
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
