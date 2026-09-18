using BookoPhile.Business.Services.IServices;
using BookoPhile.Data;
using BookoPhile.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookoPhile.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public IActionResult Index()
        {
            var categories = _categoryServices.GetCategoriesAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(Category category)
        {
            if (!String.IsNullOrEmpty(category.Name) && _context.Categories.Any(c => c.Name == category.Name))
            {
                ModelState.AddModelError("", "Category name already exists");
            }
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(Id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(Category category)
        {
            if(!String.IsNullOrEmpty(category.Name) && _context.Categories.Any(c=>c.Name.ToLower()==category.Name.ToLower() && c.Id != category.Id))
            {
                ModelState.AddModelError("", "Category name already exists");
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? Id) 
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public IActionResult DeleteItem(int? Id)
        {
            var category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("index");
        }
    }
}
