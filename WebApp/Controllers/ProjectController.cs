using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProjectDetail()
        {
            return View();
        }



    }
}
