using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CategoryRepo
{
    public interface ICategoryRepo
    {
        IList<Category> GetCategories();
    }
}
