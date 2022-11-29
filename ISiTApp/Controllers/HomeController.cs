using ISiTApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISiTApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Chapter1() => View();
        public IActionResult Chapter2() => View();
        public IActionResult Chapter3() => View();
        public IActionResult Chapter4() => View();
        public IActionResult Chapter5() => View();
        public IActionResult Part() => PartialView();
        public IActionResult Part1() => PartialView();
        public string IndexInfo()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            return $"controller: {controller} | action: {action}";
        }
        public string About(string name, int age) => $"About Page. Имя: {name}  Возраст: {age}";

        [Route("homepage")]
        public string Home() => "Самая ГЛАВНАЯ страница";

        [Route("testpage/{id?}")]
        public string Test(int? id)
        {
            if (id is not null)
                return $"Параметр id={id}";
            else
                return $"Параметр id неопределен";
        }

        [Route("main/{id:int}/{name:maxlength(10)}")]
        public string Test(int id, string name) => $" id={id} | name={name}";
        public string IndexPerson(OtherPerson person)
        {
            return $"{person.Name}({person.Age}) - {person.Company?.Name}";
        }
        public string AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                return $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
            }
            string errors = $"Количество ошибок: {ModelState.ErrorCount}. Ошибки в свойствах: ";
            foreach (var prop in ModelState.Keys)
            {
                errors = $"{errors}{prop}; ";
            }
            return errors;
        }
        public string AddOtherUser([Bind("Name")] User user)
        {
            return $"Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
        }

        static List<Event> events = new List<Event>();
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Event myEvent)
        {
            myEvent.Id = Guid.NewGuid().ToString();
            events.Add(myEvent);
            return RedirectToAction("/Home/Events");
        }
    }
}