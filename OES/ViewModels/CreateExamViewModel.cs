using OES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OES.ViewModels {
    public class CreateExamViewModel {
        public int Id { get; set; }

        [Required(ErrorMessage ="Select the Course")]
        public int CourseId { get; set; }

        public string TeacherId { get; set; }

        public int? TotalMarks { get; set; }

        [Required(ErrorMessage ="Must Name the Exam")]
        public string ExamName { get; set; }

        [Required(ErrorMessage ="Exam Date and time must be declared")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }


        [Required(ErrorMessage ="Exam time must be specified")]
        [DataType(DataType.Time)]
        public DateTime ExamTime { get; set; }

        [Required(ErrorMessage ="Is the message Online?")]
        public bool IsOnline { get; set; }

        [Required(ErrorMessage ="Want to Catagorize the Questions?")]
        public bool IsCatagorized { get; set; }

        public int? NoOfQuestions { get; set; }

        public int? StartingIndex { get; set; }

        
    }
}