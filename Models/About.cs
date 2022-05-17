using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSchoolWebApp.Models
{
    public class About
    {
        public string title { get; set; }
        public string description { get; set; }
        public string quote { get; set; }
        public string quoteAuthor { get; set; }
    }
    public class AboutRootModel 
    { 
        //access to the object
        public About About { get; set; }
        //other stuff I might want to add - like the title of the page
        public string Title { get; set; }
    }

}
