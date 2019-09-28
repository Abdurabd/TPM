using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using model;
using dao;

namespace dao
{
    public class LoginCheck
    {
        // to check the user is already existing or not for trainer/sme/requestor
        public int logincheck(string userid)
        {
            int returncode=1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<Skill> dbSkills = new List<Skill>();
            SqlCommand cmd = new SqlCommand("sp_usercheck", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode; 
        }

        public int loginsmeusercheck(string userid)
        {
            int returncode = 1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<Skill> dbSkills = new List<Skill>();
            SqlCommand cmd = new SqlCommand("sp_smeusercheck", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;

        } 
        public int requestorlogincheck(string userid)
        {
            int returncode = -1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<Skill> dbSkills = new List<Skill>();
            SqlCommand cmd = new SqlCommand("sp_requestorusercheck", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;
        }

        public int logincheckuserid(string userid, string password)
        {
            int returncode=-1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("sp_Traineruseridcheck", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            string encpassword = encrypt(password);
            cmd.Parameters.AddWithValue("@password",encpassword);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;
        }
        public int admincheckuserid(string userid, string password)
        {
            int returncode = -1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("sp_admincheckuserid", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@password", password);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;
        }

        public int requestorcheckuserid(string userid, string password)
        {
            int returncode = -1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("sp_requestorcheckuserid", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            string encpassword = encrypt(password);
            cmd.Parameters.AddWithValue("@password", encpassword);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;
        }

        public int smecheckuserid(string userid, string password)
        {
            int returncode = -1;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("sp_smecheckuserid", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            string encpassword = encrypt(password);
            cmd.Parameters.AddWithValue("@password", encpassword);
            returncode = (int)cmd.ExecuteScalar();
            connect.Close();
            return returncode;

        }
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
