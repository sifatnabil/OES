using OES.Models;
using OES.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OES.Controllers
{
    [Authorize(Roles ="Student, Admin")]
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Account() {
            var student = _context.Students.Include(b => b.BloodGroup).SingleOrDefault(s => s.UserName == User.Identity.Name);
            var viewModel = new StudentProfileViewModel();
            viewModel.Student = student;
            var GroupName = _context.BloodGroups.SingleOrDefault(b => b.Id == student.BloodGroupId);
            //viewModel.BloodGroupName = GroupName.GroupName;
            
            return View(viewModel);
        }

        public ActionResult EditProfile() {
            var student = _context.Students.SingleOrDefault(s => s.UserName == User.Identity.Name);
            var viewModel = new StudentProfielEditViewModel(student);
            viewModel.BloodGroups = _context.BloodGroups.ToList();
            return View(viewModel);
        }

        public ActionResult ShowResults() {
            var user = _context.Students.SingleOrDefault(u => u.UserName == User.Identity.Name);
            var results = _context.Results.Include(e => e.Exam).Where(r => r.StudentId == user.Id).ToList();
            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(Student student) {
            if (ModelState.IsValid) {
                var user = _context.Students.SingleOrDefault(s => s.UserName == User.Identity.Name);
                user.FirstName = student.FirstName;
                user.LastName = student.LastName;
                user.Address = student.Address;
                user.PhoneNumber = student.PhoneNumber;
                user.BloodGroupId = student.BloodGroupId;
                try {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException e) {

                    Console.WriteLine(e);
                }
                return RedirectToAction("Account", "Students");
            }

            return View(student);
        }

        public ActionResult ShowExams() {
            var exams = _context.Exams.ToList();
            return View(exams);
        }

        public ActionResult PrepareExam(int id) {
            var li = _context.Questions.Where(q => q.ExamId == id).ToList();
            Queue<Question> questions = new Queue<Question>();
            foreach (var i in li) {
                questions.Enqueue(i);
            }

            TempData["Questions"] = questions;
            TempData["Score"] = 0;
            TempData["ExamId"] = id;
            TempData.Keep();

            return RedirectToAction("AttendExam");
        }

        public ActionResult AttendExam() {
            Question q = null;
            if(TempData["Questions"] != null) {
                Queue<Question> qList =(Queue<Question>)TempData["Questions"];
                if(qList.Count > 0) {
                    q = qList.Peek();
                    qList.Dequeue();
                    TempData["Questions"] = qList;
                    TempData.Keep();
                }
                else {
                    return RedirectToAction("EndExam", new { id = TempData["Score"] });
                }
            }

            else {
                return RedirectToAction("Index", "Students");
            }
            return View(q);
        }

        public ActionResult EndExam() {
            var student = _context.Students.SingleOrDefault(s => s.UserName == User.Identity.Name);
            var result = new Result();
            result.ExamId = Convert.ToInt32(TempData["ExamId"]);
            result.StudentId = student.Id;
            result.ObtainedMark = Convert.ToInt32(TempData["Score"]);
            _context.Results.Add(result);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult AttendExam(Question model) {
            int choosenAnswer = 0;
            int rightAnswer = model.RightAnswer;
            

            if(model.Option1 != null) {
                choosenAnswer = 1;
            }
            else if (model.Option2 != null) {
                choosenAnswer = 2;
                Console.WriteLine("hohoho");
            }
            else if (model.Option3 != null) {
                choosenAnswer = 3;
            }
            else if (model.Option4 != null) {
                choosenAnswer = 4;
            }


            if(choosenAnswer == rightAnswer) {
                TempData["Score"] = Convert.ToInt32(TempData["Score"]) + model.Mark;
            }

            TempData.Keep();

            return RedirectToAction("AttendExam");
        }
    }


}