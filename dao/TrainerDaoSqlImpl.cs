using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dao
{
    public class TrainerDaoSqlImpl : TrainerDao
    {
        public void adminApprovedTrainer(long requestId, long trainerId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(adminApprovedTrainerId) from adminApprovedTrainer  where requestId=@requestid and trainer_Id=@trainerid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                cmd.Parameters.AddWithValue("@trainerid", trainerId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                if (check == 0)
                {
                    connect.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into adminApprovedTrainer values (@trainerid,@requestid)", connect);
                    cmd1.Parameters.AddWithValue("@requestid", requestId);
                    cmd1.Parameters.AddWithValue("@trainerid", trainerId);
                    cmd1.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }

        public void adminRequestingTrainer(long requestId, long trainerId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(adminTrainerReqId) from adminToTrainer  where requestId=@requestid and trainer_Id=@trainerid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                cmd.Parameters.AddWithValue("@trainerid", trainerId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                if (check == 0)
                {
                    connect.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into adminToTrainer values(@requestid,@trainerid)", connect);
                    cmd1.Parameters.AddWithValue("@requestid", requestId);
                    cmd1.Parameters.AddWithValue("@trainerid", trainerId);
                    cmd1.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }


        public List<Trainer> getNameBySearch(string skillname)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Trainer> trainerSearch = new List<Trainer>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer t join trainer_skills ts on t.trainerId=ts.trainer_id join skillset s on ts.skillid=s.skill_id where skill_name=@skill_name", connect);

                cmd.Parameters.AddWithValue("@skill_name", skillname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    // sk.Add(dr["skill"].ToString());
                    trainerSearch.Add(new Trainer((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return trainerSearch;
            }

        }

        public List<Trainer> getSearchByDate(string name,DateTime date1, DateTime date2)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Trainer> trainerSearch = new List<Trainer>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer t join trainerAvailability ts on t.trainerId=ts.trainer_id join trainer_skills tss on t.trainerId = tss.trainer_Id join skillset s on tss.skillid = s.skill_id where ts.startdate <=@date1 and ts.enddate >= @date2 and ts.availability_status = 'Available' and s.skill_name = @skill_name", connect);
                cmd.Parameters.AddWithValue("@skill_name", name);
                cmd.Parameters.AddWithValue("@date1", date1.ToShortDateString());
                cmd.Parameters.AddWithValue("@date2", date2.ToShortDateString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    // sk.Add(dr["skill"].ToString());
                    trainerSearch.Add(new Trainer((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return trainerSearch;
            }

        }

        public List<Skill> getsmeSkillList(long smeid)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                List<Skill> skillList = new List<Skill>();
                connect.Open();

                SqlCommand cmd = new SqlCommand("select * from skillset s join sme_skills t on s.skill_id=t.skillid where t.sme_Id=@smeid", connect);
                cmd.Parameters.AddWithValue("@smeid", smeid);
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

        public List<Trainer> getTrainerListAdmin()
        {
                     
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Trainer> trainerList = new List<Trainer>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    trainerList.Add(new Trainer((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return trainerList;
            }
    }

        public List<Trainer> getTrainerListSuggestionsAdmin(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Trainer> trainerSuggestionsList = new List<Trainer>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer t join trainer_skills ts on t.trainerId=ts.trainer_Id join skillset s on ts.skillid = s.skill_id join request r on s.skill_id = r.skillsubject where r.requestId = @requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    trainerSuggestionsList.Add(new Trainer((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return trainerSuggestionsList;
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


        public List<Trainer> getTrainersNominationList(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Trainer> trainersNominationList = new List<Trainer>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer  t join trainerNomination n on t.trainerId=n.trainer_Id join request r on n.requestId =r.requestId where r.requestId=@requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    trainersNominationList.Add(new Trainer((long.Parse(dr["trainerId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return trainersNominationList;
            }
        }
        public int getTrainerNominationsCount(long trainerId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(trainerNominationId) from trainerNomination  where trainer_Id=@trainerid", connect);
                cmd.Parameters.AddWithValue("@trainerid", trainerId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                return check;
            }
        }

        public List<Calender> getDatesTrainer(long trainerId)
        {
            List<Calender> cal = new List<Calender>();
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getTrainer = new SqlCommand("select * from trainerAvailability where trainer_id = @trainerId", connection);
                getTrainer.Parameters.AddWithValue("@trainerId", trainerId);
                SqlDataReader result = getTrainer.ExecuteReader();
                while (result.Read())
                {
                  cal.Add (new Calender(DateTime.Parse(result["startDate"].ToString()), DateTime.Parse(result["enddate"].ToString()), result["availability_status"].ToString()));

                }
                connection.Close();
            }
            return cal;
        }

        public void deleteSkillsTrainer(long trainerId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                ;
                connect.Open();
                SqlCommand cmd = new SqlCommand("delete from trainer_skills where trainer_Id=@trainerid", connect);
                cmd.Parameters.AddWithValue("@trainerid", trainerId);
                cmd.ExecuteNonQuery();
                connect.Close();

            }
        }
        public void updatetrainerdetails(long trainerId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                connect.Open();
                SqlCommand cmd = new SqlCommand("update trainer set  first_name =@firstname , last_name = @lastname, gender =@Gender, age=@age, contact_no = @contactno, emailId = @emailid,description=@description where trainerId = @trainerid", connect);
                cmd.Parameters.AddWithValue("@trainerid", trainerId);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@contactno", contactno);
                cmd.Parameters.AddWithValue("@emailid", emailid);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }
        public List<GetRequest> getApprovedRequestTrainer(long trainerId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("select * from request r join adminApprovedTrainer at on r.requestId=at.requestId join skillset s on s.skill_id=r.skillsubject where at.trainer_Id=@trainerId order by r.requestId desc", connection);
                requestorList.Parameters.AddWithValue("@trainerId", trainerId);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.GetRequest(long.Parse(results["requestId"].ToString()), results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }




    }
}
