using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class GetRequest
    {
        long requestId;
        string skillSubject;
        DateTime startDate;
        DateTime endDate;
        string venue;

        public GetRequest(long requestId, string skillSubject, DateTime startDate, DateTime endDate, string venue)
        {
            this.requestId = requestId;
            this.skillSubject = skillSubject;
            this.startDate = startDate;
            this.endDate = endDate;
            this.venue = venue;
        }

        public GetRequest()
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
    }
        public class req
        {
            long requestId;
            string skillSubject;
            DateTime startDate;
            DateTime endDate;
            string venue;

        public req(long requestId, string skillSubject, DateTime startDate, DateTime endDate, string venue)
        {
            this.requestId = requestId;
            this.skillSubject = skillSubject;
            this.startDate = startDate;
            this.endDate = endDate;
            this.venue = venue;
        }
        public req()
            {}

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
    }
    }
