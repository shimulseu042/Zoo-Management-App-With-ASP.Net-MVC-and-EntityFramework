using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewAnimalFoodTotal
    {
        public ViewAnimalFoodTotal()
        {
                
        }
        public ViewAnimalFoodTotal(AnimalFood animalFood)
        {
            Id = animalFood.Id;
            TotalQuantity = animalFood.Quantity * animalFood.Animal.Quantity;
            TotalPrice = TotalQuantity * animalFood.Food.Price;
            AnimalName = animalFood.Animal.Name;
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double TotalQuantity { get; set; }
        public string AnimalName { get; set; }
    }
}
