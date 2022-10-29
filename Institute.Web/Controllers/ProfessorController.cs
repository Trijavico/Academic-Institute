using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Institute.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Institute.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            this.professorRepository = professorRepository;
        }

        // GET: ProfessorController
        public ActionResult Index()
        {
            var professors = this.professorRepository.GetAll().Select(st => new Models.Professor()
            {
                Id = st.Id,
                Name = st.FirstName,
                lastName = st.LastName,
                HireDate = st.EnrollmentDate

            });

            return View(professors);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            var professor = this.professorRepository.GetProfessor(id);

            Professor modelprofessor = new Professor()
            {
                Id = professor.Id,
                Name = professor.FirstName,
                lastName = professor.LastName,
                HireDate = professor.EnrollmentDate
            };

            return View(modelprofessor);
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Professor professorModel)
        {
            try
            {
                Institute.DAL.Entities.Production.Professor myProfessor = new DAL.Entities.Production.Professor()
                {
                    CreationDate = DateTime.Now,
                    CreationUser = 1,
                    FirstName = professorModel.Name,
                    EnrollmentDate = professorModel.HireDate,
                    LastName = professorModel.lastName,
                    Id = professorModel.Id
                };

                professorRepository.Save(myProfessor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            var professor = this.professorRepository.GetProfessor(id);

            Professor modelprofessor = new Professor()
            {
                Id = professor.Id,
                Name = professor.FirstName,
                lastName = professor.LastName,
                HireDate = professor.EnrollmentDate
            };

            return View(modelprofessor);
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Professor professorModel)
        {
            try
            {

                Institute.DAL.Entities.Production.Professor pf = new DAL.Entities.Production.Professor()
                
                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    FirstName = professorModel.Name,
                    LastName = professorModel.lastName,
                    EnrollmentDate = professorModel.HireDate
                };

                professorRepository.Update(pf);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            var professor = this.professorRepository.GetProfessor(id);

            Professor modelprofessor = new Professor()
            {
                Id = professor.Id,
                Name = professor.FirstName,
                lastName = professor.LastName,
                HireDate = professor.EnrollmentDate
            };

            return View(modelprofessor);
        }

        // POST: ProfessorController/Delete/5
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
