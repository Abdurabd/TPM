<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requests(InAdmin).aspx.cs" Inherits="TrainerPage.Requests_InAdmin_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style1.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <header class="registraion-heading">
        Trainer Pool Managament
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="home-logout">Logout</asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="home-logout">Home</asp:LinkButton>
     </header>
    <center>
    <div>
        <h2> Requests List</h2>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" CellSpacing="10" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="grid-background-color" GridLines="None">
            <Columns>
                <asp:BoundField DataField="requestorId" HeaderText="Requestor Id" />
                <asp:BoundField DataField="requestId" HeaderText="Request Id" />
                <asp:BoundField DataField="skillsubject" HeaderText="Subject" />
                <asp:BoundField DataField="startdate" HeaderText="Start Date" />
                <asp:BoundField DataField="enddate" HeaderText="End Date" />
                <asp:BoundField DataField="venue" HeaderText="Venue" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:HyperLinkField Text="See More Details" HeaderText="" DataNavigateUrlFields="requestId" DataNavigateUrlFormatString="RequestDetails.aspx?requestId={0}" ItemStyle-CssClass="colorfor-image" ControlStyle-CssClass="forgot-pass-link"/>
            </Columns>
        </asp:GridView>
    </div>
        </center>
    </form>
     <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
</body>

</html>
