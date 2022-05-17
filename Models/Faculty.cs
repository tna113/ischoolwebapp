using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSchoolWebApp.Models
    //namespace is a container that holds all the code
    //can have a faculty in another namespace but they dont butt heads
{
    public class Faculty
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class FacultyRootModel
    {
        public List<Faculty> faculty { get; set; }
        //add a title that will go into the html title...
        public string Title { get; set; }

        //give me css?
        //give me footer?
        //can put whatever in here specific for faculty...root..model...
    }
}
