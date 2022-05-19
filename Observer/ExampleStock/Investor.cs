using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleStock
{
    public class Investor : IInvestor
    {
        private string _name;
        public Stock Stock { get; set; }

        public Investor(string name)
        {
            _name = name;
        }


        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", _name, stock.Symbol, stock.Price);
        }
    }
}
