<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="TrainerPage.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="script.js"></script>
    <link href="style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <header class="registraion-heading">
       Trainer Pool Management
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="home-logout" Visible="false" OnClick="LinkButton1_Click">Login</asp:LinkButton>
    </header>
    <div class="Registration-form">
        <h1>Registration form</h1>
    </div>
    <article>
        
            <div>
            <center>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" ></asp:Label>
                <table cellpadding="5px" cellspacing="10px" class="registratin-table"> 
                    <tr>
                        <td>First Name</td>
                        <td>
                            <asp:TextBox ID="txtfirstname" runat="server" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td>
                            <asp:TextBox ID="txtlastname" runat="server" CssClass="firstname-width"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Age</td>
                        <td>
                            <asp:TextBox ID="txtage" runat="server" TextMode="Number"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Gender
                        </td>
                        <td>
                            <asp:RadioButton ID="radiogender" runat="server" GroupName="gender" Text="Male" />
                            <asp:RadioButton ID="radiosgender" runat="server" GroupName="gender" Text="Female" />
                        </td>
                    </tr>
                    <tr>
                        <td>Contact Number
                        </td>
                        <td>
                            <asp:TextBox ID="txtcontact" runat="server" TextMode="Number" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>User Id</td>
                        <td>
                            <asp:TextBox ID="txtuserid" runat="server" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm Password</td>
                        <td>
                            <asp:TextBox ID="confirm" runat="server" TextMode="Password" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>emailId</td>
                        <td>
                            <asp:TextBox ID="emailid" runat="server" CssClass="firstname-width"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>User Type</td>
                        <td>
                            <asp:DropDownList ID="usertype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="usertype_SelectedIndexChanged">
                                <asp:ListItem>Usertype</asp:ListItem>
                                <asp:ListItem>SME</asp:ListItem>
                                <asp:ListItem>Trainer</asp:ListItem>
                                <asp:ListItem>Requestor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                   <%-- <tr>
                        
                        <td colspan="2">    
                           <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click"></asp:Button>
                        </td>
                    </tr>--%>
                    
                    <tr>
                     
                         <td><asp:Label ID="lbl1" runat="server" Text="SkillSet" Visible="false"></asp:Label></td>
                        <td>

                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="False" ></asp:CheckBoxList>
                        </td>
                           
                      <%--  <td>
                            <asp:CheckBox ID="Checkjava" runat="server" Text="Java" />
                            <asp:CheckBox ID="Checkdotnet" runat="server" Text="Dotnet" />
                            <asp:CheckBox ID="Checkmain" runat="server" Text="Mainframe" />
                            <asp:CheckBox ID="Checkpython" runat="server" Text="Python" /></td>--%>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Register" OnClientClick="return validate()" OnClick="Button1_Click" CssClass="register-button" />
                <br />
                <br />
                
            </center>                               
            </div>
        </form>
    </article>
    <%-- <footer class="footer">
            Copyright &copy 2019 by WDTPM team
            <br />
            All rights are reserved.
        </footer>--%>
</body>
</html>

<%--<forms loginurl="Login.aspx" defaulturl="welcome.aspx">
        <credentials passwordFormat="Clear">
          <user name="abhishek" password="abhi@123"/>
        </credentials>
      </forms>--%>
