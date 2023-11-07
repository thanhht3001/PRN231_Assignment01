using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        public IList<Product> GetFlowers() => ProductDAO.GetProducts();
        public Product GetFlower(int id) => ProductDAO.GetProduct(id);
        public bool Exist(int id) => ProductDAO.Exist(id);
        public void Save(Product product) => ProductDAO.Save(product);
        public void Delete(Product product) => ProductDAO.Delete(product);
        public void Update(Product product) => ProductDAO.Update(product);
        IList<Product> SearchByName(string name) => ProductDAO.SearchByName(name);
    }
}
