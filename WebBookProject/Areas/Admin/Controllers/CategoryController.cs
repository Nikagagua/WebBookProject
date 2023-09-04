using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models.Models;
using WebProject.Utility;

namespace WebBookProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.RoleAdmin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }

        public IActionResult Index()
        {
            if (_unitOfWork.Category.GetAll() == null)
            {
                throw new ArgumentNullException(nameof(_unitOfWork.Category.GetAll));
            }

            List<Category> categories = _unitOfWork.Category.GetAll().ToList();

            return View(categories);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (string.Equals(category.Name, category.DisplayOrder.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
                }
                else if (!string.IsNullOrEmpty(category.Name) && category.Name.Contains("test", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "Names containing 'test' are not allowed.");
                }
                else
                {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();

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
        [Route("Admin/Category/Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (string.Equals(category.Name, category.DisplayOrder.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
                }
                else if (!string.IsNullOrEmpty(category.Name) && category.Name.Contains("test", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Name", "Names containing 'test' are not allowed.");
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();

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
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            // Notifications
            if (TempData["Success"] == null)
            {
                TempData["Success"] = "Category deleted successfully";
            }
            else if (TempData["Error"] == null)
            {
                TempData["Error"] = "There was an error deleting the category";
            }

            return RedirectToAction("Index", "Category");
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = categoryList });
        }

        #endregion API CALLS
    }
}