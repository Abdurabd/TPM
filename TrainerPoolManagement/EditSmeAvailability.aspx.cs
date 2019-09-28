using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model;
using dao;

namespace WebApplication4
{
    public partial class EditSmeAvailability : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            {
                string status;
                if (available.Checked == true)
                {
                    status = "Available";
                }
                else
                {
                    status = "Busy";
                }

                RequestManagementSql request = new RequestManagementSql();
                request.addSmeAvailability(det, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), status);
                Label1.Text = "Availability saved";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}