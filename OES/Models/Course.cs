using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Course {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public double CourseCredit { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}