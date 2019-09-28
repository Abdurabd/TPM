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
    public partial class RequestCalenderRequestor : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            Details det = new Details();
            model.TrainersmeDetails trainersmefirstname = new model.TrainersmeDetails();
            long reqId = long.Parse(Request.QueryString["requestId"]);
            trainersmefirstname = det.trainersmedetails(reqId);

            Label2.Text = trainersmefirstname.RequestId.ToString();
            Label3.Text = trainersmefirstname.TrainerId.ToString();
            Label4.Text = trainersmefirstname.SmeId.ToString();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            RequestDaoSqlImpl calendar = new RequestDaoSqlImpl();
            List<model.RequestCalendar> trainerCal = new List<model.RequestCalendar>();
            long reqId = long.Parse(Request.QueryString["requestId"]);
            trainerCal = calendar.getrequeststrdateenddate(reqId);
            foreach (var t in trainerCal)
            {
                DateTime date1 = t.Startdate;
                DateTime date2 = t.Enddate;

                if (e.Day.Date >= date1 && e.Day.Date <= date2)
                {

                    e.Cell.Attributes.Add("onclick", "javascript:alert('Busy')");
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Cell.Attributes.Add("onclick", "javascript:alert('Free')");
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestorHome.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
   

    }
