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
    public partial class RequestCalendarAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Details det = new Details();
            model.TrainersmeDetails trainersmefirstname = new model.TrainersmeDetails();
            trainersmefirstname = det.trainersmedetails(long.Parse(Session["requestid"].ToString()));
           
                Label2.Text = trainersmefirstname.RequestId.ToString();
                Label3.Text = trainersmefirstname.TrainerId.ToString();
                Label4.Text = trainersmefirstname.SmeId.ToString();
            
             

            //if (trainersmefirstname.SmeId == null)
            //{
            //    GridView2.Visible = true;
            //    GridView2.DataSource = trainersmefirstname;
            //    GridView2.DataBind();
            //}
            //else if(trainersmefirstname.TrainerId==null)
            //    {
            //    GridView3.Visible = true;
            //    GridView3.DataSource = trainersmefirstname;
            //    GridView3.DataBind();
            //}
            //else
            //{
            //    GridView1.Visible = true;
            //    GridView1.DataSource = trainersmefirstname;
            //    GridView1.DataBind();
            //}


        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            RequestDaoSqlImpl calendar = new RequestDaoSqlImpl();
            List<model.RequestCalendar> trainerCal = new List<model.RequestCalendar>();
            trainerCal = calendar.getrequeststrdateenddate(long.Parse(Session["requestId"].ToString()));
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            FinaliseRequestSqlImpl finaldao = new FinaliseRequestSqlImpl();
            long t = long.Parse(Session["requestId"].ToString());
            finaldao.closingRequest(t);
            Label1.Visible = true;
            Label1.Text = "Request Closed";

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin1.aspx");
        }
    }
              

    }