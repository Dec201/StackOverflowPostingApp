using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingApp
{
    public class PostMenu
    {

        private static int AssignmentPostID;

        public int Id { get; set; }

        public string PostAuthor { get; set; }

        public string PostTitle { get; set; }

        public string PostDescription { get; set; }

        public DateTime PostTime { get; set; }

        public DateTime? PostLastEdited { get; set; }

        public int UserId { get; set; }




        public static int GetNextID()
        {
            return AssignmentPostID++;
        }



    }


}
