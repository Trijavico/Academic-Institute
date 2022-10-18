using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Institute.Web.Controllers
{
    public class ClassroomController : Controller
    {
        // GET: ClassroomController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClassroomController/Details/5
        public ActionResult Details(int id)
        {
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

        // GET: ClassroomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassroomController/Edit/5
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

        // GET: ClassroomController/Delete/5
        public ActionResult Delete(int id)
        {
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
