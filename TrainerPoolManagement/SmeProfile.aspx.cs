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
    public partial class SmeProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Details d = new Details();
                long det = d.smedet(Session["adminlogin"].ToString());
                RequestManagementSql smeDetail = new RequestManagementSql();
                model.SME smeDao = new model.SME();
                smeDao = smeDetail.getSme(det);
                Label1.Text = smeDao.SmeId.ToString();
                TextBox1.Text = smeDao.First_name;
                TextBox2.Text = smeDao.Last_name;
                TextBox3.Text = smeDao.Gender;
                TextBox4.Text = smeDao.Age.ToString();
                TextBox5.Text = smeDao.Contact_no.ToString();
                TextBox6.Text = smeDao.EmailId;
                TextBox7.Text = smeDao.Description;


                List<Skill> dbdata = new List<Skill>();
                RegistrationCheckbox checkboxDetails = new RegistrationCheckbox();
                dbdata = checkboxDetails.registrationCheckboxFill();
                foreach (Skill s in dbdata)
                {
                    ListItem item = new ListItem();
                    item.Value = s.SkillId.ToString();
                    item.Text = s.SkillName;
                    CheckBoxList1.Items.Add(item);
                }
                SmeDao sme = new SmeDaoSqlImpl();
                List<Skill> skilllist = new List<Skill>();
                skilllist = sme.getsmeSkillList(det);

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    foreach (Skill a in skilllist)
                    {
                        if (item.Value == a.SkillId.ToString())
                        {
                            item.Selected = true;
                        }
                    }

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SmeHome.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            SmeDao del = new SmeDaoSqlImpl();
            del.deleteSkillsSme(det);
            TrainerDao train = new TrainerDaoSqlImpl();
            del.updatesmedetails(long.Parse(Label1.Text), TextBox1.Text, TextBox2.Text, TextBox3.Text, long.Parse(TextBox4.Text), long.Parse(TextBox5.Text), TextBox6.Text, TextBox7.Text);
            List<SmeSkill> dbcheck = new List<SmeSkill>();
            RegistrationCheckbox registrationCheckbox = new RegistrationCheckbox();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                long skillId = long.Parse(item.Value);
                if (item.Selected)
                {
                    registrationCheckbox.smeSkillInsert(det, skillId);
                }

            }
            Label2.Text = "Profile Edited Succesfully";
            Label2.Visible = true;
        }
    }
}