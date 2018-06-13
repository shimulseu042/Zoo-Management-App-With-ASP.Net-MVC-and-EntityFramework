using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.MvcClient.Controllers
{
    public class FoodController : Controller
    {
        private FoodService service = new FoodService();
        // GET: Food
        public ActionResult Index()
        {
            var viewFoods =  service.GetAll();
            return View(viewFoods);
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            var food = service.Get(id);
            return View(food);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                // TODO: Add insert logic here
                var saveFood = service.Save(food);
                if (saveFood)
                {
                    return RedirectToAction("Index");
                }
                return View(food);
            }
            catch
            {
                return View(food);
            }
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            Food food = service.GetDbModel(id);
            return View(food);
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {
                // TODO: Add update logic here

                var updated = service.Update(food);
                if (updated)
                {
                    return RedirectToAction("Index");
                }
                return View(food);
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            Food food = service.GetDbModel(id);
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            try
            {
                // TODO: Add delete logic here
                var deleted = service.Delete(food);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }
                return View(food);
            }
            catch
            {
                return View();
            }
        }
    }
}
