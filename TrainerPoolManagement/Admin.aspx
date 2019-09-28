<head runat="server">
    <link href="style1.css" rel="stylesheet" />
    <title></title>
</head>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
    <header class="registraion-heading">
       Trainer Pool Management
       
       <%-- </header>
        <span class="home-logout">--%>
             <%--<asp:LinkButton ID="LinkButton2" runat="server" class="home-logout">LogOut</asp:LinkButton>--%>
            <%--<asp:LinkButton ID="LinkButton1" runat="server" class="home-logout">Home</asp:LinkButton>--%>
        <%--</span>--%>
        
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="home-logout" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
        <a href="Admin.aspx" class="home-logout">Home</a>
        </header>

    
        <div class="welcome">
            <span>Welcome, <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
        </div>
        
    <div>
        <center>
            <table class="admin-button" cellspacing="10px" cellspacing="10px">
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Requests" OnClick="Button1_Click" CssClass="button-adjust" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Trainer Lists" CssClass="button-adjust" OnClick="Button2_Click"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="SME Lists" CssClass="button-adjust" OnClick="Button3_Click"  />
                </td>
            </tr>
        </table>
        </center>
                
    </div>
    </form>
     <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>
</body>
</html>
