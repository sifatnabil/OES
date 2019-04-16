using OES.Models;
using OES.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OES.Controllers
{
    [Authorize(Roles="Admin, Teacher")]
    public class TeachersController : Controller
    {
        private ApplicationDbContext _context;

        public TeachersController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Teachers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateExam() {
            var viewModel = new CreateExamViewModel();
            var clients = _context.Courses.
               Select(s => new {
                   Text = s.CourseCode + " - " + s.CourseName,
                   Value = s.Id
               }).ToList();
            ViewBag.CoursesList = new SelectList(clients, "Value", "Text");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExam(CreateExamViewModel exam) {
            if (ModelState.IsValid) {
                var teacher = _context.Teachers.Single(t => t.UserName == User.Identity.Name);
                var newExam = new Exam();
                newExam.CourseId = exam.CourseId;
                newExam.TeacherId = teacher.Id;
                newExam.ExamName = exam.ExamName;
                newExam.ExamDate = exam.ExamDate.Date.Add(exam.ExamTime.TimeOfDay);
                newExam.IsOnline = exam.IsOnline;
                newExam.IsCatagorized = exam.IsCatagorized;
                _context.Exams.Add(newExam);
                _context.SaveChanges();
                Session["ExamId"] = newExam.Id;
                Session["QNo"] = 0;
                return RedirectToAction("SetQuestion", "Teachers", new { id = newExam.Id });
            }

            return View();
        }

        public ActionResult GetExams() {
            var teacher = _context.Teachers.SingleOrDefault(t => t.UserName == User.Identity.Name);
            var exams = _context.Exams.Where(e => e.TeacherId == teacher.Id).ToList();

            return View(exams);
        }

       

        public ActionResult SetQuestion(int? id) {
            if(id == null) {
                return View();
            }
            else {
                Session["ExamId"] = id;
                return View();
            }
        }

        public ActionResult ViewQuestions(int id) {
            var questions = _context.Questions.Where(q => q.ExamId == id).ToList();
            return View(questions);
        }
        

        public ActionResult GetQuestion(int? id) {
            var examId = Convert.ToInt64(Session["ExamId"]);
            var questions = _context.Questions.Where(q => q.ExamId == examId).ToList();

            return Json(new { data = questions }, JsonRequestBehavior.AllowGet );
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0) {
            if(id == 0) {
                return View(new Question());
            }

            else {
                return View(_context.Questions.Where(q => q.Id == id).FirstOrDefault());
            }
           
        }

        [HttpPost]
        public ActionResult AddOrEdit(Question model) {

            if(model.Id == 0) { 
                if (ModelState.IsValid) {
                    model.ExamId = Convert.ToInt32(Session["ExamId"]);
                    model.QuesNo = Convert.ToInt32(Session["QNo"]) + 1;
                    Session["QNo"] = Convert.ToInt32(Session["QNo"]) + 1;


                    _context.Questions.Add(model);

                    try {
                        _context.SaveChanges();
                    }
                    catch (DbEntityValidationException e) {

                        throw;
                    }

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

            else {
                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteQuestion(int id) {
            var q = _context.Questions.SingleOrDefault(x => x.Id == id);
            _context.Questions.Remove(q);
            _context.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}