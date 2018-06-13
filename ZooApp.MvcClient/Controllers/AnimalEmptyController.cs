using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.MvcClient.Controllers
{
    public class AnimalEmptyController : Controller
    {
        AnimalService animalService = new AnimalService();
        // GET: AnimalEmpty
        public ActionResult Index()
        {
            
            var viewAnimals = animalService.GetAll();
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
            var animalById= animalService.Get(id);
            return View(animalById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                var saved = animalService.Save(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editedAnimal = animalService.GetDbModel(id);
            return View(editedAnimal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            var edited = animalService.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deletedAnimal = animalService.GetDbModel(id);
            return View(deletedAnimal);
        }
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            
            var deleted = animalService.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}