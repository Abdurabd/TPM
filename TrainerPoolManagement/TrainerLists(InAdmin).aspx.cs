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
    public partial class TrainerLists_InAdmin_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {

            List<Trainer> trainerList = new List<Trainer>();
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            trainerList = trainerdao.getTrainerListAdmin();
            GridView1.DataSource = trainerList;
            GridView1.DataBind();
        }
        //public void searchData()
        //{
        //    List<Trainer> searchList = new List<Trainer>();
        //    TrainerDao trainerdao = new TrainerDaoSqlImpl();
        //    string name = DropDownList2.SelectedValue;
        //    searchList = trainerdao.getNameBySearch(name);
        //    GridView1.DataSource = searchList;
        //    GridView1.DataBind();
        //}
        public void searchDataByDate()
        {
            List<Trainer> searchList = new List<Trainer>();
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            DateTime date1 = DateTime.Parse(TextBox1.Text);
            DateTime date2 = DateTime.Parse(TextBox2.Text);
            string name = DropDownList2.SelectedValue;
            searchList = trainerdao.getSearchByDate(name,date1, date2);
            GridView1.DataSource = searchList;
            GridView1.DataBind();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            searchDataByDate();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TrainerDao trainerdao = new TrainerDaoSqlImpl();
            List<Trainer> trainer = new List<Trainer>();
            // trainer = trainerdao.getTrainerListAdmin();
            long tid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tid = long.Parse(e.Row.Cells[0].Text.ToString());
                //string h = e.Row.Cells[0].Text;
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