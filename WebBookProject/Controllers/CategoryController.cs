using Microsoft.AspNetCore.Mvc;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models.Models;

namespace WebBookProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork __unitOfWork;

        public CategoryController(IUnitOfWork context)
        {
            __unitOfWork = context;
        }

        public IActionResult Index()
        {
            if (__unitOfWork.Category.GetAll() == null)
                {
                    throw new ArgumentNullException(nameof(__unitOfWork.Category.GetAll));
                }

            List<CategoryModel> categories = __unitOfWork.Category.GetAll().ToList();
            
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
                    __unitOfWork.Category.Add(category);
                    __unitOfWork.Save();

                    // Notifications 
                    if (TempData["Success"] == null)
                    {
                        TempData["Success"] = "Category created successfully";
                    }
                    else if (TempData["Error"] == null)
                    {
                        TempData["Error"] = "There was an error deleting the category";
                    }
                    
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

            CategoryModel? categoryFromDb = __unitOfWork.Category.Get(c => c.CategoryId == id);
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
                    __unitOfWork.Category.Update(category);
                    __unitOfWork.Save();

                    // Notifications 
                    if (TempData["Success"] == null)
                    {
                        TempData["Success"] = "Category updated successfully";
                    }
                    else if (TempData["Error"] == null)
                    {
                        TempData["Error"] = "There was an error updating the category";
                    }
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
            CategoryModel? categoryFromDb = __unitOfWork.Category.Get(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Guid? Id)
        {
            CategoryModel? category = __unitOfWork.Category.Get(c => c.CategoryId == Id);
            if (category == null)
            {
                return NotFound();
            }
            __unitOfWork.Category.Remove(category);
            __unitOfWork.Save();

            // Notifications 
            if (TempData["Success"] == null)
            {
                TempData["Success"] = "Category removed successfully";
            }
            else if (TempData["Error"] == null)
            {
                TempData["Error"] = "There was an error deleting the category";
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
