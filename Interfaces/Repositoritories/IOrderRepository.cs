using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveOrders(List<Order> orders);
        public void Delete(int orderId);
        List<Order>? GetAllOrders();
        Order GetOrder(int id);
    }
}