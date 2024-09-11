using finalProject.Context;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.Controllers
{
    public class UserController : Controller
    {
        ShopContext db=new ShopContext();
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User u)
        {

            ModelState.Remove("Products");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields are Required");

                return View();
            }


            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Signin");
            
        }
        [HttpGet]
        public IActionResult Signin() { 
            return View();  
        }
        [HttpPost]
        
        public IActionResult Signin(User user)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            var _user=db.Users.FirstOrDefault(u=>u.Email==user.Email&& u.Password==user.Password);
            if (_user == null) {
                ViewBag.error = "Invalid User";
                return View("Register");
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
