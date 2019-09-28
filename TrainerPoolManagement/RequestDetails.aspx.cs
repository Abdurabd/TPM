using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dao;
using model;


namespace Trainingpool
{
    public partial class RequestDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                BindDataTrainersNominations();
                BindDataTrainerSuggestions();
                BindDataSmeNominations();
                BindDataSmeSuggestions();
                BindDataRequest();
            
            
        }
        public void BindDataTrainersNominations()
        {

            List<Trainer> trainersNominationList = new List<Trainer>();
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            trainersNominationList = trainerdao.getTrainersNominationList(long.Parse(Request.QueryString["requestId"]));

            GridView1.DataSource = trainersNominationList;
            GridView1.DataBind();
        }

        public void BindDataTrainerSuggestions()
        {

            List<Trainer> trainersNominationList = new List<Trainer>();
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            trainersNominationList = trainerdao.getTrainerListSuggestionsAdmin(long.Parse(Request.QueryString["requestId"]));
            GridView2.DataSource = trainersNominationList;
            GridView2.DataBind();
        }
        public void BindDataSmeNominations()
        {

            List<SME> trainersNominationList = new List<SME>();
            SmeDao smedao = new SmeDaoSqlImpl();
            trainersNominationList = smedao.getSmeNominationList(long.Parse(Request.QueryString["requestId"]));

            GridView3.DataSource = trainersNominationList;
            GridView3.DataBind();
        }
        public void BindDataSmeSuggestions()
        {

            List<SME> smeNominationList = new List<SME>();
            SmeDao smedao = new SmeDaoSqlImpl();
            smeNominationList = smedao.getSmeListSuggestionsAdmin(long.Parse(Request.QueryString["requestId"]));
            GridView4.DataSource = smeNominationList;
            GridView4.DataBind();
        }
        public void BindDataRequest()
        {
            List<Requests> requestList = new List<Requests>();
            RequestDaoSqlImpl requestDao = new RequestDaoSqlImpl();
            requestList = requestDao.getRequestList(long.Parse(Request.QueryString["requestId"]));

            GridView5.DataSource = requestList;
            GridView5.DataBind();
            
        }

      

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView4.Rows[rowindex];
                long smeid = long.Parse(row.Cells[0].Text);
                long reqId = long.Parse(Request.QueryString["requestId"]);
                SmeDao smedao = new SmeDaoSqlImpl();
                smedao.adminRequestingSme(reqId, smeid);
                Label5.Visible = true;
                Label5.Text = "Request sent";

            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView2.Rows[rowindex];
                long trainerid = long.Parse(row.Cells[0].Text);
                long reqId = long.Parse(Request.QueryString["requestId"]);
                TrainerDao trainerdao = new TrainerDaoSqlImpl();
                trainerdao.adminRequestingTrainer(reqId, trainerid);
                Label4.Visible = true;
                Label4.Text = "Request Sent";

            }
        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView3.Rows[rowindex];
                long smeid = long.Parse(row.Cells[0].Text);
                long reqId = long.Parse(Request.QueryString["requestId"]);
                RequestManagementDao calendar = new RequestManagementSql();
                List<model.Calender> trainerCal = new List<model.Calender>();
                trainerCal = calendar.getDatesRequest(reqId);
                foreach (var t in trainerCal)
                {
                    DateTime date1 = t.StartDate;
                    DateTime date2 = t.Enddate;
                    RequestManagementSql request = new RequestManagementSql();
                    //long trainerid = long.Parse(row.Cells[0].Text);
                    string status = "Busy";
                   
                    request.addSmeAvailability(smeid, date1, date2, status);
                    SmeDao smedao = new SmeDaoSqlImpl();
                    smedao.adminApprovedSme(reqId, smeid);
                    Label3.Visible = true;
                    Label3.Text = "Approved SME";
                    Label1.Visible = true;
                    GridView3.Visible = false;
                    GridView5.Visible = true;

                }

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView1.Rows[rowindex];
                long trainerid = long.Parse(row.Cells[0].Text);
                long reqId = long.Parse(Request.QueryString["requestId"]);
                RequestManagementDao calendar = new RequestManagementSql();
                List<model.Calender> trainerCal = new List<model.Calender>();
                trainerCal = calendar.getDatesRequest(reqId);
                foreach (var t in trainerCal)
                {
                    DateTime date1 = t.StartDate;
                    DateTime date2 = t.Enddate;
                    RequestManagementSql request = new RequestManagementSql();
                    //long trainerid = long.Parse(row.Cells[0].Text);
                    string status = "Busy";
                    request.addAvailability(trainerid, date1, date2, status);
                    TrainerDao trainerdao = new TrainerDaoSqlImpl();
                    trainerdao.adminApprovedTrainer(reqId, trainerid);
                    Label2.Visible = true;
                    Label2.Text = "Approved Trainer";
                    Label1.Visible = true;
                    GridView1.Visible = false;
                    GridView5.Visible = true;

                }
                
            }
        }
        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
         
                int rowindex = Int32.Parse(e.CommandArgument.ToString());
                GridViewRow row = GridView5.Rows[rowindex];
                long reqId = long.Parse(row.Cells[1].Text);
                Session["requestId"] = reqId;

                Response.Redirect("RequestCalendarAdmin.aspx");
                //long reqId = long.Parse(Request.QueryString["requestId"]);
                FinaliseRequestSqlImpl finaldao = new FinaliseRequestSqlImpl();
                //Response.Redirect("TrainerCalendar.aspx");
                //finaldao.adminFinalisingRequest(reqId);
                //finaldao.closingRequest(reqId);
                //Response.Redirect("FinaliseRequest.aspx?requestId={1}");
            }
        }
      

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            List<RequestDetails> trainer = new List<RequestDetails>();
            long tid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tid = long.Parse(e.Row.Cells[0].Text.ToString());
                DropDownList ddl = (e.Row.FindControl("DropDownList1") as DropDownList);
                List<Skill> skillList = new List<Skill>();
                skillList = trainerdao.getTrainerSkillList(tid);
                if (skillList.Count == 0)
                {
                    ddl.Items.Add("No Skills");
                }
                else
                {
                    ddl.DataSource = skillList;
                    ddl.DataTextField = "SkillName";
                    ddl.DataValueField = "SkillId";
                    ddl.DataBind();
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            List<RequestDetails> trainer = new List<RequestDetails>();
            long tid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tid = long.Parse(e.Row.Cells[0].Text.ToString());
                DropDownList ddl = (e.Row.FindControl("DropDownList2") as DropDownList);
                List<Skill> skillList = new List<Skill>();
                skillList = trainerdao.getTrainerSkillList(tid);
                if (skillList.Count == 0)
                {
                    ddl.Items.Add("No Skills");
                }
                else
                {
                    ddl.DataSource = skillList;
                    ddl.DataTextField = "SkillName";
                    ddl.DataValueField = "SkillId";
                    ddl.DataBind();
                }
            }

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            List<RequestDetails> trainer = new List<RequestDetails>();
            long smeid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                smeid = long.Parse(e.Row.Cells[0].Text.ToString());
                DropDownList ddl = (e.Row.FindControl("DropDownList3") as DropDownList);
                List<Skill> skillList = new List<Skill>();
                skillList = trainerdao.getsmeSkillList(smeid);
                if (skillList.Count == 0)
                {
                    ddl.Items.Add("No Skills");
                }
                else
                {
                    ddl.DataSource = skillList;
                    ddl.DataTextField = "SkillName";
                    ddl.DataValueField = "SkillId";
                    ddl.DataBind();
                }
            }

        }

       

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            List<RequestDetails> trainer = new List<RequestDetails>();
            long smeid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                smeid = long.Parse(e.Row.Cells[0].Text.ToString());
                DropDownList ddl = (e.Row.FindControl("DropDownList4") as DropDownList);
                List<Skill> skillList = new List<Skill>();
                skillList = trainerdao.getsmeSkillList(smeid);
                if (skillList.Count == 0)
                {
                    ddl.Items.Add("No Skills");
                }
                else
                {
                    ddl.DataSource = skillList;
                    ddl.DataTextField = "SkillName";
                    ddl.DataValueField = "SkillId";
                    ddl.DataBind();
                }
            }

        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin1.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}