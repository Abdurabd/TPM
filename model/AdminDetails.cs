using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace model
{
    public class AdminDetails
    {
        string userid;
        string password;

        public AdminDetails(string userid, string password)
        {
            this.userid = userid;
            this.password = password;
        }

        public AdminDetails()
        {

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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
