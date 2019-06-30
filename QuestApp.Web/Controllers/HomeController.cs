using Microsoft.AspNetCore.Mvc;

namespace QuestApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
