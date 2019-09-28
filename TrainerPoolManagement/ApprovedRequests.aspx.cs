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
    public partial class ApprovedRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Details d = new Details();
                long det = d.requestordet(Session["adminlogin"].ToString());
                RequestManagementDao requestDao = new RequestManagementSql();
                List<model.req> request = new List<model.req>();
                
                request = requestDao.getApprovedRequest(det);
                GridView1.DataSource = request;
                GridView1.DataBind();
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



        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.CommandName == "select")
        //    {
        //        Response.Redirect("RequestCalendarRequestor.aspx");
        //    }
        //}
    }
}