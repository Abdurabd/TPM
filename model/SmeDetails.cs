using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace model
{
   public class SmeDetails
    {
        long smeId;
        string first_name;
        string last_name;
        string gender;
        long contact_no;
        long age;
        string userid;
        string emailId;
        string description;
        DateTime startDate;
        DateTime endDate;
        string availability;

        public SmeDetails()
        {

        }

        public SmeDetails(long smeId, string first_name, string last_name, string gender, long contact_no, long age, string userid, string emailId, string description, DateTime startDate, DateTime endDate, string availability)
        {
            this.smeId = smeId;
            this.first_name = first_name;
            this.last_name = last_name;
            this.gender = gender;
            this.contact_no = contact_no;
            this.age = age;
            this.userid = userid;
            this.emailId = emailId;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.availability = availability;
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

        public string First_name
        {
            get
            {
                return first_name;
            }

            set
            {
                first_name = value;
            }
        }

        public string Last_name
        {
            get
            {
                return last_name;
            }

            set
            {
                last_name = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public long Contact_no
        {
            get
            {
                return contact_no;
            }

            set
            {
                contact_no = value;
            }
        }

        public long Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public string EmailId
        {
            get
            {
                return emailId;
            }

            set
            {
                emailId = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
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

        public string Availability
        {
            get
            {
                return availability;
            }

            set
            {
                availability = value;
            }
        }
    }
}
