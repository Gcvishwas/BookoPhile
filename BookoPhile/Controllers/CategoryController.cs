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
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(Category category)
        {
            if (!String.IsNullOrEmpty(category.Name) && !await _categoryServices.IsCategoryNameUniqueAsync(category.Name))
            {
                ModelState.AddModelError("", "Category name already exists");
            }
            if(ModelState.IsValid)
            {
                await _categoryServices.CreateCategoryAsync(category);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = await _categoryServices.GetCategoryByIdAsync(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(Category category)
        {
            if (!String.IsNullOrEmpty(category.Name) &&
                !await _categoryServices.IsCategoryNameUniqueAsync(category.Name, category.Id))
            {
                ModelState.AddModelError("", "Category name already exists");
            }

            if (ModelState.IsValid)
            {
                await _categoryServices.UpdateCategoryAsync(category);

                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = await _categoryServices.GetCategoryByIdAsync(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteItem(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            await _categoryServices.DeleteCategoryAsync(Id.Value);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("index");
        }
    }
}
