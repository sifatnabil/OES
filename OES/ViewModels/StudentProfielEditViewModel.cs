using OES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.ViewModels {
    public class StudentProfielEditViewModel {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string UniversityId { get; set; }

        public DateTime Birthdate { get; set; }

        public int? BloodGroupId { get; set; }

        public IEnumerable<BloodGroup> BloodGroups { get; set; }


        public StudentProfielEditViewModel(Student student) {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.Address = student.Address;
            this.PhoneNumber = student.PhoneNumber;
            this.BloodGroupId = student.BloodGroupId;
        }
    }
}