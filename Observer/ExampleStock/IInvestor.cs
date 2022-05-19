using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleStock
{
    public interface IInvestor
    {
        void Update(Stock stock);
    }
}
