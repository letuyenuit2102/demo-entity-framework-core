using demo_entity_framework_core.DataAccess.Repository.IRepository;

namespace demo_entity_framework_core.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Product { get; set; }

        public ICategoryRepository Category { get; set; }
        public readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        { 
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
