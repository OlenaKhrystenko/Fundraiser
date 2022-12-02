using Microsoft.AspNetCore.Mvc;
using CommerceProject.Data;
using CommerceProject.Models;

namespace CommerceProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDBContext _db;

        public SearchController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult SearchForFundraiser()
        {
            return View("Search");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchForFundraiser(IFormCollection form) 
        { 
            IEnumerable<Fundraiser_1> fundraisers = _db.Fundraiser_1s;

            List<Fundraiser_1> sfundList = new List<Fundraiser_1>();
            foreach (Fundraiser_1 fundraiser in fundraisers)
            {
                if (fundraiser.FundraiserName.ToLower().Contains(form["search"].ToString().ToLower()))
                {
                    sfundList.Add(fundraiser);
                }
            }

            TempData["flist"] = sfundList;

            return View("Search");
        }
    }
}
