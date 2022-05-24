

using OrdersStrategy.Business.Models;

namespace OrdersStrategy.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
