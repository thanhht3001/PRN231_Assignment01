using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepo
{
    public interface IProductRepo
    {
         void Save(Product product);
         void Delete(Product product);
         void Update(Product product);
         IList<Product> GetFlowers();
         Product GetFlower(int id);
         bool Exist(int id);
        public IList<Product> SearchByName(string name) => ProductDAO.SearchByName(name);
    }
}
