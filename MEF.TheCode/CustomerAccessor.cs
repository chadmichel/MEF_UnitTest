using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.TheCode
{
    [Export(typeof(ICustomerAccessor))]
    public class CustomerAccessor : ICustomerAccessor
    {
        public Customer Find(string customerId)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
