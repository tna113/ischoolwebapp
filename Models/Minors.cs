using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSchoolWebApp.Models
{
    public class Minors
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> courses { get; set; }
        public string note { get; set; }
    }

    public class MinorsRootModel
    {
        public List<Minors> minors { get; set; }

        public string title { get; set; }
    }

}
