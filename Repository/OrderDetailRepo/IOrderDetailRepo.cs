using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepo
{
    public interface IOrderDetailRepo
    {
        void Save(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        IList<OrderDetail> GetOrderDetailByOrderId(int id);
        OrderDetail SearchOrderDetailByOrderIdAndByFlowerBouquetId(int orderId, int flowerBouquetId);
        bool Exist(int id);
    }
}
