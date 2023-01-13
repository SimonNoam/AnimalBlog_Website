using AnimalsWeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Controllers
{
    public class HomeController : Controller
    {
        private IAnimalRepository _animalRepository;
        public HomeController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
       
        public IActionResult Index()
        {
            ViewBag.top = _animalRepository.TopAnimals();

            return View();
        }

    }
}
