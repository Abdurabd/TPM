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
    public partial class TrainerShowMoreDetails : System.Web.UI.Page
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
            List<TrainerDetails> trainerDetailsList = new List<TrainerDetails>();
                model.TrainerDetails trainerdao = new model.TrainerDetails();
                MoreDetails moredetails = new MoreDetailsSqlImpl();
                trainerdao = moredetails.getTrainerDetails(long.Parse(Request.QueryString["trainerId"]));
                TextBox1.Text = trainerdao.TrainerId.ToString();
                TextBox2.Text = trainerdao.First_name;
                TextBox3.Text = trainerdao.Last_name;
                TextBox4.Text = trainerdao.Gender;
                TextBox5.Text = trainerdao.Age.ToString();
                TextBox6.Text = trainerdao.Contact_no.ToString();
                TextBox7.Text = trainerdao.EmailId;
                TextBox11.Text = trainerdao.Description;
                TextBox9.Text = trainerdao.StartDate.ToString();
                TextBox10.Text = trainerdao.EndDate.ToString();
                TextBox8.Text = trainerdao.Availability.ToString();

                TrainerDao train = new TrainerDaoSqlImpl();
                List<Trainer> trainer = new List<Trainer>();
                long tid = 0;

                tid = long.Parse(Request.QueryString["trainerId"]);
                List<Skill> skillList = new List<Skill>();
                skillList = train.getTrainerSkillList(tid);

                if (skillList.Count == 0)
                {
                    DropDownList1.Items.Add("No Skills");
                }
                else
                {
                    DropDownList1.DataSource = skillList;
                    DropDownList1.DataTextField = "SkillName";
                    DropDownList1.DataValueField = "SkillId";
                    DropDownList1.DataBind();
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