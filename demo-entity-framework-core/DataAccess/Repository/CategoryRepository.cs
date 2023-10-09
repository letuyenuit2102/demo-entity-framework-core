using demo_entity_framework_core.DataAccess.Repository.IRepository;
using demo_entity_framework_core.Models;

namespace demo_entity_framework_core.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
