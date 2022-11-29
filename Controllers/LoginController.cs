using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.Dynamic;
using System.Security.Claims;

namespace CommerceProject.Controllers
{
    //[Authorize]//11/21/2022
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _db;

        private readonly IHttpContextAccessor _contextAccessor;//11/21/2022

        //constructor
        public LoginController(ApplicationDBContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _contextAccessor = contextAccessor;//11/21/2022 
        }

        public IActionResult UserProfile() 
        {
            IEnumerable<User_1> allUsers = _db.User_1s;
            List<User_1> users = _db.User_1s.ToList();

            var uname = _contextAccessor.HttpContext.Session.GetString("username");

            string duplicate = "";
            int userid = 0; 

            int count = 0;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == uname)
                {
                    count++;
                    userid = users[i].UserId;
                    if (count > 1)
                    {
                        duplicate = users[i].UserName;
                        userid = users[i].UserId;
                    }
                }
            }

            //foreach (var us in allUsers)
            //{
            //    if (uname == us.UserName && us.UserId != userid && count > 1)
            //    { 
            //        _db.User_1s.Remove(us);
            //    }
            //}

            if (!string.IsNullOrEmpty(uname))
            {
                foreach (var user in allUsers)
                {
                    if (uname == user.UserName && user.UserId == userid)
                    {
                        TempData["username"] = user.UserName;
                        TempData["fullname"] = user.FullName;
                        TempData["dob"] = user.Dob;
                        TempData["address"] = user.Address;
                        TempData["email"] = user.Email;

                        return View("UserProfile");
                    }
                }

            }
            return View("Index");

            //var usrs = getUser();
            //var dnrs = getDonor();
            //var fndrs = getFundraiser();

            //MultipleModelsVM model = new MultipleModelsVM();
            //model.Userss = usrs;
            //model.Donorss = dnrs;
            //model.Fundraiserss = fndrs;

            //return View(model);
        }

        public User_1 getUser()//11/25/2022
        {
            IEnumerable<User_1> allUsers = _db.User_1s;
            var uname = _contextAccessor.HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(uname))
            {
                foreach (var user in allUsers) 
                {
                    if (uname == user.UserName)
                    { 
                        return user;
                    }
                }
            }
            return new User_1();
        }

        public IEnumerable<Fundraiser_1> getFundraiser()//11/25/2022 
        {
            IEnumerable<Fundraiser_1> allFundraisers = _db.Fundraiser_1s;
            return allFundraisers;
        }

        public Donor_1 getDonor()//11/25/2022
        { 
            IEnumerable<Donor_1> allDonors = _db.Donor_1s;
            List<User_1> userList = _db.User_1s.ToList();
            var uname = _contextAccessor.HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(uname))
            {
                foreach (var donor in allDonors)
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        if (donor.DonorName == userList.ElementAt(i).FullName)
                        {
                            return donor;
                        }
                    }
                }
            }
            return new Donor_1();
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Test()
        {
            IEnumerable<User_1> users = _db.User_1s;
            return View("Demo");
        }

        public string NewUserCreated() {
            return "New User was successfully created.";
        }
        
        public IActionResult testcase()
        {
            IEnumerable<User_1> users = _db.User_1s;
            return View("Demo");
        }

        public string NewUserNotCreated()
        {
            return "New User was not created.";
        }

        //Get Edit Method
        public IActionResult Edit(string? username, string? fullname, string? dob, string? address, string? email) {
            if (username == null) 
            {
                return NotFound();
            }
            //var usernameFromDB = _db.User_1s.Find(userId);
            //var usernameFromDBFisrt = _db.User_1s.FirstOrDefault(u => u.UserName == username);
            //var usernameFromDBSingle = _db.User_1s.SingleOrDefault(u => u.UserName == username);

            //if (usernameFromDB == null)
            //{
            //    return NotFound();
            //}

            TempData["username"] = username;
            TempData["fullname"] = fullname;
            TempData["dob"] = dob;
            TempData["address"] = address;
            TempData["email"] = email;

            //return View(usernameFromDB);


            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User_1 obj, IFormCollection form)
        {
            string name = form["UserName"];
            string pass = "";
            string sq1 = "";
            string sq2 = "";
            string sq3 = "";

            if (name != null)
            {
                IEnumerable<User_1> users = _db.User_1s;
                foreach (User_1 user in users)
                {
                    if (user.UserName == name)
                    { 
                        pass = user.Password; ;
                        sq1 = user.SequrityQuestion1;
                        sq2 = user.SequrityQuestion2;
                        sq3 = user.SequrityQuestion3;
                        break;
                    }
                }
            }

            obj.Password = pass;
            obj.SequrityQuestion1 = sq1;
            obj.SequrityQuestion2 = sq2;
            obj.SequrityQuestion3 = sq3;

            _db.User_1s.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("UserProfile");
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST action method
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create(User_1 obj, IFormCollection form)
        {

            IEnumerable<User_1> objLoginList = _db.User_1s;

            string pwd = form["Password"];
            string confirmPwd = form["ConfirmPassword"];
            string userName = form["UserName"];

            string errorMsg = "";

            if (objLoginList != null)
            {
                foreach (User_1 login in objLoginList)
                {
                    if (userName == login.UserName)
                    {
                        errorMsg += "Login already exists.";
                    }
                }
            }
            if (pwd != confirmPwd)
            {
                errorMsg += "Password and Confirm Password must match.";
            }

            if (errorMsg != "")
            {
                ViewBag.Message = errorMsg;
                obj.UserName = userName;
                obj.Password = pwd;

                return View("Create");
            }


            //if (ModelState.IsValid)
            {   
                if (errorMsg.Length == 0) {
                    obj.Address = " ";
                    obj.Dob = " ";
                    obj.Email = " ";
                obj.Password = form["Password"];
                    _db.User_1s.Add(obj);    //add new entry to DB
                    _db.SaveChanges();      //goes to the DB and saves all the changes  
                    //return RedirectToAction("Index");
                
                    return RedirectToAction("NewUserCreated");
                } 

            }
            return View("Create");  
        }

        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection form/*, string ReturnUrl*/) 
        {
            string usr = form["UserName"];
            string pwd = form["Password"];

            string yes = "no";
            IEnumerable<User_1> objLoginList = _db.User_1s;
            if (objLoginList != null)
            {
                foreach (User_1 login in objLoginList)
                {
                    if (login.UserName == usr && login.Password == pwd)
                    {
                        yes = "yes";

                        _contextAccessor.HttpContext.Session.SetString("username", usr);
                        _contextAccessor.HttpContext.Session.SetString("password", pwd);

                        TempData["user"] = usr;

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, login.UserName)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(claimsIdentity);

                        var props = new AuthenticationProperties();

                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();


                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                        ViewBag.Message = "You are successfuly logged in.";

                        //return Redirect(ReturnUrl == null ? "/Home/Index" : ReturnUrl);
                        //return View("Demo");
                        //return View("UserProfile");//11/25//2022
                        return RedirectToAction("UserProfile");
                    }
                }
            }
            ViewBag.Message = "Your login or password is incorrect";
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult demo(IFormCollection form)
        {
            
            string usr = form["UserName"];
            string pwd = form["Password"];

                string yes = "no";
                IEnumerable<User_1> objLoginList = _db.User_1s;
                if (objLoginList != null)
                {
                    foreach (User_1 login in objLoginList)
                    {
                        if (login.UserName == usr && login.Password == pwd)
                        {
                            yes = "yes";

                        _contextAccessor.HttpContext.Session.SetString("username", usr);
                        _contextAccessor.HttpContext.Session.SetString("password", pwd);

                        TempData["user"] = usr;

                            ViewBag.Message = "You are successfuly logged in.";
                            //return RedirectToAction("Create");
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ViewBag.Message = "Your login or password is incorrect";
                return View("Index");
           // }
        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        { 
            await HttpContext.SignOutAsync();
            
            return RedirectToAction("Index", "Home");
        }

 
     
    }
}
