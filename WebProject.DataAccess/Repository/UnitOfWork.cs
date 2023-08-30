using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;

namespace WebProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebProjectDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(WebProjectDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}