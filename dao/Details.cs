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
    public class Details
    {
        public AdminDetails adminname(string userid)
        {
            //string h = "hemanth";
            //List<AdminDetails> ad1 = new List<AdminDetails>();
            model.AdminDetails det = new model.AdminDetails();
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from adminDetails where username=@userid", connect);
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                det.Userid = dr["username"].ToString();
                det.Password = dr["password_admin"].ToString();
                //ad1.Add(new AdminDetails(dr["username"].ToString(), dr["password_admin"].ToString()));
                //string ad = ad;
            }
            return det;
        }

        public long trainerdet(string userid)
        {
            model.TrainerDetails details = new model.TrainerDetails();
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from trainer where userid=@userid", connect);
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                details.TrainerId = long.Parse(dr["trainerId"].ToString());
            }
            long h = details.TrainerId;
            return h;
        }
        public long requestordet(string userid)
        {
            model.Requestor details = new model.Requestor();
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from requestor where userid=@userid", connect);
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                details.RequestorId = long.Parse(dr["requestorId"].ToString());
            }
            long h = details.RequestorId;
            return h;
        }
        public long smedet(string userid)
        {
            model.SME details = new model.SME();
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from sme where userid=@userid", connect);
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                details.SmeId = long.Parse(dr["smeId"].ToString());
            }
            long h = details.SmeId;
            return h;

        }
        public TrainersmeDetails trainersmedetails(long requestid)
        {
            model.TrainersmeDetails trainesmedet = null;
            SqlConnection connect = ConnectionHandler.getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select r.requestId,at.trainer_Id,saa.smeid from  request r left join adminApprovedTrainer at on r.requestId=at.requestId left  join adminApprovedSme saa on r.requestId=saa.requestId where r.requestId=@requestId", connect);
            cmd.Parameters.AddWithValue("@requestId", requestid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
            DataTable dt = ds.Tables[0];
            string smeid,trainerid;
            foreach (DataRow dr in dt.Rows)
            {
                smeid = (dr["smeid"].ToString() == "") ? "0" : dr["smeid"].ToString();
                trainerid = (dr["trainer_Id"].ToString() == "") ? "0" : dr["trainer_Id"].ToString();
                trainesmedet = new TrainersmeDetails(long.Parse(dr["requestId"].ToString()), long.Parse(trainerid), long.Parse(smeid));
                //trainesmedet.RequestId = long.Parse(dr["requestId"].ToString());
                //trainesmedet.TrainerId = long.Parse(dr["trainer_Id"].ToString());
                //trainesmedet.SmeId = long.Parse(dr["sme_Id"].ToString());
            }
            
            return trainesmedet;
        }
    }
}
