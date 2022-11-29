using ISiTApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISiTApp.Controllers
{
    public class TimeController : Controller
    {
        readonly ITimeService timeService;
        public TimeController(ITimeService timeServ)
        {
            timeService = timeServ;
        }
        public string Index() => timeService.Time;
        public string tService([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }
        public string Now()
        {
            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time ?? "Не определено";
        }
    }
}
