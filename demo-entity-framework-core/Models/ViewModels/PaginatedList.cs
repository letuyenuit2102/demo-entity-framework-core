namespace demo_entity_framework_core.Models.ViewModels
{
	public class PaginatedList<T>
	{
		public List<T> Items { get; set; }
		public int PageIndex { get; set; }
		public int TotalPages { get; set; }

		public PaginatedList(List<T> items, int pageIndex, int totalPages)
		{
			Items = items;
			PageIndex = pageIndex;
			TotalPages = totalPages;
		}

		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
	}
}
