using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class TrainerSkill
    {
        long trainerId;
        long skillId;

        public TrainerSkill()
        {

        }
        public TrainerSkill(long trainerId, long skillId)
        {
            this.trainerId = trainerId;
            this.skillId = skillId;
        }

        public long TrainerId
        {
            get
            {
                return trainerId;
            }

            set
            {
                trainerId = value;
            }
        }

        public long SkillId
        {
            get
            {
                return skillId;
            }

            set
            {
                skillId = value;
            }
        }
    }
}
