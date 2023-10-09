namespace demo_entity_framework_core.Models.ViewModels
{
	public class CategoryVM
	{
		public List<Category> categories;
		public Category category;
		public int PageIndex { get; set; }
		public int TotalPages { get; set; }
		public int Total { get; set; }
		public CategoryVM(List<Category> items, int pageIndex, int totalPages, int total)
		{
			categories = items;
			PageIndex = pageIndex;
			TotalPages = totalPages;
			Total = total;
		}

		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
	}
}
