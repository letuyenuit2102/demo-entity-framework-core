using demo_entity_framework_core.DataAccess.Repository.IRepository;
using demo_entity_framework_core.Models;
using demo_entity_framework_core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo_entity_framework_core.Controllers
{
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductController(IUnitOfWork unitOfWork) 
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index(int page = 1, int pageSize = 3)
		{
			var products = _unitOfWork.Product.GetAll(u => true, "Category");
			var categories = _unitOfWork.Category.GetAll();
			var totalItems = products.Count();
			var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
			var itemsOnPage = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			var total = products.Count();
			return View(new ProductVM(itemsOnPage, page , totalPages , total)
			{
				product = new Product(),
				categories = categories.Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString(),
				}),
				Total = total
			});
		}

		[HttpPost]
		public IActionResult Index(Product product)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Add(product);
				_unitOfWork.Save();
				return RedirectToAction("Index", "Product");
			}
			return RedirectToAction("Index", "Product");

		}

		[HttpPost]
		public IActionResult DeleteProduct(Guid id)
		{
			var product = _unitOfWork.Product.Get(u => u.Id == id);
			_unitOfWork.Product.Remove(product);
			_unitOfWork.Save();
			return Json(new { });
		}

		[HttpPost]
		public IActionResult DeleteMultipleProduct (List<Guid> ids)
		{
			var products = _unitOfWork.Product.GetAll(u => ids.Contains(u.Id));
			_unitOfWork.Product.RemoveRange(products);
			_unitOfWork.Save();
			return Json(new { });
		}
	}
}
