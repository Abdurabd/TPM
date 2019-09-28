using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using dao;

namespace dao
{
    public interface RequestManagementDao
    {
        void addRequest(long requestorId, long skillSubject, DateTime startDate, DateTime endDate, string venue, string status);
        List<req> getRequest(long requestorId);
        RequestorDetails getRequestor(long requestorId);
        List<GetRequest> getRequest();
        List<GetRequest> getTrainerRequest(long trainerId);
        void addNomination(long requestId, long trainerId);
        Trainer getTrainer(long trainerId);
        List<GetRequest> getSmeRequest(long smeId);
        void addSmeNomination(long requestId, long smeId);
        SME getSme(long smeId);
        void addAvailability(long id, DateTime startDate, DateTime endDate, string status);
        void addSmeAvailability(long id, DateTime startDate, DateTime endDate, string status);
        List<Calender> getDatesRequest(long requestId);
        void updaterequestordetails(long requestorId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description);
        List<req> getApprovedRequest(long requestorId);
        List<GetRequest> getRequestsme();
    }
}
