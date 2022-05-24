using OrdersStrategy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersStrategy.Business.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var filename = $"invoice_{Guid.NewGuid()}.txt";
            using (var stream = new StreamWriter(filename))
            {
                stream.Write(GenerateTextInvoice(order));

                stream.Flush();

                Console.WriteLine($"Invoice for order saved to {filename}");
            }
        }
    }
}
