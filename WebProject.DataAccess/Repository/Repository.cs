using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;

namespace WebProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebProjectDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(WebProjectDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            
            var result = query.FirstOrDefault();
            if (result == null)
            {
                throw new InvalidOperationException("No matching entity found.");
            }
            
            return result;
        }


        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
