using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student = Institute.Web.Models.Student;

namespace Institute.Web.Controllers
{

    public class StudentController : Controller
    {

        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }



        // GET: StudentController
        public ActionResult Index()
        {
            var students = this.studentRepository.GetAll().Select(st => new Models.Student()
            {
                Id = st.Id,
                Name = st.FirstName,
                lastName = st.LastName,
                EnrollmentDate = st.EnrollmentDate

            }) ;

            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = this.studentRepository.GetStudent(id);

            Student modelstudent = new Student()
            {
                Name = student.FirstName,
                lastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };

            return View(modelstudent);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student studentModel)
        {
            try
            {
                Institute.DAL.Entities.Student myStudent = new DAL.Entities.Student()
                {
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    FirstName = studentModel.Name,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    LastName = studentModel.lastName,
                    Id = studentModel.Id
                };

                studentRepository.Save(myStudent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = this.studentRepository.GetStudent(id);

            Student modelstudent = new Student()
            {
                Name = student.FirstName,
                lastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };

            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Student studentModel)
        {
            try
            {
                var myModel = studentModel;

                Institute.DAL.Entities.Student student = new DAL.Entities.Student()
                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    FirstName = studentModel.Name,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    LastName = studentModel.lastName,
                    Id = studentModel.Id
                };

                studentRepository.Update(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = this.studentRepository.GetStudent(id);

            Student modelstudent = new Student()
            {
                Name = student.FirstName,
                lastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };

            return View(modelstudent);
        }

        // POST: StudentController/Delete/5
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
