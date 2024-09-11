using finalProject.Context;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace finalProject.Controllers
{
    public class ProductController : Controller
    {
        ShopContext db = new ShopContext();
        [HttpGet]
        public IActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products);
        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Product p)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields are Required");
                ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View();
            }


            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View();
            }
            db.Products.Update(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

