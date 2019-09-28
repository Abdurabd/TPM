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
    public partial class TrainerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            if (!IsPostBack)
            {
                RequestManagementSql trainerDetail = new RequestManagementSql();
                model.Trainer trainerDao = new model.Trainer();
                trainerDao = trainerDetail.getTrainer(det);
                Label1.Text = trainerDao.TrainerId.ToString();
                TextBox1.Text = trainerDao.First_name;
                TextBox2.Text = trainerDao.Last_name;
                TextBox3.Text = trainerDao.Gender;
                TextBox4.Text = trainerDao.Age.ToString();
                TextBox5.Text = trainerDao.Contact_no.ToString();
                TextBox6.Text = trainerDao.EmailId;
                TextBox7.Text = trainerDao.Description;

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
                TrainerDao train = new TrainerDaoSqlImpl();
                List<Skill> skilllist = new List<Skill>();
                skilllist = train.getTrainerSkillList(det);

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    foreach (Skill a in skilllist)
                    {
                        if (item.Value==a.SkillId.ToString())
                        {
                            item.Selected = true;
                        }
                    }

                }




            //        foreach (Skill a in skilllist)
            //    {

            //        //for (int i = 0; i < skilllist.Count; i++)
            //        //{
            //            if (a.SkillId == 1)
            //            {
            //                CheckBoxList1.Items[i].Selected = true;
            //            }
            //            else if (a.SkillId == 2)
            //            {
            //                CheckBoxList1.Items[i].Selected = true;
            //            }
            //            else if (a.SkillId == 3)
            //            {
            //                CheckBoxList1.Items[i].Selected = true;
            //            }
            //            else if (a.SkillId == 4)
            //            {
            //                CheckBoxList1.Items[i].Selected = true;
            //            }
            //        //}
            //}

        }
    }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainerHome.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TrainerHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Details d = new Details();
            long det = d.trainerdet(Session["adminlogin"].ToString());
            TrainerDao del = new TrainerDaoSqlImpl();
            del.deleteSkillsTrainer(det);
            TrainerDao train = new TrainerDaoSqlImpl();
            del.updatetrainerdetails(long.Parse(Label1.Text), TextBox1.Text, TextBox2.Text, TextBox3.Text, long.Parse(TextBox4.Text), long.Parse(TextBox5.Text), TextBox6.Text, TextBox7.Text);
            List<TrainerSkill> dbcheck = new List<TrainerSkill>();
            RegistrationCheckbox registrationCheckbox = new RegistrationCheckbox();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                long skillId = long.Parse(item.Value);
                if (item.Selected)
                {
                    registrationCheckbox.skillInsert(det, skillId);
                }
            
            }
            Label2.Text = "Profile Edited Succesfully";
            Label2.Visible = true;
        }
    }
}