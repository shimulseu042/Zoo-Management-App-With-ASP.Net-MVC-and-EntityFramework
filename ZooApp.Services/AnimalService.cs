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
        public List<ViewAnimal> GetAll()
        {
            List<Animal> animals = db.Animals.ToList();

            List<ViewAnimal> viewAnimals = animals.Select(x => new ViewAnimal()
            {
                Id = x.Id,
                Name = x.Name,
                Origin = x.Origin,
                Quantity = x.Quantity
            }).ToList();
            return viewAnimals;
        }

        public ViewAnimal Get(int id)
        {
            Animal animal = db.Animals.Find(id);
            return new ViewAnimal()
            {
                Id = animal.Id,
                Name = animal.Name,
                Origin = animal.Origin,
                Quantity = animal.Quantity
            };
        }

        public bool Save(Animal animal)
        {
            
            Animal newAnimal =  db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        
        public Animal Delete(Animal objAnimal)
        {
            var animal = db.Animals.Find(objAnimal.Id);
            Animal deletedAnimal = db.Animals.Remove(animal);
            db.SaveChanges();
            return deletedAnimal;
        }
	    public Animal GetDbModel(int id)
	    {
		    Animal animal = db.Animals.Find(id);
		    return animal;
	    }
    }
}
