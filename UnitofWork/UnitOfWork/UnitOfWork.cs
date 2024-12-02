using UnitofWork.Data;
using UnitofWork.Models;
using UnitofWork.Repositories;

namespace UnitofWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Product> _products;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);

        public int Commit() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
