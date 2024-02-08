using Institute.BLL.Contracts;
using Institute.Web.Extensions;
using Institute.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Institute.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        // GET: ProfessorController
        public ActionResult Index()
        {
            var professors = ((List<BLL.Models.ProfessorModel>)_service.GetAll().Data).ConverToModel();

            return View(professors);
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            var professor = _service.GetById(id);

            return View(professor);
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professorModel)
        {
            try
            {
                var myProfessor = new BLL.Dto.ProfessorSaveDto()
                {
                    FirstName = professorModel.FirstName,
                    HireDate = (DateTime)professorModel.HireDate,
                    LastName = professorModel.LastName,
                    UserId = professorModel.Id
                };

                _service.SaveProfessor(myProfessor);

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
            var professor = _service.GetById(id).Data as Professor;

            Professor modelprofessor = new Professor()
            {
                Id = professor.Id,
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                HireDate = professor.HireDate
            };

            return View(professor);
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professorModel)
        {
            try
            {

                var pf = new BLL.Dto.ProfessorUpdateDto()
                {
                    UserId = professorModel.Id,
                    FirstName = professorModel.FirstName,
                    LastName = professorModel.LastName,
                    HireDate = professorModel.HireDate.HasValue ? professorModel.HireDate : null
                };

                _service.UpdateProfessor(pf);

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
            var professorResult = _service.GetById(id);

            if (professorResult.Success && professorResult.Data is Professor professor)
            {
                Professor modelProfessor = new Professor()
                {
                    Id = professor.Id,
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    HireDate = professor.HireDate
                };

                return View(modelProfessor);
            }
            else
            {
                // Manejar el caso en el que no se pudo obtener el profesor
                return RedirectToAction("Error");
            }
        }

        // POST: ProfessorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                BLL.Models.ProfessorModel professor = _service.GetById(id).Data;
                var professorToDelete = new BLL.Dto.ProfessorRemoveDto(){
                    Id = id,
                };

                var result = _service.RemoveProfessor(professorToDelete);
                if(result.Success){
                    Console.WriteLine("BORRADO");
                }else{
                    Console.WriteLine("ERROR AL BORRAR");
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}