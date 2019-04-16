using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Query {
        public int Id { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public Student Student { get; set; }
        public string StudentId { get; set; }

        public string QueryQues { get; set; }

        public DateTime QueryTime { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}