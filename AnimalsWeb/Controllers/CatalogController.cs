using AnimalsWeb.Models;
using AnimalsWeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Controllers
{
    public class CatalogController : Controller
    {
        IAnimalRepository _animalRepository;

        public CatalogController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;

        public IActionResult Index(int id)
        {
            ViewBag.List = _animalRepository.GetCategories();

            if (id == 0)
            {
                return View(_animalRepository.GetAnimals());
            }

            return View(_animalRepository.GetAnimalsByCategory(id));
        }
    }
}
