using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Trainer
    {
        long trainerId;
        string first_name;
        string last_name;
        string gender;
        long contact_no;
        long age;
        string userid;
        string password_user;
        string userType;
        string emailId;
        string description;

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

        public string Password_user
        {
            get
            {
                return password_user;
            }

            set
            {
                password_user = value;
            }
        }

        public string UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
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
        public Trainer()
        {

        }

        public Trainer(long trainerId, string first_name, string last_name, string gender, long contact_no, long age, string userid, string password_user, string userType, string emailId, string description)
        {
            this.TrainerId = trainerId;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Gender = gender;
            this.Contact_no = contact_no;
            this.Age = age;
            this.Userid = userid;
            this.Password_user = password_user;
            this.UserType = userType;
            this.EmailId = emailId;
            this.Description = description;
        }

        public override string ToString()
        {
            return this.TrainerId + "  " + this.First_name + "  " + this.Last_name + "  " + this.Gender + "  " + this.Contact_no + "  " + this.Age + "  " + this.Userid + "  " + this.Password_user + "  " + this.UserType + "  " + this.EmailId+" "+this.Description;
        }
    }

}
