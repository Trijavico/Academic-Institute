
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
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

            return View(departments);
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

            return View(modelDepartment);
        }

        // GET: CareerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CareerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Department modelTarget)
        {
            try
            {
                Institute.DAL.Entities.Production.Department target = new DAL.Entities.Production.Department()
                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    Name = modelTarget.Name,
                    Administrator = modelTarget.Administrator,
                    Budget = modelTarget.Budget
                };

                departmentRepository.Save(target);

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

            return View(modelDepartment);
        }

        // POST: CareerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Department modelTarget)
        {
            try
            {
                Institute.DAL.Entities.Production.Department target = new DAL.Entities.Production.Department()

                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    Name = modelTarget.Name,
                    Administrator = modelTarget.Administrator,
                    Budget = modelTarget.Budget
                };

                departmentRepository.Update(target);

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

            return View(modelDepartment);
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
