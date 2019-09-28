<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestDetails.aspx.cs" Inherits="Trainingpool.RequestDetails" %>

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
     <article>
              <h2>Nominations by Trainers</h2>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" CssClass="grid-background-color" CellPadding="4" CellSpacing="4">
            <Columns>
                <asp:BoundField DataField="trainerId" HeaderText="Trainer Id" Visible="true"/>
                <asp:BoundField DataField="userid" HeaderText="UserId" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:TemplateField HeaderText="Skillset">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" >
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" Text="Approve" runat="server"  CommandName="select" CommandArgument="<%# Container.DataItemIndex %>"  CssClass="forgot-pass-link"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            
              <br />
              <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label-adjust" Visible="false"></asp:Label>
             <h2>Nominations by SME</h2>
             <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView3_RowCommand" OnRowDataBound="GridView3_RowDataBound" CssClass="grid-background-color" CellPadding="4" CellSpacing="4" >
            <Columns>
            <asp:BoundField DataField="smeId" HeaderText="SME Id" Visible="true"/>
                 <asp:BoundField DataField="userid" HeaderText="UserId" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                 <asp:TemplateField HeaderText="Skillset">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" >
                      
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" Text="Approve" runat="server" CommandName="select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="forgot-pass-link"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
              <br />
              <asp:Label ID="Label3" runat="server" Text="Label" CssClass="label-adjust" Visible="false"></asp:Label>
        <h2>Suggestions For Trainers</h2>
        <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView2_RowCommand" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" CssClass="grid-background-color" CellPadding="4" CellSpacing="4">
            <Columns>
              <asp:BoundField DataField="trainerId" HeaderText="Trainer Id" Visible="true"/>
                 <asp:BoundField DataField="userid" HeaderText="UserId" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                 <asp:TemplateField HeaderText="Skillset">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" >
                      
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" Text="Send Request" runat="server" CommandName="select" CommandArgument="<%# Container.DataItemIndex %>"  CssClass="forgot-pass-link"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       
              <br />
              <asp:Label ID="Label4" runat="server" Text="Label" CssClass="label-adjust" Visible="false"></asp:Label>
          <h2>Suggestions For SME</h2>
        <asp:GridView ID="GridView4" runat="server"  AutoGenerateColumns="False" EmptyDataText="No records found" OnRowCommand="GridView4_RowCommand" OnRowDataBound="GridView4_RowDataBound" CssClass="grid-background-color" CellPadding="4" CellSpacing="4">
            <Columns>
              <asp:BoundField DataField="smeId" HeaderText="SME Id" Visible="true"/>
                 <asp:BoundField DataField="userid" HeaderText="UserId" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                 <asp:TemplateField HeaderText="Skillset">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList4" runat="server" >
                      
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" Text="Send Request" runat="server" CommandName="select" CommandArgument="<%# Container.DataItemIndex %>"  CssClass="forgot-pass-link"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>        
            </Columns>
        </asp:GridView>        
              <br />
              <asp:Label ID="Label5" runat="server" Text="Label" CssClass="label-adjust" Visible="false"></asp:Label>
        <h2><asp:Label ID="Label1" runat="server" Text="Request" Visible="false"></asp:Label></h2>
         <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnSelectedIndexChanged="GridView5_SelectedIndexChanged" OnRowCommand="GridView5_RowCommand" OnRowDataBound="GridView5_RowDataBound" Visible="false" CellPadding="4" CellSpacing="4" CssClass="grid-background-color">
            <Columns>
                <asp:BoundField DataField="requestorId" HeaderText="Requestor Id" />
                <asp:BoundField DataField="requestId" HeaderText="Request Id" />
                <asp:BoundField DataField="skillsubject" HeaderText="Subject" />
                <asp:BoundField DataField="startdate" HeaderText="Start Date" />
                <asp:BoundField DataField="enddate" HeaderText="End Date" />
                <asp:BoundField DataField="venue" HeaderText="Venue" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <%-- <asp:HyperLinkField Text="Finalise Request" HeaderText="" DataNavigateUrlFields="requestId" DataNavigateUrlFormatString="FinaliseRequest.aspx?requestId={0}"/>--%>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" Text="View Calendar" runat="server"  CommandName="select" CommandArgument="<%# Container.DataItemIndex %>"  CssClass="forgot-pass-link"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
           
          </article>
        </center>
          <%-- <a href="FinaliseRequest.aspx">Confirm Request</a>--%>
       <%-- <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>

    </form>
     
   
</body>
</html>
