using finalProject.Context;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace finalProject.Controllers
{
    public class CategoryController : Controller
    {
        ShopContext db = new ShopContext();
        public IActionResult Index()
        {
            var categories = db.Categories;
            return View(categories);

        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Category c)
        {
            ModelState.Remove("Products");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields are Required");
                
                return View();
            }


            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (_category == null)
            {
                return RedirectToAction("Index");
            }
            

            return View(_category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ModelState.Remove("Products");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
               
                return View();
            }

            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(c=>c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
