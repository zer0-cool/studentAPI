using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentAPI.Models.dtos
{
    public class RequestObjects
    {
        public class NewStudent
        {
            public string firstName {get; set;}
            public string lastName {get; set;}
            public int GradeLevel {get; set;}
            public int School { get; set; }

        }
    }
}