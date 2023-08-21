using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebProjectMVC.Models;

namespace WebProjectMVC.Data
{
    public class WebProjectDbContext : DbContext
    {
        public virtual DbSet<CategoryModel>? Categories { get; set; }

        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
