using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.Data.SqlClient;
using System.Data;

namespace dao
{
    public class RegistrationCheckbox
    {
        public List<Skill> registrationCheckboxFill()
        {
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<Skill> dbSkills = new List<Skill>();
            SqlCommand cmd = new SqlCommand("select * from skillset", connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            connect.Close();
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                // sk.Add(dr["skill"].ToString());
                dbSkills.Add(new Skill(long.Parse(dr["skill_id"].ToString()), dr["skill_name"].ToString()));
            }
            return dbSkills;
        }
        public void skillInsert(long trainerId,long skillId)
        {
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<TrainerSkill> dbSkills = new List<TrainerSkill>();
            SqlCommand cmd = new SqlCommand("insert into trainer_skills values(@trainerId,@skillId)", connect);
            cmd.Parameters.AddWithValue("@trainerId", trainerId);
            cmd.Parameters.AddWithValue("@skillId", skillId);
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("insert into trainerAvailability(trainer_Id,enddate,startDate,availability_status) values (@trainerId,GETDATE(),GETDATE(),'Available')", connect);           
            cmd2.Parameters.AddWithValue("@trainerId", trainerId);
            cmd2.ExecuteNonQuery();            
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            
            //connect.Close();
            //DataTable dt = ds.Tables[0];

            //foreach (DataRow dr in dt.Rows)
            //{
            //    // sk.Add(dr["skill"].ToString());
            //    dbSkills.Add(new TrainerSkill(long.Parse(dr["trainer_Id"].ToString()), long.Parse(dr["skillid"].ToString())));
            //}
            //return dbSkills;
        }
        public void smeSkillInsert(long smeId, long skillId)
        {
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<SmeSkill> dbsmeskills = new List<SmeSkill>();
            SqlCommand cmd = new SqlCommand("insert into sme_skills values(@smeId,@skillId)", connect);
            SqlCommand cmd2 = new SqlCommand("insert into smeAvailability(sme_Id,startDate,enddate,availability_status) values (@smeId,GETDATE(),GETDATE(),'Available')", connect);
            cmd2.Parameters.AddWithValue("@smeId", smeId);
            cmd.Parameters.AddWithValue("@smeId", smeId);
            cmd.Parameters.AddWithValue("@skillId", skillId);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
        }
    }
}
