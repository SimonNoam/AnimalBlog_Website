using AnimalsWeb.Models;

namespace AnimalsWeb.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Animal> TopAnimals();
        IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAnimalsByCategory(int id);
        Animal GetAnimalById(int id);
        void AddAnimal(Animal animal);
        void DeleteAnimal(int animalId);
        void UpdateAnimal(int animalId , Animal animal);
        void CommentToAnimal (int id , string comment);
    }
}
