using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using model;
using dao;

namespace TrainerPage
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
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
        }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginCheck login = new LoginCheck();
            if (usertype.Text == "Trainer")
            {
                string log = txtuserid.Text;
                int h=login.logincheck(log);
                if (h != 1)
                {
                    long id = trainers();
                    List<TrainerSkill> dbcheck = new List<TrainerSkill>();
                    RegistrationCheckbox registrationCheckbox = new RegistrationCheckbox();
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        long skillId = long.Parse(item.Value);
                        if (item.Selected)
                        {
                            registrationCheckbox.skillInsert(id, skillId);
                        }
                        Label1.Visible = true;
                        Label1.Text = "Registered successfully";
                        LinkButton1.Visible = true;
                    }
                   
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "username already exists";
                }
            }
            else if (usertype.Text == "SME")
            {
                string log = txtuserid.Text;
                int h = login.loginsmeusercheck(log);
                if (h != 1)
                {
                    long sid = sme();
                    List<SmeSkill> dbsmeskill = new List<SmeSkill>();
                    RegistrationCheckbox registrationcheckbox = new RegistrationCheckbox();
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        long smeskillId = long.Parse(item.Value);
                        if (item.Selected)
                        {
                            registrationcheckbox.smeSkillInsert(sid, smeskillId);
                        }
                        Label1.Visible = true;
                        Label1.Text = "Registered successfully";
                        LinkButton1.Visible = true;
                    }

                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "username already exists";
                }
                
            }
            else
            {
                string log = txtuserid.Text;
                int h = login.requestorlogincheck(log);
                if (h != 1)
                {
                    registrationInsertion regis = new registrationInsertion();
                    Requestor requestorDetails = new Requestor();
                    requestorDetails.First_name = txtfirstname.Text;
                    requestorDetails.Last_name = txtlastname.Text;
                    requestorDetails.Gender = radiogender.Text;
                    requestorDetails.Age = long.Parse(txtage.Text);
                    requestorDetails.Contact_no = long.Parse(txtcontact.Text);
                    requestorDetails.Userid = txtuserid.Text;
                    requestorDetails.Password_user = txtpassword.Text;
                    requestorDetails.UserType = usertype.Text;
                    requestorDetails.EmailId = emailid.Text;
                    requestorDetails.Description = TextBox1.Text;
                    regis.registrationRequestor(requestorDetails);
                    Label1.Visible = true;
                    Label1.Text = "Registered successfully";
                    LinkButton1.Visible = true;

                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "username already exists";
                }
            }

            //else if (usertype.Text == "SME")
            //{
            //    registrationInsertion regis = new registrationInsertion();
            //    Trainer trainerdetails = new Trainer();
            //    trainerdetails.First_name = txtfirstname.Text;
            //    trainerdetails.Last_name = txtlastname.Text;
            //    trainerdetails.Gender = radiogender.Text;
            //    trainerdetails.Age = long.Parse(txtage.Text);
            //    trainerdetails.Contact_no = long.Parse(txtcontact.Text);
            //    trainerdetails.Userid = txtuserid.Text;
            //    trainerdetails.Password_user = txtpassword.Text;
            //    trainerdetails.UserType = usertype.Text;
            //    trainerdetails.EmailId = emailid.Text;
            //    regis.registrationSme(trainerdetails);
            //}
            //else
            //{
            //    
            //}

            
        }

        protected long trainers()
        {
            long tId=0;
            registrationInsertion regis = new registrationInsertion();
            Trainer trainerdetails = new Trainer();
            if (usertype.Text == "Trainer")
            {
                trainerdetails.First_name = txtfirstname.Text;
                trainerdetails.Last_name = txtlastname.Text;
                trainerdetails.Gender = radiogender.Text;
                trainerdetails.Age = long.Parse(txtage.Text);
                trainerdetails.Contact_no = long.Parse(txtcontact.Text);
                trainerdetails.Userid = txtuserid.Text;
                trainerdetails.Password_user = txtpassword.Text;
                trainerdetails.UserType = usertype.Text;
                trainerdetails.EmailId = emailid.Text;
                trainerdetails.Description = TextBox1.Text;
                tId = regis.registrationTrainer(trainerdetails);
            }
            return tId;
        }
        protected long sme()
        {
            long sid = 0;
            registrationInsertion regis = new registrationInsertion();
            SME smedetails = new SME();
            if (usertype.Text == "SME")
            {
                smedetails.First_name = txtfirstname.Text;
                smedetails.Last_name = txtlastname.Text;
                smedetails.Gender = radiogender.Text;
                smedetails.Age = long.Parse(txtage.Text);
                smedetails.Contact_no = long.Parse(txtcontact.Text);
                smedetails.Userid = txtuserid.Text;
                smedetails.Password_user = txtpassword.Text;
                smedetails.UserType = usertype.Text;
                smedetails.EmailId = emailid.Text;
                smedetails.Description = TextBox1.Text;
                sid = regis.registrationSme(smedetails);
            }
            return sid;

        }

        protected void usertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usertype.Text == "Requestor")
            {
                lbl1.Visible = false;
                CheckBoxList1.Visible = false;
            }
            else if (usertype.Text == "Trainer" || usertype.Text == "SME")
            {
                lbl1.Visible = true;
                CheckBoxList1.Visible = true;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}