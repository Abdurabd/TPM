using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using dao;
using model;

namespace TrainerPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if(FormsAuthentication.Authenticate(UserName.Text,UserPass.Text))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(UserName.Text,chkboxPersist.Checked);
            //}
            //else
            //{
            //    Msg.Text = "Invalid User Name and/or Password";
            //}
            //Msg.Visible = true;

            if (DropDownList1.Text == "Trainer")
            {
                LoginCheck login = new LoginCheck();
                string username = UserName.Text;
                string password = UserPass.Text;
                int value = login.logincheckuserid(username, password);
                if (value == 1)
                {
                    Session["adminlogin"] = username;
                    Response.Redirect("TrainerHome.aspx");
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Invalid username/password";
                }
            }
            else if (DropDownList1.Text == "SME")
            {
                LoginCheck login = new LoginCheck();
                string username = UserName.Text;
                string password = UserPass.Text;
                int value = login.smecheckuserid(username, password);
                if (value == 1)
                {
                    Session["adminlogin"] = username;
                    Response.Redirect("SmeHome.aspx");
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Invalid username/password";
                }
            }
            else if (DropDownList1.Text == "Requestor")
            {
                LoginCheck login = new LoginCheck();
                string username = UserName.Text;
                string password = UserPass.Text;
                int value = login.requestorcheckuserid(username, password);
                if (value == 1)
                {
                    Session["adminlogin"] = username;
                    Response.Redirect("RequestorHome.aspx");
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Invalid username/password";
                }
            }
            else if (DropDownList1.Text == "Admin")
            {
                LoginCheck login = new LoginCheck();
                string username = UserName.Text;
                string password = UserPass.Text;
                Admin ad = new Admin();
                //ad.admindetails()
                int value = login.admincheckuserid(username, password);
                if (value == 1)
                {
                    Session["adminlogin"] = username;
                    Response.Redirect("Admin1.aspx");
                }
                else
                {
                    Msg.Visible = true;
                    Msg.Text = "Inavlid username/password";
                }
            }
            else
            {
                Msg.Visible = true;
                Msg.Text = "Select Usertype";
            }
            //if (chkboxPersist.Checked)
            //{
            //    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(30);
            //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            //}
            //else
            //{
            //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            //}
            Response.Cookies["UserName"].Value = UserName.Text.Trim();
            Response.Cookies["Password"].Value = UserPass.Text.Trim();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Trainer")
            {
                Session["update"] = DropDownList1.Text;
                Response.Redirect("ForgotPassword.aspx");
            }
            else if (DropDownList1.Text == "SME")
            {
                Session["update"] = DropDownList1.Text;
                Response.Redirect("ForegotPassword");
            }
            else if (DropDownList1.Text == "Requestor")
            {
                Session["update"] = DropDownList1.Text;
                Response.Redirect("ForgotPassword.aspx");
            }
            else if (DropDownList1.Text == "Usertype")
            {
                Msg.Visible = true;
                Msg.Text = "Select User Type";
            }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Session["usertype"] = LinkButton1.Text;
        //}
    }
}