using demo_entity_framework_core.DataAccess.Repository.IRepository;
using demo_entity_framework_core.Models;

namespace demo_entity_framework_core.DataAccess.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
