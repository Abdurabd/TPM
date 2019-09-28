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
   public class FinaliseRequestSqlImpl
    {
        public void adminFinalisingRequest(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                int check = 0;
                connect.Open();
                SqlCommand cmd = new SqlCommand("select count(allocatedId) from allocated  where requestId=@requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                check = int.Parse(cmd.ExecuteScalar().ToString());
                connect.Close();
                if (check == 0)
                {
                    connect.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into allocated (requestId,trainer_Id,sme_Id) select r.requestId,t.trainer_Id,s.sme_Id from request r right JOIN adminApprovedTrainer t on t.requestId=r.requestId right join adminApprovedSme s on r.requestId=s.requestId where t.requestId=@requestid or s.requestId=@requestid", connect);
                    cmd1.Parameters.AddWithValue("@requestid", requestId);
                    cmd1.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }
        public void closingRequest(long requestId)
        {
            using (SqlConnection connect = ConnectionHandler.getConnection())
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("update request set request_status = 'OFF' where requestId =@requestid", connect);
                cmd.Parameters.AddWithValue("@requestid", requestId);
                cmd.ExecuteNonQuery();
                SqlCommand deleteTrainerNomination = new SqlCommand("delete from trainerNomination where requestId =@requestid", connect);
                deleteTrainerNomination.Parameters.AddWithValue("@requestid", requestId);
                deleteTrainerNomination.ExecuteNonQuery();
                SqlCommand deleteSmeNomination = new SqlCommand("delete from smeNomination where requestId =@requestid", connect);
                deleteSmeNomination.Parameters.AddWithValue("@requestid", requestId);
                deleteSmeNomination.ExecuteNonQuery();
                connect.Close();
            }
        }

    }
}
