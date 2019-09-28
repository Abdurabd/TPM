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
    public partial class Myrequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack)
            {
                Details d = new Details();
                long det = d.requestordet(Session["adminlogin"].ToString());
                RequestManagementDao requestDao = new RequestManagementSql();
                List<model.req> request = new List<model.req>();
                request = requestDao.getRequest(det);
                GridView1.DataSource = request;
                GridView1.DataBind();
            }

        }
    }
}