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

        public IActionResult Edit(string? FundraiserName, string? FundraiserDescription, string? FundraiserGoal, string? Owner) {
            TempData["fname"] = FundraiserName;
            TempData["fdescr"] = FundraiserDescription;
            TempData["fgoal"] = FundraiserGoal;
            TempData["fowner"] = Owner;

            return View("EditF");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fundraiser_1 f, IFormCollection collection)
        {
            f.FundraiserName = collection["title"];
            f.FundraiserDescription = collection["description"];
            f.FundraiserGoal = Convert.ToDouble(collection["goal"]);
            f.Owner = User.Identity.Name;

            IEnumerable<Fundraiser_1> funds = _db.Fundraiser_1s;
            foreach (Fundraiser_1 objFund in funds)
            {
                if (objFund.FundraiserName == collection["title"])
                {
                    objFund.FundraiserName = collection["title"];
                    objFund.FundraiserDescription = collection["description"];
                    objFund.FundraiserGoal = Convert.ToDouble(collection["goal"]);
                    objFund.Owner = User.Identity.Name;
                    _db.Fundraiser_1s.Update(objFund);                  
                    
                    return RedirectToAction("Index", "Home");
                }
            }

            

            //_db.Fundraiser_1s.Update(f);
            //_db.SaveChanges();
            return View("EditF");
        }

        public IActionResult ShowData(string FundraiserName, string Description, double CurrentAmount, double Goal, string Owner) 
        {
            TempData["FundraiserName"] = FundraiserName;
            TempData["Description"] = Description;
            TempData["CurrentAmount"] = CurrentAmount;
            TempData["Goal"] = Goal;
            TempData["Owner"] = Owner;

            List<string> donorsList = new List<string>();
            IEnumerable<Donor_1> donors = _db.Donor_1s;
            foreach (Donor_1 donor in donors)
            {
                if (FundraiserName == donor.FundraiserTitle)
                {
                    donorsList.Add(donor.DonorName);
                }
            }

            TempData["list"] = donorsList;

            TempData["donorsnumber"] = donorsList.Count;

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
