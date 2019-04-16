using OES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OES.ViewModels {
    public class ExamViewModel {
        public Exam Exam { get; set; }
        public Teacher Teacher { get; set; }
    }
}