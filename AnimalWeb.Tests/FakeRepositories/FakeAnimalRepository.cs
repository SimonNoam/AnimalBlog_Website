using AnimalsWeb.Models;
using AnimalsWeb.Repositories;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsWeb.Tests.FakeRepositories
{
    internal class FakeAnimalRepository : IAnimalRepository
    {
        private IEnumerable<Animal> _animals;
        private IEnumerable<Category> _categories;
        private IEnumerable<Comment> _comments;
        public FakeAnimalRepository()
        {
            _categories = new List<Category>()
            { new Category{ CategoryId =1 },
              new Category{ CategoryId =2 }
            };

            _comments = new List<Comment>()
            {
                new Comment{ CommentId = 1 , AnimalId =1},
                new Comment{ CommentId = 2 , AnimalId=2},
                new Comment{ CommentId = 3 , AnimalId = 3}
            };

            _animals = new List<Animal>()
            { new Animal() { AnimalId = 1 , CategoryId=1},
                new Animal() { AnimalId = 2 ,CategoryId=1 },
                new Animal() { AnimalId = 3 , CategoryId = 3}
            };
        }
        public void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(LoginPage user)
        {
            throw new NotImplementedException();
        }

        public void CommentToAnimal(int id, string comment)
        {

            throw new NotImplementedException();
        }

        public void DeleteAnimal(int animalId)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }

        public IEnumerable<Animal> GetAnimalsByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public IEnumerable<Animal> TopAnimals()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(int animalId, Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
