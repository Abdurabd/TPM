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
    public partial class SMELists_InAdmin_ : System.Web.UI.Page
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
            List<SME> smeList = new List<SME>();
            SmeDao smedao = new SmeDaoSqlImpl();
            smeList = smedao.getSmeListAdmin();
            GridView1.DataSource = smeList;
            GridView1.DataBind();
        }
        //public void searchData()
        //{
        //    List<SME> searchList = new List<SME>();
        //    SmeDao smedao = new SmeDaoSqlImpl();
        //    string name = DropDownList2.SelectedValue;
        //    searchList = smedao.getNameBySearch(name);
        //    GridView1.DataSource = searchList;
        //    GridView1.DataBind();
        //}

        public void searchDataByDate()
        {

            List<SME> searchList = new List<SME>();
            SmeDao smedao = new SmeDaoSqlImpl();
            DateTime date1 = DateTime.Parse(TextBox1.Text);
            DateTime date2 = DateTime.Parse(TextBox2.Text);
            string name = DropDownList2.SelectedValue;
            searchList = smedao.getSearchByDate(name,date1, date2);
            GridView1.DataSource = searchList;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SmeDao sme = new SmeDaoSqlImpl();
            List<SME> trainer = new List<SME>();
            // trainer = trainerdao.getTrainerListAdmin();
            long smeid = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                smeid = long.Parse(e.Row.Cells[0].Text.ToString());
                //string h = e.Row.Cells[0].Text;
                DropDownList ddl = (e.Row.FindControl("DropDownList1") as DropDownList);
                List<Skill> skillList = new List<Skill>();
                skillList = sme.getsmeSkillList(smeid);

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

       

        protected void Button2_Click(object sender, EventArgs e)
        {
            searchDataByDate();
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