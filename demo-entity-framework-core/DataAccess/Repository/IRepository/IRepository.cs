using System.Linq.Expressions;

namespace demo_entity_framework_core.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);

    }
}
