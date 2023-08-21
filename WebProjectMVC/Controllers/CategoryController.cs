using Microsoft.AspNetCore.Mvc;
using WebProjectMVC.Data;
using WebProjectMVC.Models;

namespace WebProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WebProjectDbContext _context;

        public CategoryController(WebProjectDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            if (_context.Categories == null)
                {
                    throw new ArgumentNullException(nameof(_context.Categories));
                }

            List<CategoryModel> categories = _context.Categories.ToList();
            
            return View(categories);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                if (string.Equals(category.Name, category.DisplayOrder?.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
                }
                else if (!string.IsNullOrEmpty(category.Name) && category.Name.Contains("test", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "Names containing 'test' are not allowed.");
                }
                else
                {
                    _context?.Categories?.Add(category);
                    _context?.SaveChanges();
                    TempData["Success"] = "Category created successfully";
                    return RedirectToAction("Index", "Category");
                }
            }
            return View(category);
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            CategoryModel? categoryFromDb = _context?.Categories?.FirstOrDefault(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                if (string.Equals(category.Name, category.DisplayOrder?.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
                }
                else if (!string.IsNullOrEmpty(category.Name) && category.Name.Contains("test", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "Names containing 'test' are not allowed.");
                }
                else
                {
                    _context?.Categories?.Update(category);
                    _context?.SaveChanges();
                    TempData["Success"] = "Category updated successfully";
                    return RedirectToAction("Index", "Category");
                }
            }
            return View(category);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            CategoryModel? categoryFromDb = _context?.Categories?.FirstOrDefault(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Guid? Id)
        {
            CategoryModel? category = _context?.Categories?.FirstOrDefault(c => c.CategoryId == Id);
            if (category == null)
            {
                return NotFound();
            }
            _context?.Categories?.Remove(category);
            _context?.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
