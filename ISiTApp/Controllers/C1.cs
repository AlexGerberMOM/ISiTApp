using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISiTApp.Controllers
{
    public class C1 : Controller
    {
        // GET: c1
        public string Index()
        {
            return "Hello METANIT.COM";
        }

        protected internal string Hello() => "Hello ASP.NET";

        [HttpGet]
        public string Get()
        {
            return "Hello METANIT.COM";
        }

        [HttpPost]
        public string Post()
        {
            return "Hello ASP.NET";
        }
        public async Task Res()
        {
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync("<h4>Hello METANIT.COM</h4>");
        }

        public async Task Req()
        {
            Response.ContentType = "text/html;charset=utf-8";
            System.Text.StringBuilder tableBuilder = new("<h4>Request headers</h4><table>");
            foreach (var header in Request.Headers)
            {
                tableBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
            }
            tableBuilder.Append("</table>");
            await Response.WriteAsync(tableBuilder.ToString());
        }
        [HttpGet]
        public async Task SingleName()
        {
            string content = @"<form method='post'>
                            <div class='input-group mb-3'>
                                <span class='input-group-text' id='basic-addon3'>name=</span>
                                <input type='text' name='name' class='form-control' placeholder='Ваше имя'/>
                            </div></br>
                            <input type='submit' data-frame-load='c1-10' class='btn btn-light btn-sm' value='Выполнить запрос'/>
                        </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }
        [HttpPost]
        public string SingleName(string name) => $"Здравствуйте, {name}";

        public string Person(Person person)
        {
            return $"Person Имя: {person.Name}  Person Возраст: {person.Age}";
        }
        public IActionResult Action()
        {
            return new HTMLResults("<h4'>Ответ от класса HTMLResults</h4>");
        }
        public IActionResult ContentResult()
        {
            return Content("Я использую ContentResult");
        }
        public IActionResult JsonResult()
        {
            Person ivan = new Person("Ivan", 33);
            return Json(ivan);
        }
        public IActionResult JsonResultSerialize()
        {
            var ivan = new Person("Ivan", 33);
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            return Json(ivan, jsonOptions);
        }
        public IActionResult Main() => Content("Home page");
        public IActionResult About() => Content("About page");

        public IActionResult Contact()
        {
            return Redirect("~/C1/About");
        }
        public IActionResult Web()
        {
            return Redirect("https://yandex.ru");
        }
        public IActionResult RedirectTo()
        {
            return RedirectToAction("About", "C1");
        }
        public IActionResult RedirectWithParameters()
        {
            return RedirectToAction("AboutUser", "C1", new { name = "Ivan", age = 33 });
        }
        public IActionResult RedirecttoRoute()
        {
            return RedirectToRoute("default", new { controller = "C1", action = "AboutUser", name = "Ivan", age = 99 });
        }

        public IActionResult AboutUser(string name, int age) => Content($"Имя:{name}  Возраст: {age}");
        public IActionResult notFound()
        {
            return NotFound("Ресурс не найден");
        }
        public IActionResult Auth(int age)
        {
            if (age < 18) return Unauthorized(new Error("Access is denied"));
            return Content("Доступ разрешен");
        }
        record class Error(string Message);
        public IActionResult Bad(string? name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("Имя не определено");
            return Content($"Имя: {name}");
        }
        public IActionResult Okay()
        {
            return Ok("Не беспокойтесь. Все хорошо!");
        }
        public IActionResult GetFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            // Тип файла - content-type
            string file_type = "text/plain";
            // Имя файла - необязательно
            string file_name = "hello.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
        public IActionResult GetBytes()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "text/plain";
            string file_name = "hello2.txt";
            return File(mas, file_type, file_name);
        }
        public IActionResult GetStream()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "text/plain";
            string file_name = "hello3.txt";
            return File(fs, file_type, file_name);
        }
        public IActionResult GetVirtualFile() =>
            File("Files/hello.txt", "text/plain", "hello4.txt");
    }
    public record class Person(string Name, int Age);

    public class RoomController : LogBaseController
    {
        public string Index() => "Информацию о контроллере и методе смотрите в консоли";
    }

    [NonController]
    public class C1NonConroller : Controller
    {
        public string Index()
        {
            return "Hello METANIT.COM";
        }
    }

    public class C1Other : Controller
    {
        [NonAction]
        public string Hello()
        {
            return "Hello ASP.NET";
        }

        [ActionName("Welcome")]
        public string Helloo()
        {
            return "Hello ASP.NET";
        }
    }

}
