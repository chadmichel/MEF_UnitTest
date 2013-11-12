using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.TheCode
{
    public interface ICustomerAccessor
    {
        Customer Find(string customerId);

        void Save(Customer customer);
    }
}
