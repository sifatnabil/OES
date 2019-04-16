using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Exam {
        public int Id { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }

        public int? TotalMarks { get; set; }

        public string ExamName { get; set; }

        public DateTime ExamDate { get; set; }

        public bool IsOnline { get; set; }

        public bool IsCatagorized { get; set; }

        public List<string> Catagories { get; set; }

        public int? NoOfQuestions { get; set; }

        public int? StartingIndex { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<Query> Queries { get; set; }
    }
}