using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
  public class RequestorDetails
    {
        long requestorId;
        string firstName;
        string lastName;
        string gender;
        long contactNumber;
        long age;
       
        string emailId;
        string description;

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

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
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

        public long ContactNumber
        {
            get
            {
                return contactNumber;
            }

            set
            {
                contactNumber = value;
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
        public RequestorDetails()
        { }

        public RequestorDetails(long requestorId, string firstName, string lastName, string gender, long contactNumber, long age, string emailId, string description)
        {
            this.RequestorId = requestorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.ContactNumber = contactNumber;
            this.Age = age;
            this.EmailId = emailId;
            this.Description = description;
        }
    }
}
