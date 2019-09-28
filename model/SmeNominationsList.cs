using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class SmeNominationsList
    {
        long requestid;
        long smeid;

        public SmeNominationsList()
        {

        }
        public SmeNominationsList(long requestid, long smeid)
        {
            this.requestid = requestid;
            this.smeid = smeid;
        }

        public long Requestid
        {
            get
            {
                return requestid;
            }

            set
            {
                requestid = value;
            }
        }

        public long Smeid
        {
            get
            {
                return smeid;
            }

            set
            {
                smeid = value;
            }
        }
    }
}
