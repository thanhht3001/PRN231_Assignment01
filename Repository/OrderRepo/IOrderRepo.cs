using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public interface IOrderRepo
    {
        void Save(Order order);
        void Delete(Order order);
        void Update(Order order);
        IList<Order> GetOrders();
        IList<Order> GetOrdersForReport(DateTime startDate, DateTime endDate);
        Order GetOrder(int id);
        IList<Order> GetOrderByCustomerId(int customerId);
        bool Exist(int id);
    }
}
