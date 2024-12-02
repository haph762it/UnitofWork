using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitofWork.Data;

namespace UnitofWork.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id) => _dbSet.Find(id);

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Remove(T entity) => _dbSet.Remove(entity);
    }
}
