using Microsoft.AspNetCore.Mvc;

namespace ManagementStudentWithNHibernate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }
    }
}
