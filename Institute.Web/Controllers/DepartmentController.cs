using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Department = Institute.Web.Models.Department;

namespace Institute.Web.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        // GET: CareerController
        public ActionResult Index()
        {
            var departments = this.departmentRepository.GetAll().Select(st => new Models.Department()
            {
                Id = st.Id,
                Name = st.Name,
                Administrator = st.Administrator,
                Budget = st.Budget,

            });

            return View();
        }

        // GET: CareerController/Details/5
        public ActionResult Details(int id)
        {
            var dp = this.departmentRepository.GetDepartment(id);

            Department modelDepartment = new Department()
            {
                Id = dp.Id,
                Name = dp.Name,
                Administrator = dp.Administrator,
                Budget = dp.Budget
            };

            return View();
        }

        // GET: CareerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CareerController/Create
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

        // GET: CareerController/Edit/5
        public ActionResult Edit(int id)
        {
            var dp = this.departmentRepository.GetDepartment(id);

            Department modelDepartment = new Department()
            {
                Id = dp.Id,
                Name = dp.Name,
                Administrator = dp.Administrator,
                Budget = dp.Budget
            };

            return View();
        }

        // POST: CareerController/Edit/5
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

        // GET: CareerController/Delete/5
        public ActionResult Delete(int id)
        {
            var dp = this.departmentRepository.GetDepartment(id);

            Department modelDepartment = new Department()
            {
                Id = dp.Id,
                Name = dp.Name,
                Administrator = dp.Administrator,
                Budget = dp.Budget
            };

            return View();
        }

        // POST: CareerController/Delete/5
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
