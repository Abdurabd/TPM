<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestorHome.aspx.cs" Inherits="WebApplication4.Requestor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style1.css" rel="stylesheet" />
    <script src="script.js"></script>
    <%--<script src="script1.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <header class="registraion-heading">
       Trainer Pool Management
        <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="home-logout" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
        <a href="Myrequests.aspx" class="home-logout">Pending Requests</a> 
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="home-logout" OnClick="LinkButton2_Click">Approved Requests</asp:LinkButton>
        <a href="RequestorProfile.aspx" class="home-logout">Edit Profile</a>
    </header>
    
    <div>
        <h1>Welcome, <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h1>
         <center>
        <article>
        <div>
            
        </div>
        <table cellpadding="5px" cellspacing="10px" class="registratin-table">
            <tr>
                <th colspan="2">New Request</th>

            </tr>
            <tr>
                <td>Skill:</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                 <%--   <asp:RadioButton ID="radioJava" runat="server" GroupName="skill" Text="Java"/><label for="radioJava"></label>
                    <br />
                    <asp:RadioButton ID="radioDotnet" runat="server" GroupName="skill" Text="DotNet"/><label for="radioDotnet"></label>
                    <br />
                    <asp:RadioButton ID="radioMainFrame" runat="server" GroupName="skill" Text="Mainframe"/><label for="radioMainFrame"></label>
                    <br />
                    <asp:RadioButton ID="radioPython" runat="server" GroupName="skill" Text="Python"/><label for="radioradioPython"></label>--%>
                </td>
            </tr>
            <tr>
                <td>
                    Start Date:
                </td>
                <td>
                    <asp:TextBox ID="dateStart" runat="server" TextMode="Date" CssClass="txtboxsize"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    End Date:
                </td>
                <td>
                    <asp:TextBox ID="dateEnd" runat="server" TextMode="Date" CssClass="txtboxsize"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Venue:</td>
                <td>
                    <asp:TextBox ID="txtVenue" runat="server" CssClass="txtboxsize"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return newrequest()"></asp:Button>--%>
                    <asp:Button ID="buttonRequest" runat="server" Text="Request" OnClientClick="return newrequest()" OnClick="buttonRequest_Click" CssClass="search-available"/>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </th>
            </tr>
        </table>
        </article>
        </center>
    </div>
    </form>
</body>
</html>
 <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
</footer>
