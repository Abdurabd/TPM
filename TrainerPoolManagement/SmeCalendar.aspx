<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmeCalendar.aspx.cs" Inherits="TrainerPage.SmeCalendar" %>

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
            <span> 
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="home-logout">Logout</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="home-logout" OnClick="LinkButton1_Click">Home</asp:LinkButton>
            </span>
        </header>
    
        <center>
            <h2>
                My Schedule
            </h2>
        <div>
        <asp:Calendar ID="Calendar1" runat="server" Height="310px" Width="467px" BackColor="#999999" OnDayRender="Calendar1_DayRender"></asp:Calendar>
        </div>
            <br />
        <asp:Label ID="Label1" runat="server" Text="Red-busy" ForeColor="Red"></asp:Label>
            <h2>My Approvals</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" CellSpacing="10" CssClass="grid-background-color" GridLines="None">
                 <Columns>
                <asp:BoundField DataField="requestId" HeaderText="Request Id" />
                <asp:BoundField DataField="skillsubject" HeaderText="Subject" />
                <asp:BoundField DataField="startdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Start Date" />
                <asp:BoundField DataField="enddate"  DataFormatString="{0:dd/MM/yyyy}" HeaderText="End Date" />
                <asp:BoundField DataField="venue" HeaderText="Venue" />
</Columns>
            </asp:GridView>
        </center>
    </form>
</body>
</html>
