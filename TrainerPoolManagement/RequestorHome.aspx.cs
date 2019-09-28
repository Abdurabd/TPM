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
    public partial class Requestor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Skill> dbdata = new List<Skill>();
                RegistrationCheckbox checkboxDetails = new RegistrationCheckbox();
                dbdata = checkboxDetails.registrationCheckboxFill();
                foreach (Skill s in dbdata)
                {
                    ListItem item = new ListItem();
                    item.Value = s.SkillId.ToString();
                    item.Text = s.SkillName;
                    RadioButtonList1.Items.Add(item);
                }
                string name = Session["adminlogin"].ToString();
                Label2.Text = name;
            }

        }

        protected void buttonRequest_Click(object sender, EventArgs e)
        {
            Details d = new Details();
                long det = d.requestordet(Session["adminlogin"].ToString());
                string status = "ON";
                RequestManagementSql request = new RequestManagementSql();
                request.addRequest(det,long.Parse(RadioButtonList1.SelectedValue), DateTime.Parse(dateStart.Text), DateTime.Parse(dateEnd.Text), txtVenue.Text, status);
                Label1.Text = "Request Added Successfully";
            //  Response.Redirect("Registration.aspx");
            RadioButtonList1.ClearSelection();
            dateStart.Text = dateEnd.Text = txtVenue.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApprovedRequests.aspx");
        }
    }
    }
