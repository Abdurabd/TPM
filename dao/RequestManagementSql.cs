using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.Data;
using System.Data.SqlClient;

namespace dao
{
    public class RequestManagementSql : RequestManagementDao
    {
        public void addAvailability(long id,DateTime startDate, DateTime endDate, string status)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();

          
                    SqlCommand getAvailability = new SqlCommand("insert into trainerAvailability(trainer_Id,startDate,enddate,availability_status) values(@id,@startDate,@endDate,@status)", connection);
                    getAvailability.Parameters.AddWithValue("@id", id);
                    getAvailability.Parameters.AddWithValue("@startDate", startDate);
                    getAvailability.Parameters.AddWithValue("@endDate", endDate);
                    getAvailability.Parameters.AddWithValue("@status", status);
                    getAvailability.ExecuteNonQuery();
                    connection.Close();
            }
        }
       


        public void addNomination(long requestId, long trainerId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                int check = 0;
                int nomination = 0;
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Count(trainerNominationId) from trainerNomination where requestId=@requestId and trainer_Id=@trainerId", connection);
                cmd.Parameters.AddWithValue("@trainerId", trainerId);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                SqlCommand nominations = new SqlCommand("select count(trainerNominationId) from trainerNomination where trainer_Id=@trainerId", connection);
                nominations.Parameters.AddWithValue("@trainerId", trainerId);
                nomination = int.Parse(nominations.ExecuteScalar().ToString());
                connection.Close();
                if (check == 0 && nomination < 3)
                {
                    connection.Open();
                    SqlCommand addNomination = new SqlCommand("insert into trainerNomination values(@requestId,@trainerId)", connection);
                    addNomination.Parameters.AddWithValue("@requestId", requestId);
                    addNomination.Parameters.AddWithValue("@trainerId", trainerId);
                    addNomination.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        public void addRequest(long requestorId, long skillSubject, DateTime startDate, DateTime endDate, string venue, string status)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand addRequest = new SqlCommand("insert into request values (@requestorId,@skillSubject,@startDate,@endDate,@venue,@status)", connection);
                addRequest.Parameters.AddWithValue("@requestorId", requestorId);
                addRequest.Parameters.AddWithValue("@skillSubject", skillSubject);
                addRequest.Parameters.AddWithValue("@startDate", startDate);
                addRequest.Parameters.AddWithValue("@endDate", endDate);
                addRequest.Parameters.AddWithValue("@venue", venue);
                addRequest.Parameters.AddWithValue("@status", status);
                addRequest.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void addSmeAvailability(long id, DateTime startDate, DateTime endDate, string status)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getSmeAvailability = new SqlCommand(" insert into smeAvailability(sme_Id,startDate,endDate,availability_status) values(@id,@startDate,@endDate,@status)", connection);
                getSmeAvailability.Parameters.AddWithValue("@id", id);
                getSmeAvailability.Parameters.AddWithValue("@startDate", startDate);
                getSmeAvailability.Parameters.AddWithValue("@endDate", endDate);
                getSmeAvailability.Parameters.AddWithValue("@status", status);
                getSmeAvailability.ExecuteNonQuery();
                connection.Close();
            }
        }


        public void addSmeNomination(long requestId, long smeId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                int check = 0;
                int nomination = 0;
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Count(smeNominationId) from smeNomination where requestId=@requestId and sme_Id=@smeId", connection);
                cmd.Parameters.AddWithValue("@smeId", smeId);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                SqlCommand nominations = new SqlCommand("select count(smeNominationId) from smeNomination where sme_Id=@smeId", connection);
                nominations.Parameters.AddWithValue("@smeId", smeId);
                nomination = int.Parse(nominations.ExecuteScalar().ToString());
                if (check == 0)
                {
                    
                    SqlCommand addNomination = new SqlCommand("insert into smeNomination values(@requestId,@smeId)", connection);
                    addNomination.Parameters.AddWithValue("@requestId", requestId);
                    addNomination.Parameters.AddWithValue("@smeId", smeId);
                    addNomination.ExecuteNonQuery();
                  
                }
                connection.Close();
            }
        }


        public List<GetRequest> getRequest()
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("Select requestId,skill_name,startdate,enddate,venue from request r join skillset s on r.skillsubject=s.skill_id where request_status='ON'", connection);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.GetRequest(long.Parse(results["requestId"].ToString()), results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }

        public List<GetRequest> getRequestsme()
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("Select requestId,skill_name,startdate,enddate,venue from request r join skillset s on r.skillsubject=s.skill_id where request_status='ON'", connection);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.GetRequest(long.Parse(results["requestId"].ToString()), results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }

        public List<req> getRequest(long requestorId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<req> requestList = new List<req>();
                SqlCommand requestorList = new SqlCommand("Select * /*skill_name,startdate,enddate,venue*/ from request join skillset on skillsubject=skill_id where requestor_Id=@requestorId and request_status='ON' order by requestId desc", connection);
                requestorList.Parameters.AddWithValue("@requestorId", requestorId);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.req(long.Parse(results["requestId"].ToString()),results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }

        public List<req> getApprovedRequest(long requestorId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<req> requestList = new List<req>();
                SqlCommand requestorList = new SqlCommand("Select * /*skill_name,startdate,enddate,venue*/ from request join skillset on skillsubject=skill_id where requestor_Id=@requestorId and request_status='OFF' order by requestId desc", connection);
                requestorList.Parameters.AddWithValue("@requestorId", requestorId);
                SqlDataReader results = requestorList.ExecuteReader();
                while (results.Read())
                {
                    requestList.Add(new model.req(long.Parse(results["requestId"].ToString()), results["skill_name"].ToString(), DateTime.Parse(results["startdate"].ToString()), DateTime.Parse(results["enddate"].ToString()), results["venue"].ToString()));
                }
                connection.Close();
                return requestList;
            }
        }
        public RequestorDetails getRequestor(long requestorId)
        {
            RequestorDetails requestor = null;
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getrequestor = new SqlCommand("Select requestorId,first_name,last_name,gender,contact_no,age,emailId,description from requestor where requestorId=@requestorId", connection);
                getrequestor.Parameters.AddWithValue("@requestorId", requestorId);
                SqlDataReader result = getrequestor.ExecuteReader();
                while (result.Read())
                {
                    requestor = new RequestorDetails(long.Parse(result["requestorId"].ToString()), result["first_name"].ToString(), result["last_name"].ToString(), result["gender"].ToString(), long.Parse(result["contact_no"].ToString()), long.Parse(result["age"].ToString()), result["emailId"].ToString(),result["description"].ToString());

                }
                connection.Close();

            }
            return requestor;
        }


        public SME getSme(long smeId)
        {
            SME sme = null;
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getSme = new SqlCommand("Select *from sme where smeId=@smeId", connection);
                getSme.Parameters.AddWithValue("@smeId", smeId);
                SqlDataReader result = getSme.ExecuteReader();
                while (result.Read())
                {
                    sme = new SME(long.Parse(result["smeId"].ToString()), result["first_name"].ToString(), result["last_name"].ToString(), result["gender"].ToString(), long.Parse(result["contact_no"].ToString()), long.Parse(result["age"].ToString()), result["userid"].ToString(), result["password_user"].ToString(), result["userType"].ToString(), result["emailId"].ToString(),result["description"].ToString());

                }
                connection.Close();

            }
            return sme;
        }


        public List<GetRequest> getSmeRequest(long smeId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("select * from request r join adminToSme at on r.requestId = at.requestId join skillset ss on ss.skill_id = r.skillsubject  where at.sme_Id =@smeId  and r.request_status = 'ON'", connection);
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


        public Trainer getTrainer(long trainerId)
        {
            Trainer trainer = null;
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getTrainer = new SqlCommand("Select *from trainer where trainerId=@trainerId", connection);
                getTrainer.Parameters.AddWithValue("@trainerId", trainerId);
                SqlDataReader result = getTrainer.ExecuteReader();
                while (result.Read())
                {
                    trainer = new Trainer(long.Parse(result["trainerId"].ToString()), result["first_name"].ToString(), result["last_name"].ToString(), result["gender"].ToString(), long.Parse(result["contact_no"].ToString()), long.Parse(result["age"].ToString()), result["userid"].ToString(), result["password_user"].ToString(), result["userType"].ToString(), result["emailId"].ToString(),result["description"].ToString());

                }
                connection.Close();

            }
            return trainer;
        }


        public List<GetRequest> getTrainerRequest(long trainerId)
        {
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                List<GetRequest> requestList = new List<GetRequest>();
                SqlCommand requestorList = new SqlCommand("select * from request r join adminToTrainer at on r.requestId = at.requestId join skillset ss on ss.skill_id = r.skillsubject  where at.trainer_Id = @trainerId and r.request_status = 'ON'", connection);
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


        public List<Calender> getDatesRequest(long requestId)
        {
            List<Calender> cal = new List<Calender>();
            using (SqlConnection connection = ConnectionHandler.getConnection())
            {
                connection.Open();
                SqlCommand getTrainer = new SqlCommand("select * from request r where r.requestId = @requestId", connection);
                getTrainer.Parameters.AddWithValue("@requestId", requestId);
                SqlDataReader result = getTrainer.ExecuteReader();
                while (result.Read())
                {
                    cal.Add(new Calender(DateTime.Parse(result["startDate"].ToString()), DateTime.Parse(result["enddate"].ToString()), result["request_status"].ToString()));

                }
                connection.Close();
            }
            return cal;
        }

        public void updaterequestordetails(long requestorId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                if(description==" ")
                {
                    description = null;
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("update requestor set  first_name =@firstname , last_name = @lastname, gender =@Gender, age=@age, contact_no = @contactno, emailId = @emailid ,description=@description where requestorId = @requestorid", connect);
                    cmd.Parameters.AddWithValue("@requestorid", requestorId);
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
                else
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("update requestor set  first_name =@firstname , last_name = @lastname, gender =@Gender, age=@age, contact_no = @contactno, emailId = @emailid ,description=@description where requestorId = @requestorid", connect);
                    cmd.Parameters.AddWithValue("@requestorid", requestorId);
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
        }





    }
}
