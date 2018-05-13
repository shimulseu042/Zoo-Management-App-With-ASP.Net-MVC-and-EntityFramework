﻿using System;
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
            
            var viewAnimals = animalService.GetAllAnimals();
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
            var animalById= animalService.DetailsAnimal(id);
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
            var IsSaved = animalService.SaveAnimal(animal);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editedAnimal = animalService.EditAnimalById(id);
            return View(editedAnimal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            var saved = animalService.EditAnimal(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deletedAnimal = animalService.DeleteAnimalById(id);
            return View(deletedAnimal);
        }
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            
            var IsDeleted = animalService.DeleteAnimal(animal);
            return RedirectToAction("Index");
        }
    }
}