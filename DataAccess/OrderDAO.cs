using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static IList<Order> GetOrders()
        {
            var list = new List<Order>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Orders.Include(c => c.Member).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static IList<Order> GetOrdersForReport(DateTime startDate, DateTime endDate)
        {
            var list = new List<Order>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Orders.Include(c => c.Member)
                        .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).OrderByDescending(o => o.Freight).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static Order GetOrder(int id)
        {
            Order order = new Order();
            var list = new List<Order>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Orders.Include(o => o.Member).ToList();
                    order = list.SingleOrDefault(o => o.OrderId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;

        }

        public static IList<Order> GetOrderByCustomerId(int customerId)
        {
            var list = new List<Order>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Orders.Include(c => c.Member).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;

        }
        public static void Save(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
        public static void Update(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Order>(order).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var p1 = context.Orders.SingleOrDefault(c => c.OrderId == order.OrderId);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static bool Exist(int id)
        {
            using (var context = new FStoreDBContext())
            {
                return context.Orders.Any(e => e.OrderId == id);
            }
        }
    }
}
    

