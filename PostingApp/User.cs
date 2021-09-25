using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingApp
{


    public class User
    {

        private static int AssignmentUserID;

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime AccountCreated { get; set; }


        public static int GetNextID()
        {
            return AssignmentUserID++;
        }

    }




}
