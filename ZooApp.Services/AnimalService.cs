using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {
        ZooContext db = new ZooContext();
        public List<ViewAnimal> GetAllAnimals()
        {
            List<Animal> animals = db.Animals.ToList();

            List<ViewAnimal> viewAnimals = animals.Select(x => new ViewAnimal()
            {
                Id = x.Id,
                Food = x.Food,
                Name = x.Name,
                Origin = x.Origin,
                Quantity = x.Quantity
            }).ToList();
            return viewAnimals;
        }

        public ViewAnimal DetailsAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            return new ViewAnimal()
            {
                Id = animal.Id,
                Food = animal.Food,
                Name = animal.Name,
                Origin = animal.Origin,
                Quantity = animal.Quantity
            };
        }

        public string SaveAnimal(Animal animal)
        {
            
            Animal newAnimal =  db.Animals.Add(animal);
            db.SaveChanges();
            return "Animal Created Successfully";
        }

        public string EditAnimal(Animal animal)
        {
            db.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Animal Edited Successfuly";
        }

        public Animal EditAnimalById(int id)
        {
            Animal editedAnimal = db.Animals.Find(id);
            db.SaveChanges();
            return editedAnimal;
        }

        public Animal DeleteAnimal(Animal idAnimal)
        {
            var animal = db.Animals.Find(idAnimal.Id);
            Animal deletedAnimal = db.Animals.Remove(animal);
            db.SaveChanges();
            return deletedAnimal;
        }

        public Animal DeleteAnimalById(int id)
        {
            Animal deletedAnimal = db.Animals.Find(id);
            return deletedAnimal;
        }

        public Animal GetAnimalById(int id)
        {
            Animal animal = db.Animals.Find(id);
            return animal;
        }
    }
}
