<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestCalenderRequestor.aspx.cs" Inherits="TrainerPage.RequestCalenderRequestor" %>

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
            <a href="Myrequests.aspx" class="home-logout">Pending Requests</a>
         <a href="ApprovedRequests.aspx" class="home-logout">Approved Requests</a>
         <a href="RequestorProfile.aspx" class="home-logout">Edite Profile</a>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="home-logout" OnClick="LinkButton1_Click">Home</asp:LinkButton>
        </header>
        <center>
        <h2>
           Request Schedule
        </h2>
    <div>
        <asp:Calendar ID="Calendar1" runat="server" Height="243px" Width="498px" OnDayRender="Calendar1_DayRender"></asp:Calendar>
        <br />
    </div>

        <b>
        <span class="request-admin-calendar">
        <asp:Label ID="Label5" runat="server" Text="RequestId" CssClass="request-admin-calendar"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="TraineId" CssClass="request-admin-calendar"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="SmeId" CssClass="request-admin-calendar"></asp:Label>
        </span>
        </b>
        <br />
        <span>
            <br />
        <asp:Label ID="Label2" runat="server" Text="Label" CssClass="request-admin-trainer-sme"></asp:Label>
    
        <asp:Label ID="Label3" runat="server" Text="Label" CssClass="request-admin-trainer-sme"></asp:Label>
       
        <asp:Label ID="Label4" runat="server" Text="Label" CssClass="request-admin-trainer-sme"></asp:Label>
        </span>
       <%-- <br />
        <asp:Button ID="Button1" runat="server" Text="Submit Request" OnClick="Button1_Click" CssClass="submit-request-button" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red"></asp:Label>--%>
    </form>
        </center>
     <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
</body>
</html>
