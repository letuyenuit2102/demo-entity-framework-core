using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo_entity_framework_core.Models.ViewModels
{
	public class ProductVM
	{
		public List<Product> products;
		public Product product;
		public IEnumerable<SelectListItem> categories;
		public int PageIndex { get; set; }
		public int TotalPages { get; set; }
		public int Total { get; set; }
		public ProductVM(List<Product> items, int pageIndex, int totalPages, int total)
		{
			products = items;
			PageIndex = pageIndex;
			TotalPages = totalPages;
			Total = total;
		}

		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
	}
}
