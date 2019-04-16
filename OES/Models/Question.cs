using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OES.Models {
    public class Question {
        public int Id { get; set; }

        public Exam Exam { get; set; }

        [Required]
        public int ExamId { get; set; }

        public string QuestionType { get; set; }

        public string QuestionCatagory { get; set; }

        public int QuesNo { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="Question")]
        public string Ques { get; set; }

        [Required]
        [Display(Name ="Option 1")]
        public string Option1 { get; set; }

        [Required(ErrorMessage ="Field is required")]
        [Display(Name ="Option 2")]
        public string Option2 { get; set; }

        [Required]
        [Display(Name ="Option 3")]
        public string Option3 { get; set; }

        [Required]
        [Display(Name ="Option 4")]
        public string Option4 { get; set; }

        [Required]
        [Display(Name ="Right Answer(1-4)")]
        [Range(1, 4, ErrorMessage ="Answer must be between the given options")]
        public int RightAnswer { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Please Enter a valid integer number")]
        public int Mark { get; set; }

        
    }
}