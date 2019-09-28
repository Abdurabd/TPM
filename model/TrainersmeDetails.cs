using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class TrainersmeDetails
    {
        long requestId;
        long trainerId;
        long smeId;
      

        public TrainersmeDetails(long requestId, long trainerId, long smeId)
        {
            this.requestId = requestId;
            this.smeId = smeId;
            this.trainerId = trainerId;
           
        }

        public TrainersmeDetails()
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

        public override string ToString()
        {
            return this.requestId+" "+this.trainerId+"  "+this.smeId ;
        }
    }
}
