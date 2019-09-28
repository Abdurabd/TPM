using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using model;

namespace dao
{
    public interface SmeDao
    {
        List<SME> getSmeListAdmin();
        List<Skill> getSmeSkillList(int smeid);
        List<SME> getNameBySearch(string name);
        List<SME> getSmeNominationList(long requestId);
        List<SME> getSmeListSuggestionsAdmin(long requestId);
        void adminRequestingSme(long requestId, long smeId);
        void adminApprovedSme(long requestId, long smeId);
        List<Skill> getsmeSkillList(long smeid);
        List<SME> getSearchByDate(string name,DateTime date1, DateTime date2);
        int getSmeNominationsCount(long smeId);
        List<Calender> getDatesSme(long smeId);
        List<GetRequest> getApprovedRequestsme(long smeId);
        void updatesmedetails(long smeId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description);
        void deleteSkillsSme(long smeId);
        List<SmeNominationsList> smeNominationList(long smeid);
    }
}
