using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;

namespace WebProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebProjectDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(WebProjectDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
