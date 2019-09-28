<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Myrequests.aspx.cs" Inherits="WebApplication4.Myrequests" %>

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
            <a href="RequestorHome.aspx" class="home-logout">Home</a> 
            <a href="RequestorProfile.aspx" class="home-logout">Profile</a>
        </header>
    <center>
    <div>
        <article>
            <h2>My Request</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="grid" CellPadding="4" CellSpacing="4">
                <Columns>
                    <asp:BoundField DataField="requestId" HeaderText="Request ID" />
                    <asp:BoundField DataField="skillSubject" HeaderText="Skill"/>
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="venue" HeaderText="Venue"/>
                </Columns>
                <AlternatingRowStyle BackColor="silver"/>
        </asp:GridView>
        </article>
    </div>
    </center>
    </form>
</body>
</html>
<footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
</footer>
    
