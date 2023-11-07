using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {

        public static IList<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Products.Include(c => c.Category).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static Product GetProduct(int id)
        {
            Product Product = new Product();
            var list = new List<Product>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Products.Include(c => c.Category).ToList();
                    Product = list.SingleOrDefault(f => f.ProductId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Product;

        }
        public static void Save(Product Product)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Products.Add(Product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Update(Product Product)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Product>(Product).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(Product Product)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    bool o = context.OrderDetails.Any(o => o.ProductId == Product.ProductId);
                    var _Product = context.Products.SingleOrDefault(f => f.ProductId == Product.ProductId);
                    if (o)
                    {
                        
                        //_Product. = 0;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Products.Remove(_Product);
                        context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IList<Product> SearchByName(string name)
        {
            var list = new List<Product>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    if (name != null)
                    {
                        list = context.Products
                        .Include(f => f.Category)
                        .Where(f => f.ProductName.Contains(name))
                        .ToList();
                    }
                    else
                    {
                        list = context.Products
                        .Include(f => f.Category)
                        .ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static bool Exist(int id)
        {
            using (var context = new FStoreDBContext())
            {
                return context.Products.Any(f => f.ProductId == id);
            }
        }
    }
}
