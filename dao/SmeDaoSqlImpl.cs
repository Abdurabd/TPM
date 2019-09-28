using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using model;

namespace dao
{
    public class SmeDaoSqlImpl : SmeDao
    {
        public void adminApprovedSme(long requestId, long smeId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(adminApprovedSmeId) from adminApprovedSme  where requestId=@requestid and smeid=@smeid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                cmd.Parameters.AddWithValue("@smeid", smeId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                if (check == 0)
                {
                    connect.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into adminApprovedSme values (@smeid,@requestid)", connect);
                     cmd1.Parameters.AddWithValue("@requestid", requestId);
                    cmd1.Parameters.AddWithValue("@smeid", smeId);
                    cmd1.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }


        public void adminRequestingSme(long requestId, long smeId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(adminSmeReqId) from adminToSme  where requestId=@requestid and sme_Id=@smeid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                cmd.Parameters.AddWithValue("@smeid", smeId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                if (check == 0)
                {
                    connect.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into adminToSme values (@requestid,@smeid)", connect);
                    cmd1.Parameters.AddWithValue("@requestid", requestId);
                    cmd1.Parameters.AddWithValue("@smeid", smeId);
                    cmd1.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }


        public List<SME> getNameBySearch(string skillname)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SME> smeSearch = new List<SME>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from sme  st join sme_skills ts on st.smeId=ts.sme_Id join skillset s on ts.skillid=s.skill_id where skill_name=@skill_name", connect);

                cmd.Parameters.AddWithValue("@skill_name", skillname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    smeSearch.Add(new SME((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return smeSearch;
            }
        }


        public List<SME> getSearchByDate(string name,DateTime date1, DateTime date2)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SME> smeSearch = new List<SME>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from trainer t join trainerAvailability ts on t.trainerId = ts.trainer_id join trainer_skills tss on t.trainerId = tss.trainer_Id join skillset s on tss.skillid = s.skill_id where ts.startDate <= @date1 and ts.enddate >= @date2 and ts.availability_status = 'Available' and s.skill_name = @skill_name", connect);
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
                    smeSearch.Add(new SME((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(),dr["description"].ToString()));
                }
                return smeSearch;
            }

        }

        public List<SME> getSmeListAdmin()
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SME> smeList = new List<SME>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from sme ", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    smeList.Add(new SME((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(), dr["description"].ToString()));
                }
                return smeList;
            }
        }


        public List<SME> getSmeListSuggestionsAdmin(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SME> smeSuggestionsList = new List<SME>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from sme t join sme_skills ts on t.smeId=ts.sme_Id join skillset s on ts.skillid = s.skill_id join request r on s.skill_id = r.skillsubject where r.requestId = @requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    smeSuggestionsList.Add(new SME((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(), dr["description"].ToString()));
                }
                return smeSuggestionsList;
            }
        }


        public List<SME> getSmeNominationList(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<SME> smeNominationList = new List<SME>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from sme  t join smeNomination n on t.smeId=n.sme_Id join request r on n.requestId =r.requestId where r.requestId=@requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    smeNominationList.Add(new SME((long.Parse(dr["smeId"].ToString())), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["gender"].ToString(), long.Parse(dr["contact_no"].ToString()), long.Parse(dr["age"].ToString()), dr["userid"].ToString(), dr["password_user"].ToString(), dr["userType"].ToString(), dr["emailId"].ToString(), dr["description"].ToString()));
                }
                return smeNominationList;
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


        public List<Skill> getSmeSkillList(int smeid)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                List<Skill> skillList = new List<Skill>();
                connect.Open();
                skillList = null;
                SqlCommand cmd = new SqlCommand("select * from skillset s join sme_skills ss on s.skill_id=ss.skillid where ss.sme_Id=@smeId ", connect);
                cmd.Parameters.AddWithValue("@smeId", smeid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connect.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    skillList.Add(new Skill(long.Parse(dr["skill_id"].ToString()), dr["skill_name"].ToString()));
                }
                return skillList;
            }
        }

        public int getSmeNominationsCount(long smeId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(smeNominationId) from smeNomination  where sme_Id=@smeid", connect);
                cmd.Parameters.AddWithValue("@smeid", smeId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                return check;
            }
        }

        public List<Calender> getDatesSme(long smeId)
        {
            List<Calender> cal = new List<Calender>();
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getTrainer = new SqlCommand("select * from smeAvailability where sme_Id  = @smeId", connection);
                getTrainer.Parameters.AddWithValue("@smeId", smeId);
                SqlDataReader result = getTrainer.ExecuteReader();
                while (result.Read())
                {
                    cal.Add(new Calender(DateTime.Parse(result["startDate"].ToString()), DateTime.Parse(result["enddate"].ToString()), result["availability_status"].ToString()));

                }
                connection.Close();
            }
            return cal;
        }
        public List<GetRequest> getApprovedRequestsme(long smeId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("select * from request r join adminApprovedSme at on r.requestId=at.requestId join skillset s on s.skill_id=r.skillsubject where at.smeid=@smeId order by r.requestId desc", connection);
                requestorList.Parameters.AddWithValue("@smeId", smeId);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.GetRequest(long.Parse(results["requestId"].ToString()), results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }
        public void updatesmedetails(long smeId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {

                connect.Open();
                SqlCommand cmd = new SqlCommand("update sme set  first_name =@firstname , last_name = @lastname, gender =@Gender, age=@age, contact_no = @contactno, emailId = @emailid,description=@description where smeId = @smeId", connect);
                cmd.Parameters.AddWithValue("@smeId", smeId);
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
        public void deleteSkillsSme(long smeId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                
                connect.Open();
                SqlCommand cmd = new SqlCommand("delete from sme_skills where sme_Id=@smeid", connect);
                cmd.Parameters.AddWithValue("@smeid", smeId);
                cmd.ExecuteNonQuery();
                connect.Close();

            }
        }

        public List<SmeNominationsList> smeNominationList(long smeid)
        {
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            List<SmeNominationsList> nominatedList = new List<SmeNominationsList>();
            nominatedList = null;
            SqlCommand cmd = new SqlCommand("select * from skillset s join sme_skills ss on s.skill_id=ss.skillid where ss.sme_Id=@smeId ", connect);
            cmd.Parameters.AddWithValue("@smeId", smeid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                nominatedList.Add(new SmeNominationsList(long.Parse(dr["requestId"].ToString()), long.Parse(dr["sme_Id"].ToString())));
            }
            return nominatedList;
        }

    }
}
