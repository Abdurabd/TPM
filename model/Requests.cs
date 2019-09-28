using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Requests
    {
        long requestId;
        long requestorId;
        string skillSubject;
        DateTime startDate;
        DateTime endDate;
        string venue;
        string status;

        public Requests(long requestId, long requestorId, string skillSubject, DateTime startDate, DateTime endDate, string venue, string status)
        {
            this.requestId = requestId;
            this.requestorId = requestorId;
            this.skillSubject = skillSubject;
            this.startDate = startDate;
            this.endDate = endDate;
            this.venue = venue;
            this.status = status;
        }
        public Requests()
        {

        }

        public long RequestId
        {
            get
            {
                return requestId;
            }

            set
            {
                requestId = value;
            }
        }

        public long RequestorId
        {
            get
            {
                return requestorId;
            }

            set
            {
                requestorId = value;
            }
        }

        public string SkillSubject
        {
            get
            {
                return skillSubject;
            }

            set
            {
                skillSubject = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public string Venue
        {
            get
            {
                return venue;
            }

            set
            {
                venue = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
