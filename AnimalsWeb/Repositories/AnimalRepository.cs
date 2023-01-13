using AnimalsWeb.Data;
using AnimalsWeb.Filters;
using AnimalsWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace AnimalsWeb.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        readonly AnimalContext _context;
        public AnimalRepository(AnimalContext context) => _context = context;

        public IEnumerable<Animal> GetAnimals() => _context.Animals!;
        public IEnumerable<Animal> GetAnimalsByCategory(int id) => _context.Animals!.Where(c => c.CategoryId == id).ToList();
        public IEnumerable<Category> GetCategories() => _context.Categories!;
        public IEnumerable<Animal> TopAnimals() => _context.Animals.OrderByDescending(c => c.Comments.Count).Take(2).ToList();

        public void CommentToAnimal(int animalId, string val)
        {
            var newcomment = new Comment
            {
                AnimalId = animalId,
                Content = val
            };
            _context.Comments.Add(newcomment);
            _context.SaveChanges();
        }
        public Animal GetAnimalById(int id)
        {
            var animal = _context.Animals!.FirstOrDefault(a => a.AnimalId == id);
            return animal!;
        }

        public void AddAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void DeleteAnimal(int animalId)
        {
            var animal = _context.Animals!.FirstOrDefault(a => a.AnimalId == animalId);
            if (animal == null)
            {
                throw new InvalidTaxException();
            }
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int animalId, Animal animal)
        {
            var updatedAnimal = _context.Animals!.SingleOrDefault(a => a.AnimalId == animalId);
            if (updatedAnimal != null)
            {
                updatedAnimal.Name = animal.Name;
                updatedAnimal.Age = animal.Age;
                updatedAnimal.PictureName = animal.PictureName;
                updatedAnimal.Description = animal.Description;
                updatedAnimal.CategoryId = animal.CategoryId;
                _context.SaveChanges();
            }
        }
    }
}
