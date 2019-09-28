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
    public partial class TrainerCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Details det = new Details();
            //List<TrainersmeDetails> trainersmefirstname = new List<TrainersmeDetails>();
            //trainersmefirstname = det.trainersmedetails(long.Parse(Session["requestid"].ToString()));
            //GridView1.DataSource = trainersmefirstname;
            //GridView1.DataBind();


            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            
            List<GetRequest> requestList = new List<GetRequest>();
            TrainerDao requestDao =new TrainerDaoSqlImpl();
            requestList = requestDao.getApprovedRequestTrainer(det);

            GridView1.DataSource = requestList;
            GridView1.DataBind();
    }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            TrainerDao calendar = new TrainerDaoSqlImpl();
            List<model.Calender> trainerCal = new List<model.Calender>();
            trainerCal = calendar.getDatesTrainer(det);
            foreach (var t in trainerCal)
            {
                DateTime date1 = t.StartDate;
                DateTime date2 = t.Enddate;
                string availability = t.Availability_status;
                if (e.Day.Date >= date1 && e.Day.Date <= date2 && availability == "Busy")
                {
         
                    e.Cell.Attributes.Add("onclick", "javascript:alert('Busy')");
                    e.Cell.ForeColor = System.Drawing.Color.DarkRed;

                }
                else
                {
                    e.Cell.Attributes.Add("onclick", "javascript:alert('Free')");
                }
            }


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainerHome.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}