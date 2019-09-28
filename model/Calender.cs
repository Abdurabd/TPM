using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Calender
    {
        DateTime startDate;
        DateTime enddate;
        string availability_status;

        public Calender(DateTime startDate, DateTime enddate, string availability_status)
        {
            this.startDate = startDate;
            this.enddate = enddate;
            this.availability_status = availability_status;
        }

        public Calender()
        {

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

        public DateTime Enddate
        {
            get
            {
                return enddate;
            }

            set
            {
                enddate = value;
            }
        }

        public string Availability_status
        {
            get
            {
                return availability_status;
            }

            set
            {
                availability_status = value;
            }
        }
        public override string ToString()
        {
            return this.startDate + "  " + this.enddate + "  " + this.availability_status;
        }

    }
}
