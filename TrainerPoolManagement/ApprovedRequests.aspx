<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovedRequests.aspx.cs" Inherits="TrainerPage.ApprovedRequests" %>

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
        <div>
        <article>
            <h2>Approved Requests</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" class="grid" CellPadding="10" CellSpacing="4">
                <Columns>
                    <asp:BoundField DataField="requestId" HeaderText="Request ID" />
                    <asp:BoundField DataField="skillSubject" HeaderText="Skill"/>
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="venue" HeaderText="Venue"/>
                     <asp:HyperLinkField Text="View Schedule" HeaderText="" DataNavigateUrlFields="requestId" DataNavigateUrlFormatString="RequestCalenderRequestor.aspx?requestId={0}" ItemStyle-CssClass="colorfor-image"/>
                
                </Columns>
                <AlternatingRowStyle BackColor="Silver"/>
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
