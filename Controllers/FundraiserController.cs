using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CommerceProject.Controllers
{
    public class FundraiserController : Controller
    {
        private readonly ApplicationDBContext _db;

        public FundraiserController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View(new Fundraiser_1());
        }

        [HttpPost]
        public ContentResult Index(Fundraiser_1 objFund) 
        {
            return Content("Fundraiser Name: " + objFund.FundraiserName + " " + objFund.FundraiserDescription);
        }

        public IActionResult ShowData(string FundraiserName, string Description, double CurrentAmount, double Goal) 
        {
            TempData["FundraiserName"] = FundraiserName;
            TempData["Description"] = Description;
            TempData["CurrentAmount"] = CurrentAmount;
            TempData["Goal"] = Goal;
            return View();
        }

        public IActionResult FundraiserListView(IFormCollection form) 
        {
            string name = form["FundraiserName"];
            TempData["FundraiserName"] = name;
            IEnumerable<Fundraiser_1> objFundraiserList = _db.Fundraiser_1s;
            return View(objFundraiserList);
        }

        
        public IActionResult StartFundraiser() 
        {
            //var user = TempData["user"];
            //if (user == null) 
            //{
            //    return RedirectToAction("demo", "Login");
            //}
            return View();
        }

        //public IActionResult CreateFundraiser()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateFundraiser(Fundraiser_1 obj, IFormCollection form)
        {
            obj.FundraiserCurrentAmount = 0.00;
            if (User.Identity.IsAuthenticated) {
                obj.Owner = User.Identity.Name;
            }
            obj.FundraiserName = form["title"];
            obj.FundraiserGoal = Convert.ToDouble(form["goal"]);
            obj.FundraiserDescription = form["description"];

            _db.Fundraiser_1s.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("FundraiserListView");
        }
    }
}
