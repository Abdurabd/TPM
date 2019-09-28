using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model;
using dao;

namespace TrainerPage
{
    public partial class SMEShowMoreDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData()
        {
            List<SmeDetails> smeDetailsList = new List<SmeDetails>();
                model.SmeDetails smedao = new model.SmeDetails();
                MoreDetails moredetails = new MoreDetailsSqlImpl();
                smedao = moredetails.getSmeDetails(long.Parse(Request.QueryString["smeId"]));
            TextBox1.Text = smedao.SmeId.ToString();
                TextBox2.Text = smedao.First_name;
                TextBox3.Text = smedao.Last_name;
                TextBox4.Text = smedao.Gender;
                TextBox5.Text = smedao.Age.ToString();
                TextBox6.Text = smedao.Contact_no.ToString();
                TextBox7.Text = smedao.EmailId;
                TextBox11.Text = smedao.Description;
                TextBox9.Text = smedao.StartDate.ToString();
                TextBox10.Text = smedao.EndDate.ToString();
                TextBox8.Text = smedao.Availability.ToString();
                SmeDao sme = new SmeDaoSqlImpl();
                List<SME> trainer = new List<SME>();
                // trainer = trainerdao.getTrainerListAdmin();
                long smeid = long.Parse(Request.QueryString["smeid"]);
                List<Skill> skillList = new List<Skill>();
                skillList = sme.getsmeSkillList(smeid);

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