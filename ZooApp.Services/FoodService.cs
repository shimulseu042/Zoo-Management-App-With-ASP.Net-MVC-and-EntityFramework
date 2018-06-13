using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFood> GetAll()
        {
            List<Food> foods = db.Foods.ToList();

            List<ViewFood> viewFoods = foods.Select(x => new ViewFood()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();
            return viewFoods;
        }

        public ViewFood Get(int id)
        {
            Food food = db.Foods.Find(id);
            return new ViewFood()
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price
            };
        }

        public bool Save(Food food)
        {

            Food newFood = db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            db.Entry(food).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Food objFood)
        {
            var food = db.Foods.Find(objFood.Id);
            Food deletedFood = db.Foods.Remove(food);
            db.SaveChanges();
            return true;
        }
        public Food GetDbModel(int id)
        {
            Food food = db.Foods.Find(id);
            return food;
        }
    }
}
