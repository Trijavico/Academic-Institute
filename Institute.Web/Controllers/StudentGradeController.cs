using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Institute.Web.Models;

namespace Institute.Web.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeRepository studentGradeRepository;

        public StudentGradeController(IStudentGradeRepository studentGradeRepository)
        {
            this.studentGradeRepository = studentGradeRepository;
        }


        // GET: SubjectController
        public ActionResult Index()
        {
            var studentGrades = this.studentGradeRepository.GetAll().Select(st => new Models.StudentGrade()
            {
                Student = st.Id,
                Grade = st.Grade

            });

            return View();
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            var student = this.studentGradeRepository.GetStudentGrade(id);

            StudentGrade modelstudentGrade = new StudentGrade()
            {
                Student = student.Id,
                Grade = student.Grade
            };

            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = this.studentGradeRepository.GetStudentGrade(id);

            StudentGrade modelstudentGrade = new StudentGrade()
            {
                Student = student.Id,
                Grade = student.Grade
            };

            return View();
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = this.studentGradeRepository.GetStudentGrade(id);

            StudentGrade modelstudentGrade = new StudentGrade()
            {
                Student = student.Id,
                Grade = student.Grade
            };

            return View();
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
