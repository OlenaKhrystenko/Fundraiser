using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class StartFundraisingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FirstStepFundraising()
        { 
            return View("FirstStepFund"); 
        }  
    }
}
