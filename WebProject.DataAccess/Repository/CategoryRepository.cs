using System.Linq.Expressions;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models.Models;

namespace WebProject.DataAccess.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        private readonly WebProjectDbContext _context;
        public CategoryRepository(WebProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CategoryModel category)
        {
            _context.Update(category);
        }
    }
}