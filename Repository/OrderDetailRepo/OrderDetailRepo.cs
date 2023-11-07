using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepo
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        public void Save(OrderDetail orderDetail) => OrderDetailDAO.Save(orderDetail);
        public void Delete(OrderDetail orderDetail) => OrderDetailDAO.Delete(orderDetail);
        public void Update(OrderDetail orderDetail) => OrderDetailDAO.Update(orderDetail);
        public IList<OrderDetail> GetOrderDetailByOrderId(int id) => OrderDetailDAO.GetOrderDetailByOrderId(id);
        public OrderDetail SearchOrderDetailByOrderIdAndByFlowerBouquetId(int orderId, int flowerBouquetId) => OrderDetailDAO.SearchOrderDetailByOrderIdAndByProductId(orderId, flowerBouquetId);
        public bool Exist(int id) => OrderDetailDAO.Exist(id);
    }
}
