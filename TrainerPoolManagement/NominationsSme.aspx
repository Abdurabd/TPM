<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NominationsSme.aspx.cs" Inherits="TrainerPage.NominationsSme" %>

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
        <asp:LinkButton ID="LinkButton2" runat="server" class="home-logout" OnClick="LinkButton2_Click">Logout</asp:LinkButton>
        <a href="EditSmeAvailability.aspx" class="home-logout">Edit Availability</a> 
        <a href="SmeProfile.aspx" class="home-logout">Edit Profile</a> 
        </header>
        <center>
            <h2>My Nominations</h2>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="nomination-sme-style" CellPadding="4" CellSpacing="4">
            <Columns>
                <asp:BoundField DataField="Requestid" HeaderText="Requestid" />
                <asp:BoundField DataField="Smeid" HeaderText="smeId" />
            </Columns>

        </asp:GridView>
    </div>
            </center>
    </form>
</body>
</html>
