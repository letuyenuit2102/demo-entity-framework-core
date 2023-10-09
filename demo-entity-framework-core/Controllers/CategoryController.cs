using demo_entity_framework_core.DataAccess.Repository;
using demo_entity_framework_core.DataAccess.Repository.IRepository;
using demo_entity_framework_core.Models;
using demo_entity_framework_core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo_entity_framework_core.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _iUnitOfWork;
		public CategoryController(IUnitOfWork unitOfWork) 
		{ 
			_iUnitOfWork = unitOfWork;
		}
		public IActionResult Index(int page = 1, int pageSize = 3)
		{
			var categories = _iUnitOfWork.Category.GetAll();
			var totalItems = categories.Count();
			var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
			var itemsOnPage = categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			var total = categories.Count();
			return View(new CategoryVM(itemsOnPage, page, totalPages, total)
			{
				category = new Category(),
				Total = total
			});
		}

		[HttpPost]
		public IActionResult Index(Category category)
		{
			if (ModelState.IsValid)
			{
				Boolean.TryParse(category.Id.ToString(), out var checkId);
				_iUnitOfWork.Category.Add(category);
				_iUnitOfWork.Save();
			}
			return RedirectToAction("Index" , "Category");
		}

		[HttpGet]
		public IActionResult EditCategory(Guid id)
		{
			var Category = _iUnitOfWork.Category.Get(u => u.Id == id);

			return View(Category);
		}

		[HttpPost]
		public IActionResult EditCategory(Category category)
		{
			if (ModelState.IsValid)
			{
				_iUnitOfWork.Category.Update(category);
				_iUnitOfWork.Save();
				return RedirectToAction("Index", "Category");
			}
			return RedirectToAction("Index" , "Category");
		}

		[HttpPost]
		public IActionResult DeleteCategory(Guid id)
		{
			var category = _iUnitOfWork.Category.Get(u => u.Id == id);
			_iUnitOfWork.Category.Remove(category);
			_iUnitOfWork.Save();
			return Json(new {});
		}

		[HttpPost]
		public IActionResult DeleteMultipleCategory(List<Guid> ids)
		{
			var categories = _iUnitOfWork.Category.GetAll(u => ids.Contains(u.Id));
			_iUnitOfWork.Category.RemoveRange(categories);
			_iUnitOfWork.Save();
			return Json(new { });
		}
	}
}
