using FirstMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorldController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HelloWorldController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HelloWorldController/Create
        public ActionResult Create()
        {
            var dogVm = new DogViewModel();
            return View(dogVm);
        }

        // POST: HelloWorldController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDog(DogViewModel dogViewModel)
        {   
            return View("Index");
        }

        // GET: HelloWorldController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HelloWorldController/Edit/5
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

        // GET: HelloWorldController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HelloWorldController/Delete/5
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
