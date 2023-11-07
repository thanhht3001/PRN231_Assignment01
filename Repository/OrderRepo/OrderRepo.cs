using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public class OrderRepo : IOrderRepo
    {
        public void Save(Order order) => OrderDAO.Save(order);
        public void Delete(Order order) => OrderDAO.Delete(order);
        public void Update(Order order) => OrderDAO.Update(order);
        public IList<Order> GetOrders() => OrderDAO.GetOrders();
        public Order GetOrder(int id) => OrderDAO.GetOrder(id);
        public IList<Order> GetOrderByCustomerId(int customerId) => OrderDAO.GetOrderByCustomerId(customerId);
        public bool Exist(int id) => OrderDAO.Exist(id);
        public IList<Order> GetOrdersForReport(DateTime startDate, DateTime endDate) => OrderDAO.GetOrdersForReport(startDate, endDate);
    }
}
