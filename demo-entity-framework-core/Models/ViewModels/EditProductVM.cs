using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo_entity_framework_core.Models.ViewModels
{
	public class EditProductVM
	{
		public Product product { get; set;}
		public IEnumerable<SelectListItem> categories { get; set;}
	}
}
