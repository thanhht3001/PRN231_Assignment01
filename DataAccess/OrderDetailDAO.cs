using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
       
        public static IList<OrderDetail> GetOrderDetailByOrderId(int orderid)
        {
            var list = new List<OrderDetail>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.OrderDetails.Include(o => o.Product).Where(o => o.OrderId == orderid).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;

        }
        public static void Save(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var order = context.Orders.SingleOrDefault(o => o.OrderId == orderDetail.OrderId);
                    order.Freight += (orderDetail.UnitPrice * orderDetail.Quantity) * (decimal)((100 - orderDetail.Discount) / 100);
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
        public static void Update(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<OrderDetail>(orderDetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Remove(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static OrderDetail SearchOrderDetailByOrderIdAndByProductId(int orderId, int productId)
        {
            var orderDetail = new OrderDetail();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    if (orderId != 0 && productId != 0)
                    {
                        orderDetail = context.OrderDetails.Include(f => f.Product).Include(o => o.Order).SingleOrDefault(o => o.OrderId == orderId && o.ProductId == productId);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }

        public static bool Exist(int id)
        {
            using (var context = new FStoreDBContext())
            {
                return context.OrderDetails.Any(e => e.OrderId == id);
            }
        }
    }
}

