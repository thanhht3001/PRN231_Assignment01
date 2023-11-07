using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        public IList<Category> GetCategories() => CategoryDAO.GetCategories();
    }
}
