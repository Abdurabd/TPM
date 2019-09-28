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
    public partial class TrainerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                bindgrid1();
                bindgrid2();
                string name = Session["adminlogin"].ToString();
                Label3.Text = name;
            }
        }
        public void bindgrid1()
        {       Details d = new Details();
                long det = d.trainerdet(Session["adminlogin"].ToString());   
                RequestManagementDao requestDao = new RequestManagementSql();
                List<model.GetRequest> requestorRequest = new List<model.GetRequest>();
                requestorRequest = requestDao.getRequest();
                GridView1.DataSource = requestorRequest;
                GridView1.DataBind();
        }
        public void bindgrid2()
        {
            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            RequestManagementDao request = new RequestManagementSql();
            List<model.GetRequest> trainerRequest = new List<model.GetRequest>();
            trainerRequest = request.getTrainerRequest(det);
            GridView2.DataSource = trainerRequest;
            GridView2.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            if (e.CommandName == "Select")
            {
                TrainerDao trainerNomCount = new TrainerDaoSqlImpl();
                int check = trainerNomCount.getTrainerNominationsCount(det);
                if (check<3)
                {
                    int rowindex = Int32.Parse(e.CommandArgument.ToString());
                    GridViewRow row = GridView1.Rows[rowindex];
                    long requestId = long.Parse(row.Cells[0].Text);
                    RequestManagementDao addNomination = new RequestManagementSql();
                    addNomination.addNomination(requestId, det);
                    bindgrid1();
                    Label5.Visible = true;
                    Label5.Text = "Nominated Successfully";

                }
                else
                {
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "You already nominated for 3 requests. Please wait for Admin Action";
                    //Label3.Visible = false;
                  
                }
            }

        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            if (e.CommandName == "Select")
            {
                TrainerDao trainerNomCount = new TrainerDaoSqlImpl();
                int check = trainerNomCount.getTrainerNominationsCount(det);
                if (check<3)
                {
                    int rowindex = Int32.Parse(e.CommandArgument.ToString());
                    GridViewRow row = GridView2.Rows[rowindex];
                    long requestId = long.Parse(row.Cells[0].Text);
                    RequestManagementDao addNomination = new RequestManagementSql();
                    addNomination.addNomination(requestId, det);
                    bindgrid2();
                    Label4.Visible = true;

                    Label4.Text = "Requested Accepted";
                }
                else
                {
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "You already nominated for 3 requests. Please wait for Admin Action";
                    Label2.Visible = false;
                    //Label3.Visible = false;
                   
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("TrainerCalendar.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}