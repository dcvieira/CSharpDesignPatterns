using OrdersStrategy.Business.Models;
using System;
using System.Net.Http;


namespace OrdersStrategy.Business.Strategies.Shipping
{
    public class UnitedStatesPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement USPS Shipping Integration
                
                Console.WriteLine("Order is shipped with USPS");
            }
        }
    }
}
