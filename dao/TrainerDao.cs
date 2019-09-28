using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using model;

namespace dao
{
   public interface TrainerDao
    {
        List<Trainer> getTrainerListAdmin();
        List<Skill> getTrainerSkillList(long trainerid);
        List<Trainer> getNameBySearch(string name);
        List<Trainer> getTrainersNominationList(long requestId);
        List<Trainer> getTrainerListSuggestionsAdmin(long requestId);
        void adminRequestingTrainer(long requestId, long trainerId);
        void adminApprovedTrainer(long requestId, long trainerId);
        List<Skill> getsmeSkillList(long smeid);
        List<Trainer> getSearchByDate(string name,DateTime date1, DateTime date2);
        int getTrainerNominationsCount(long trainerId);
        List<Calender> getDatesTrainer(long trainerId);
        void deleteSkillsTrainer(long trainerId);
        List<GetRequest> getApprovedRequestTrainer(long trainerId);
        void updatetrainerdetails(long trainerId, string firstname, string lastname, string gender, long age, long contactno, string emailid, string description);
    }
}
