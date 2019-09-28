using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using model;

namespace dao
{
    public interface MoreDetails
    {
        TrainerDetails getTrainerDetails(long trainerid);
        List<Skill> getTrainerSkillList(long trainerid);
        SmeDetails getSmeDetails(long smeid);
    }
}
