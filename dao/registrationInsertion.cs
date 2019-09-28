using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using model;
using dao;

namespace dao
{
    public class registrationInsertion
    {
        public long registrationTrainer(Trainer regisInsert)
        {
            long tid = 0;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into trainer values (@First_name,@Last_name,@gender,@contact_no,@age,@userid,@password_user,@userType,@emailId,@description)", connect);
            SqlCommand cmd1 = new SqlCommand("select * from trainer where userid=@userID", connect);
           
            cmd1.Parameters.AddWithValue("@userID", regisInsert.Userid);
            cmd.Parameters.AddWithValue("@First_name", regisInsert.First_name);
            cmd.Parameters.AddWithValue("@Last_name", regisInsert.Last_name);
            cmd.Parameters.AddWithValue("@gender", regisInsert.Gender);
            cmd.Parameters.AddWithValue("@contact_no", regisInsert.Contact_no);
            cmd.Parameters.AddWithValue("@age", regisInsert.Age);
            cmd.Parameters.AddWithValue("@userid", regisInsert.Userid);
            string encpassword = encrypt(regisInsert.Password_user);
            cmd.Parameters.AddWithValue("@password_user", encpassword);
            cmd.Parameters.AddWithValue("@userType", regisInsert.UserType);
            cmd.Parameters.AddWithValue("@emailId", regisInsert.EmailId);
            cmd.Parameters.AddWithValue("@description", regisInsert.Description);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd1.ExecuteReader();
            
            while (dr.Read())
            {
                tid = long.Parse(dr["trainerId"].ToString());
            }
            connect.Close();
            return tid;
        }
        public long registrationSme(SME regisInsert)
        {
            long sid = 0;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into sme values (@First_name,@Last_name,@gender,@contact_no,@age,@userid,@password,@userType,@emailId,@description)", connect);
            SqlCommand cmd2 = new SqlCommand("select * from sme where userid=@userID",connect);
            cmd2.Parameters.AddWithValue("@userID", regisInsert.Userid);
            cmd.Parameters.AddWithValue("@First_name", regisInsert.First_name);
            cmd.Parameters.AddWithValue("@Last_name", regisInsert.Last_name);
            cmd.Parameters.AddWithValue("@gender", regisInsert.Gender);
            cmd.Parameters.AddWithValue("@contact_no", regisInsert.Contact_no);
            cmd.Parameters.AddWithValue("@age", regisInsert.Age);
            cmd.Parameters.AddWithValue("@userid", regisInsert.Userid);
            string encpassword = encrypt(regisInsert.Password_user);
            cmd.Parameters.AddWithValue("@password", encpassword);
            cmd.Parameters.AddWithValue("@userType", regisInsert.UserType);
            cmd.Parameters.AddWithValue("@emailId", regisInsert.EmailId);
            cmd.Parameters.AddWithValue("@description",regisInsert.Description);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                sid = long.Parse(dr["smeId"].ToString());
            }
            connect.Close();
            return sid;

        }
        public void registrationRequestor(Requestor regisInsert)
        {
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            if (regisInsert.Description == "")
            {
                regisInsert.Description = "No Description provided";
                SqlCommand cmd = new SqlCommand("insert into requestor values (@First_name,@Last_name,@gender,@contact_no,@age,@userid,@password,@userType,@emailId,@description)", connect);
                cmd.Parameters.AddWithValue("@First_name", regisInsert.First_name);
                cmd.Parameters.AddWithValue("@Last_name", regisInsert.Last_name);
                cmd.Parameters.AddWithValue("@gender", regisInsert.Gender);
                cmd.Parameters.AddWithValue("@contact_no", regisInsert.Contact_no);
                cmd.Parameters.AddWithValue("@age", regisInsert.Age);
                cmd.Parameters.AddWithValue("@userid", regisInsert.Userid);
                string encpassword = encrypt(regisInsert.Password_user);
                cmd.Parameters.AddWithValue("@password", encpassword);
                cmd.Parameters.AddWithValue("@userType", regisInsert.UserType);
                cmd.Parameters.AddWithValue("@emailId", regisInsert.EmailId);

                cmd.Parameters.AddWithValue("@description", regisInsert.Description);
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into requestor values (@First_name,@Last_name,@gender,@contact_no,@age,@userid,@password,@userType,@emailId,@description)", connect);
                cmd.Parameters.AddWithValue("@First_name", regisInsert.First_name);
                cmd.Parameters.AddWithValue("@Last_name", regisInsert.Last_name);
                cmd.Parameters.AddWithValue("@gender", regisInsert.Gender);
                cmd.Parameters.AddWithValue("@contact_no", regisInsert.Contact_no);
                cmd.Parameters.AddWithValue("@age", regisInsert.Age);
                cmd.Parameters.AddWithValue("@userid", regisInsert.Userid);
                string encpassword = encrypt(regisInsert.Password_user);
                cmd.Parameters.AddWithValue("@password", encpassword);
                cmd.Parameters.AddWithValue("@userType", regisInsert.UserType);
                cmd.Parameters.AddWithValue("@emailId", regisInsert.EmailId);

                cmd.Parameters.AddWithValue("@description", regisInsert.Description);
                cmd.ExecuteNonQuery();

            }
            connect.Close();
        }
        //public void TrainerSkill( regisInsert)
        //{
        //    SqlConnection connect = ConnectionHandler.getConnection();
        //    connect.Open();
        //    SqlCommand cmd = new SqlCommand("insert into requestor values (@First_name,@Last_name,@gender,@contact_no,@age,@userid,@password,@userType,@emailId)", connect);
        //    cmd.Parameters.AddWithValue("@First_name", regisInsert.First_name);
        //    cmd.Parameters.AddWithValue("@Last_name", regisInsert.Last_name);
        //    cmd.Parameters.AddWithValue("@gender", regisInsert.Gender);
        //    cmd.Parameters.AddWithValue("@contatc_no", regisInsert.Contact_no);
        //    cmd.Parameters.AddWithValue("@age", regisInsert.Age);
        //    cmd.Parameters.AddWithValue("@userid", regisInsert.Userid);
        //    cmd.Parameters.AddWithValue("@password", regisInsert.Password_user);
        //    cmd.Parameters.AddWithValue("@userType", regisInsert.UserType);
        //    cmd.Parameters.AddWithValue("@emailId", regisInsert.EmailId);
        //    connect.Close();

        //}
        public string encrypt(string password)
        {
            string s = string.Empty;
            byte[] encodebyte = new byte[password.Length];
            encodebyte = Encoding.UTF8.GetBytes(password);
            s = Convert.ToBase64String(encodebyte);
            return s;
        }

    }
}
