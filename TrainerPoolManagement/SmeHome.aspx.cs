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
    public partial class SmeHome : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
                bindgrid2();
                string name = Session["adminlogin"].ToString();
                Label6.Text = name;
            }
        }

        public void bindgrid()
        {
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            RequestManagementDao requestDao = new RequestManagementSql();
            List<model.GetRequest> requestorRequest = new List<model.GetRequest>();
            requestorRequest = requestDao.getRequestsme();
            GridView1.DataSource = requestorRequest;
            GridView1.DataBind();
        }
        public void bindgrid2()
        {
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            RequestManagementDao request = new RequestManagementSql();
            List<model.GetRequest> smeRequest = new List<model.GetRequest>();
            smeRequest = request.getSmeRequest(det);
            GridView2.DataSource = smeRequest;
            GridView2.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            if (e.CommandName == "Select")
            {
                if (e.CommandName == "Select")
                {
                    SmeDao smeNomCount = new SmeDaoSqlImpl();
                    int check = smeNomCount.getSmeNominationsCount(det);
                    if (check < 3)
                    {
                        int rowindex = Int32.Parse(e.CommandArgument.ToString());
                        GridViewRow row = GridView1.Rows[rowindex];
                        long requestId = long.Parse(row.Cells[0].Text);
                        RequestManagementDao addNomination = new RequestManagementSql();
                        addNomination.addSmeNomination(requestId, det);
                        bindgrid();
                        LinkButton btnnominate = row.FindControl("LinkButton1") as LinkButton;
                        btnnominate.Enabled = false;
                        //TextBox myTextBox = row.FindControl("MyTextBoxId") as TextBox;
                        Label5.Visible = true;
                        Label5.Text = "Nominated Successfully";
                    }
                    else
                    {
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        Label1.Visible = true;
                        Label1.Text = "You already nominated for 3 requests. Please wait for Admin Action";
                        Label2.Visible = false;
                        Label3.Visible = false;
                        
                    }
                }
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            if (e.CommandName == "Select")
            {
                SmeDao smeNomCount = new SmeDaoSqlImpl();
                int check = smeNomCount.getSmeNominationsCount(det);
                if (check < 3)
                {
                    int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView2.Rows[rowindex];
                long requestId = long.Parse(row.Cells[0].Text);
                RequestManagementDao addNomination = new RequestManagementSql();
                addNomination.addSmeNomination(requestId,det);
                    bindgrid2();
                    Label4.Visible = true;
                    Label4.Text = "Request Accepted";
                }
                else
                {
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    Label1.Text = "You already nominated for 3 requests. Please wait for Admin Action";
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label1.Visible = true;
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
           
            Response.Redirect("SmeCalendar.aspx");
        }
    }
}