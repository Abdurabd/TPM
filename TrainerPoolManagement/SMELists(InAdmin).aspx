<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMELists(InAdmin).aspx.cs" Inherits="TrainerPage.SMELists_InAdmin_" %>

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
    <div>
        <center>
         <h2>SME List</h2>
        <span class="move-search"><asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Java</asp:ListItem>
                <asp:ListItem>Dotnet</asp:ListItem>
                <asp:ListItem>Mainframe</asp:ListItem>
                <asp:ListItem>Python</asp:ListItem>
            </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"  TextMode="Date"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" CssClass="search-available" />
            </span>
        <br />
            <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowDataBound="GridView1_RowDataBound" CellPadding="4" CellSpacing="4" CssClass="grid-background-color">
            <columns>
                <asp:BoundField DataField="smeId" HeaderText="SME Id" Visible="true"/>
                        <asp:BoundField DataField="userid" HeaderText="UserId" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                 <%--<asp:BoundField DataField="gender" HeaderText="Gender" />
                 <asp:BoundField DataField="contact_no" HeaderText="Contact No" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                 <asp:BoundField DataField="age" HeaderText="Age" />--%>
                <asp:TemplateField HeaderText="Skillset">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
               <%--  <asp:BoundField DataField="skillset" HeaderText="Skillset" />--%>
                  <asp:HyperLinkField Text="See More Details" HeaderText="" DataNavigateUrlFields="smeId" DataNavigateUrlFormatString="SMEShowMoreDetails.aspx?smeId={0}" ControlStyle-CssClass="forgot-pass-link"/>
            </columns>
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
