using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult SearchForFundraiser() { 
            //to do
            return View("Search");
        }
    }
}
