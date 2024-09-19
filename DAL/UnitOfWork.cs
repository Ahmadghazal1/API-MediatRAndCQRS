using Core;
using Core.IRepositories;
using DAL.Data;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository CategoryRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            CategoryRepository = new CategoryRepository(_context);
        }
        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
