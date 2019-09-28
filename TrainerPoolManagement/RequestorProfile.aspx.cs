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
    public partial class RequestorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Details d = new Details();
                long det = d.requestordet(Session["adminlogin"].ToString());
                RequestManagementSql requestorDetail = new RequestManagementSql();
                model.RequestorDetails requestorDao = new model.RequestorDetails();
                requestorDao = requestorDetail.getRequestor(det);
                Label1.Text = requestorDao.RequestorId.ToString();
                TextBox1.Text = requestorDao.FirstName;
                TextBox2.Text = requestorDao.LastName;
                TextBox3.Text = requestorDao.Gender;
                TextBox4.Text = requestorDao.Age.ToString();
                TextBox5.Text = requestorDao.ContactNumber.ToString();
                TextBox6.Text = requestorDao.EmailId;
                TextBox7.Text = requestorDao.Description;
               
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestorHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Label2.Visible = true;
            Label2.Text = "profiel edited";
            RequestManagementSql requestdetail = new RequestManagementSql();
            requestdetail.updaterequestordetails(long.Parse(Label1.Text), TextBox1.Text, TextBox2.Text, TextBox3.Text, long.Parse(TextBox4.Text), long.Parse(TextBox5.Text), TextBox6.Text, TextBox7.Text);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestorProfile.aspx");
        }
    }
}