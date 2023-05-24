using DataAccess.DataAcces;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByID(int orderId) => OrderDAO.Instance.GetOrderByID(orderId);
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();
        public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderID) => OrderDAO.Instance.Remove(orderID);
        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
    }
}
