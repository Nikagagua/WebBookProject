using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models.Models;

namespace WebProject.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        void Update(CategoryModel category);
    }
}
