using DatabaseAccessClass.Logic;
using Microsoft.AspNetCore.Mvc;
using PlayGround.Models;
using System.Diagnostics;

namespace PlayGround.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Person person)
        {
            if(person != null)
            {
                PersonCRUD.InsertPerson(person.Name, person.Email, person.Age, person.Password, person.Country);

                return View("Privacy", person);
            }

            return View();
        }


        public IActionResult PersonsList(Person person)
        {
            var persons = PersonCRUD.GetAllPeople();
            List<Person> list = new();

            foreach (var item in persons)
            {
                list.Add(new Person
                {
                    Name = item.Name,
                    Email = item.Email,
                    Age = item.Age,
                    Password = item.Password,
                    Country = item.Country
                });
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Privacy(Person person)
        {
            if (person != null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}