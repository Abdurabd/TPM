﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmeHome.aspx.cs" Inherits="WebApplication4.SmeHome" %>

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
        <h1>Welcome, <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label> 
        </h1>
        <center>
        <div>
       <%-- <article class="sme-home-margin">--%>
            <span class="increase-header-size">
                <b>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Requests From Requestor" Visible="true"></asp:Label>
                </b>
            </span>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView1_RowCommand" GridLines="None" CellPadding="4" CellSpacing="4" CssClass="grid-background-color">
                <Columns>
                     <asp:BoundField DataField="requestId" HeaderText="Request ID"/>
                    <asp:BoundField DataField="skillSubject" HeaderText="Skill"/>
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="venue" HeaderText="Venue"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Nominate" CommandName="Select" CommandArgument="<%#Container.DataItemIndex %>" CssClass="forgot-pass-link"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            <div>
            <br />
                 <asp:Label ID="Label5" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
            

            <br />
            <br />
           <span class="increase-header-size">
           <b>
             <asp:Label ID="Label3" runat="server" Text="Requests From Admin" Visible="true" CssClass="increase-header-size"></asp:Label>
           </b>
           </span> 
               <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView2_RowCommand" GridLines="None" CellPadding="4" CellSpacing="4" CssClass="grid-background-color">
                <Columns>
                     <asp:BoundField DataField="requestId" HeaderText="Request ID"/>
                    <asp:BoundField DataField="skillSubject" HeaderText="Skill"/>
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="venue" HeaderText="Venue"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Accept" CommandName="Select" CommandArgument="<%#Container.DataItemIndex %>" CssClass="forgot-pass-link"/>
                        </ItemTemplate>
                   </asp:TemplateField>
                </Columns>
            </asp:GridView>
                
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
           <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="View Schedule" CssClass="button-float-right" OnClick="Button1_Click" ></asp:Button>
                    
        <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
                  <%--</article>--%>
    </div>
    </center>
    </form>
</body>
</html>
