using AnimalsWeb.Models;
using AnimalsWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AnimalsWeb.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        private IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
       
        public IActionResult ShowAnimal(int animalId) => View(new Tuple<Animal, Comment>(_animalRepository.GetAnimalById(animalId), new Comment()));
        public IActionResult CommentAdding(int animalId, string val)
        {
            if (ModelState.IsValid)
            {
                _animalRepository.CommentToAnimal(animalId, val);
                return RedirectToAction("ShowAnimal", _animalRepository.GetAnimalById(animalId));
            }
            else
                return RedirectToAction("ShowAnimal", _animalRepository.GetAnimalById(animalId));
        }
    }

}
