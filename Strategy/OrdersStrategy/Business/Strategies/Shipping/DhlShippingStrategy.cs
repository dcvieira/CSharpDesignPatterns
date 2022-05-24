

using OrdersStrategy.Business.Models;

namespace OrdersStrategy.Business.Strategies.Shipping
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement DHL Shipping Integration

                Console.WriteLine("Order is shipped with DHL");
            }
        }
    }
}
