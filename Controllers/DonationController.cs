using Microsoft.AspNetCore.Mvc;
using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Policy;

namespace CommerceProject.Controllers
{
    public class DonationController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        //constructor
        public DonationController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            
            return View("DonationForm");
            //return View(new Donor_1());
        }

        //[HttpPost]
        //public ContentResult Index(Donor_1 donor) 
        //{
        //    return Content("Donation: " + donor.FundraiserTitle);
        //}



        //GET action method
        public IActionResult MakeDonation()
        {
            
            return View("DonationForm");
        }

        //POST Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeDonation(Donor_1 form, IFormCollection collection, string FundraiserName) {
            //if (ModelState.IsValid)
            {
                //string donType = form.DonationType.ToString();
                String donType = collection["PaymentMethod"];
                string msg = collection["DonorName"] + " donated " + collection["DonorAmount"] + " via " + donType;
                ViewBag.Message = msg;
                form.PaymentMethod = donType;
                if (TempData["FundraiserName"] == null) { 
                    form.FundraiserTitle = "Error";
                }
                else { 
                    form.FundraiserTitle = (string)TempData["FundraiserName"];
                    
                }

                IEnumerable<Fundraiser_1> fundraisers = _dbContext.Fundraiser_1s;
                foreach (Fundraiser_1 f in fundraisers)
                {
                    if (f.FundraiserName == (string)TempData["FundraiserName"])
                    {
                        double ca = Convert.ToDouble(f.FundraiserCurrentAmount);
                        ca += Convert.ToDouble(collection["DonorAmount"]);
                        f.FundraiserCurrentAmount = ca;
                        _dbContext.Fundraiser_1s.Update(f);
                        
                    }
                }


                _dbContext.Donor_1s.Add(form);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View("DonationForm");
        }


    }
}
