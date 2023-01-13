using AnimalsWeb.Filters;
using AnimalsWeb.Models;
using AnimalsWeb.Repositories;
using AnimalsWeb.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace AnimalsWeb.Controllers
{
    public class AdmenistratorController : Controller
    {
        private readonly IWebHostEnvironment _hosting;
        private IAnimalRepository _animalRepository;
        public AdmenistratorController(IAnimalRepository animalRepository, IWebHostEnvironment ihostingEnvironment)
        {
            _animalRepository = animalRepository;
            _hosting = ihostingEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult FrontPage(int id)
        {
            ViewBag.cat = _animalRepository.GetCategories();

            if (id == 0)
            {
                return View(_animalRepository.GetAnimals());
            }
            return View(_animalRepository.GetAnimalsByCategory(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult InsertAnimal()
        {
            ViewBag.categories = _animalRepository.GetCategories();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult InsertAnimal(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null!;
                if (model.PictureName != null)
                {
                    string uploadFolder = Path.Combine(_hosting.WebRootPath, "Images");
                    uniqeFileName = model.PictureName.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqeFileName);
                    model.PictureName.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Animal animal = new Animal()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Description = model.Description,
                    PictureName = uniqeFileName,
                    CategoryId = model.CategoryId
                };
                _animalRepository.AddAnimal(animal);
                return RedirectToAction("FrontPage", _animalRepository.GetAnimals());
            }
            return RedirectToAction("InsertAnimal");
        }

        [MyExceptionFilter]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return RedirectToAction("FrontPage", _animalRepository.GetAnimals());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            ViewBag.categories = _animalRepository.GetCategories();

            if (ModelState.IsValid)
            {
                Animal animal = _animalRepository.GetAnimalById(id);

                AnimalViewModel updateAnimal = new AnimalViewModel()
                {
                    AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Age = animal.Age,
                    Description = animal.Description,
                    CategoryId = animal.CategoryId,
                };
                return View(updateAnimal);
            }
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, AnimalViewModel model)
        {
            bool hasImage = false;

            if (ModelState.IsValid)
            {
                string uniqeFileName = null!;

                var animal = _animalRepository.GetAnimalById(id);
                animal!.Name = model.Name;
                animal.Age = model.Age;
                animal.Description = model.Description;
                animal.CategoryId = model.CategoryId;


                if (model.PictureName != null)
                {

                    string uploadFolder = Path.Combine(_hosting.WebRootPath, "Images");
                    DirectoryInfo path = new DirectoryInfo(uploadFolder);

                    var file = path.GetFiles();

                    foreach (var item in file)
                    {
                        if (item.Name.Contains(model.PictureName.FileName))
                        {
                            hasImage = true;
                        }
                    }

                    uniqeFileName = model.PictureName.FileName;
                    if (hasImage == false)
                    {

                        string filePath = Path.Combine(uploadFolder, uniqeFileName);
                        model.PictureName.CopyTo(new FileStream(filePath, FileMode.Create));

                    }
                    animal.PictureName = uniqeFileName;
                }

                _animalRepository.UpdateAnimal(id, animal);

                return RedirectToAction("FrontPage", _animalRepository.GetAnimals());

            }

            return View();
        }

    }
}