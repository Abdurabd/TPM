using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dao;
using model;

namespace TrainerPage
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Details ad = new Details();
                AdminDetails det = new AdminDetails();
                det = ad.adminname(Session["adminlogin"].ToString());
                Label1.Text = det.Userid;
                string s = Session["adminlogin"].ToString();
                if (s == null)
                {
                    Response.Redirect("Login.aspx");
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Requests(InAdmin).aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainerLists(InAdmin).aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMELists(InAdmin).aspx");
        }

     

        

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}