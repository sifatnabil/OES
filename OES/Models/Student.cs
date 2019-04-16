using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OES.Models {

    public class Student: ApplicationUser {
        public string UniversityId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<Query> Queries { get; set; }
    }
}