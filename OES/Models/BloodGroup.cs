using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class BloodGroup {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}