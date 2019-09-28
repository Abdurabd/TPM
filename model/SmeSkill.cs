using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class SmeSkill
    {
        long smeId;
        long skillId;

        public SmeSkill(long smeId, long skillId)
        {
            this.smeId = smeId;
            this.skillId = skillId;
        }

        public long SmeId
        {
            get
            {
                return smeId;
            }

            set
            {
                smeId = value;
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
