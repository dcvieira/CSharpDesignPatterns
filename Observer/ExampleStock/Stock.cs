using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleStock
{
    public abstract class Stock
    {
        private string _symbol;
        private double _price;
        private List<IInvestor> investors = new List<IInvestor>();

        public string Symbol 
        {
            get => _symbol; 
        }

        public double Price { 
            get => _price; 
            set
            {
                if(_price != value)
                {
                    _price = value;
                    Notify();
                }
            } 
        }

        protected Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
    }
}
