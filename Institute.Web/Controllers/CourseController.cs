using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Course = Institute.Web.Models.Course;

namespace Institute.Web.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        // GET: ClassroomController
        public ActionResult Index()
        {
            var courses = this.courseRepository.GetAll().Select(st => new Models.Course()
            {
                Id = st.Id,
                Title = st.Title,
                Credits = st.Credits
            });

            return View();
        }

        // GET: ClassroomController/Details/5
        public ActionResult Details(int id)
        {
            var course = this.courseRepository.GetCourse(id);

            Course modelCourse = new Course()
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits
            };

            return View();
        }

        // GET: ClassroomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassroomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Course modelTarget)
        {
            try
            {
                Institute.DAL.Entities.Course target = new DAL.Entities.Course()
                {
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    Title = modelTarget.Title,
                    Credits = modelTarget.Credits
                };

                courseRepository.Save(target);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassroomController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = this.courseRepository.GetCourse(id);

            Course modelCourse = new Course()
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits
            };

            return View();
        }

        // POST: ClassroomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Course modelTarget)
        {
            try
            {
                Institute.DAL.Entities.Course target = new DAL.Entities.Course()

                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    Title = modelTarget.Title,
                    Credits = modelTarget.Credits,
                };

                courseRepository.Update(target);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassroomController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = this.courseRepository.GetCourse(id);

            Course modelCourse = new Course()
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits
            };

            return View();
        }

        // POST: ClassroomController/Delete/5
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
