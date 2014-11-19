using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentAPI.Models.dtos
{
    //this is the class that will be the containers for responses
    //typically, I use these to both assist in object creation, seralization, and
    //database structure masking; however, this data isnt so... sensitive.

    public class ReturnObjects
    {
        public class StudentReturn
        {
            public int id { get; set; }
            public string url { get; set; }
            public string firstName{ get; set;}
            public string lastName{get; set;}
         
        }

        public class StudentClassesReturn
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ClassName { get; set; }
            public string SchoolName {get; set;}

        }
    }
}