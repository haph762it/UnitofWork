using UnitofWork.Models;
using UnitofWork.Repositories;

namespace UnitofWork.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        int Commit();
    }
}
