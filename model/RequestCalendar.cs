using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class RequestCalendar
    {
        DateTime startdate;
        DateTime enddate;

        public RequestCalendar(DateTime startdate, DateTime enddate)
        {
            this.startdate = startdate;
            this.enddate = enddate;
        }

        public RequestCalendar()
        {

        }

        public DateTime Startdate
        {
            get
            {
                return startdate;
            }

            set
            {
                startdate = value;
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
        public override string ToString()
        {
            return this.startdate + " " + this.enddate;
        }
    }
}
