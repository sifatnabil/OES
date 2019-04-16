using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Result {
        public int Id { get; set; }

        public Student Student { get; set; }
        public string StudentId { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public int? TotalRightAnswer { get; set; }

        public int? TotalWrongAnswer { get; set; }

        public int ObtainedMark { get; set; }

        public bool? IsOnline { get; set; }
    }
}