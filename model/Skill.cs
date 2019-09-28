using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Skill
    {
        long skillId;
        string skillName;
        public Skill()
        {

        }
        public Skill(long skillId, string skillName)
        {
            this.skillId = skillId;
            this.skillName = skillName;
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

        public string SkillName
        {
            get
            {
                return skillName;
            }

            set
            {
                skillName = value;
            }
        }
    }
}
