using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Student: ApplicationUser {
        public string UniversityId { get; set; }
    }
}