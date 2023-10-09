using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace demo_entity_framework_core.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}
