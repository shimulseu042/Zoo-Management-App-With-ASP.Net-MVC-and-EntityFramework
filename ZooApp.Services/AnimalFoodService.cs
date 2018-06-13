using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalFoodService
    {
        private ZooContext db = new ZooContext();
        public List<ViewFoodTotal> GetFoodTotals()
        {
            IQueryable<IGrouping<int, AnimalFood>> animalFoodsGroup 
                = db.AnimalFoods.GroupBy(x => x.FoodId);
            IQueryable<ViewFoodTotal> viewFoodTotals 
                = from foodGroup in animalFoodsGroup
                let totalQuantity = foodGroup.Sum(x=>x.Animal.Quantity * x.Quantity)
                let food = foodGroup.FirstOrDefault()
                select new ViewFoodTotal
                {
                    FoodName = food.Food.Name,
                    FoodPrice = food.Food.Price,
                    TotalQuantity = totalQuantity,
                    TotalPrice = totalQuantity * food.Food.Price,
                    Id = food.Id,
                    FoodId = food.FoodId
                };
            return viewFoodTotals.ToList();
        }

        public List<ViewAnimalFoodTotal> GetFoodTotalsByFoodId(int foodId)
        {
            IQueryable<AnimalFood> animalFoods
                = db.AnimalFoods.Where(x=>x.FoodId == foodId);

            var totals =
                animalFoods.Select(animalFood => new ViewAnimalFoodTotal()
                {
                    Id = animalFood.Id,
                    TotalQuantity = animalFood.Quantity * animalFood.Animal.Quantity,
                    TotalPrice = animalFood.Quantity * animalFood.Animal.Quantity * animalFood.Food.Price,
                    AnimalName = animalFood.Animal.Name
        }).ToList();

            return totals;
        }
    }
}
