using AnimalsWeb.Controllers;
using AnimalsWeb.Models;
using AnimalsWeb.Tests.FakeRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTest
    {
        [TestMethod]
        public void IndexShouldReturnListOfAnimals()
        {
            var animalRepository = new FakeAnimalRepository();
            var catalogController = new CatalogController(animalRepository);

            var result = catalogController.Index(0) as ViewResult;
            Assert.AreEqual(typeof(List<Animal>),result!.Model!.GetType());
        }
    }
}