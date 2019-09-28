using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using model;
using System.Data;
using System.Data.SqlClient;

namespace dao
{
    public class RequestDaoSqlImpl
    {
        public List<Requests> getRequestList()
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Requests> requestList = new List<Requests>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from request r join  skillset s on r.skillsubject=s.skill_id join requestor rq on rq.requestorId=r.requestor_Id where r.request_status='ON'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    requestList.Add(new Requests((long.Parse(dr["requestId"].ToString())), (long.Parse(dr["requestor_Id"].ToString())), dr["skill_name"].ToString(), DateTime.Parse(dr["startdate"].ToString()), DateTime.Parse(dr["enddate"].ToString()), dr["venue"].ToString(), dr["request_status"].ToString()));
                }
                return requestList;
            }
        }
        public List<Requests> getRequestList(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                List<Requests> requestList = new List<Requests>();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from request r join  skillset s on r.skillsubject=s.skill_id join requestor rq on rq.requestorId=r.requestor_Id where r.requestId=@requestid ", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connect.Close();
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    requestList.Add(new Requests((long.Parse(dr["requestId"].ToString())), (long.Parse(dr["requestor_Id"].ToString())), dr["skill_name"].ToString(), DateTime.Parse(dr["startdate"].ToString()), DateTime.Parse(dr["enddate"].ToString()), dr["venue"].ToString(), dr["request_status"].ToString()));
                }
                return requestList;
            }
        }

        public List<RequestCalendar> getrequeststrdateenddate(long requestId)
        {
            List<RequestCalendar> req = new List<RequestCalendar>();
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();

            SqlCommand getTrainer = new SqlCommand("select * from request where requestId = @requestid", connect);
            getTrainer.Parameters.AddWithValue("@requestId", requestId);
            SqlDataReader result = getTrainer.ExecuteReader();
            while (result.Read())
            {
                req.Add(new RequestCalendar(DateTime.Parse(result["startDate"].ToString()), DateTime.Parse(result["enddate"].ToString())));

            }
            connect.Close();
            return req;
        }
    }
}

