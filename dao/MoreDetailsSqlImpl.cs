using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dao;
using model;

namespace dao
{
    public class MoreDetailsSqlImpl:MoreDetails
    {
        public TrainerDetails getTrainerDetails(long trainerid)
        {
            TrainerDetails tDetails = null;
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<TrainerDetails> trainerDetailsList = new List<TrainerDetails>();

                connect.Open();
                SqlCommand cmd = new SqlCommand("select  * from trainer ta join trainerAvailability t on ta.trainerId=t.trainer_Id where trainer_Id=@trainerId ", connect);
                cmd.Parameters.AddWithValue("@trainerId", trainerid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                     tDetails = new TrainerDetails((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["emailId"].ToString(),dr["description"].ToString(), dr["availability_status"].ToString(),DateTime.Parse(dr["startDate"].ToString()),DateTime.Parse(dr["enddate"].ToString()));
                }
                return tDetails;
            }
        }

        public List<Skill> getTrainerSkillList(long trainerid)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                List<Skill> skillList = new List<Skill>();
                connect.Open();

                SqlCommand cmd = new SqlCommand("select * from skillset s join trainer_skills t on s.skill_id=t.skillid where t.trainer_Id=@trainerid", connect);
                cmd.Parameters.AddWithValue("@trainerid", trainerid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    // sk.Add(dr["skill"].ToString());
                    Skill s = new Skill(long.Parse(dr["skill_id"].ToString()), dr["skill_name"].ToString());
                    skillList.Add(s);
                }
                return skillList;
            }
        }
        public SmeDetails getSmeDetails(long smeid)
        {
            SmeDetails sDetails = null;
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SmeDetails> smeDetailsList = new List<SmeDetails>();

                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from sme s join smeAvailability sa on sa.sme_Id=s.smeId where smeId=@smeId ", connect);
                cmd.Parameters.AddWithValue("@smeId", smeid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    sDetails = new SmeDetails((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["emailId"].ToString(),dr["description"].ToString(), DateTime.Parse(dr["startdate"].ToString()), DateTime.Parse(dr["enddate"].ToString()), dr["availability_status"].ToString());
                }
                return sDetails;
            }
        }


    }
}
