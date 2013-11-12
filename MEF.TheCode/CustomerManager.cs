using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.TheCode
{
    public class CustomerManager : ICustomerManager
    {
        [Import]
        public ICustomerAccessor CustomerAccessor { get; set; }

        public void Upgrade(string customerId)
        {
            // To upgrade a customer we must first find the customer.
            var customer = CustomerAccessor.Find(customerId);
            // Set Pro equal to true.
            customer.Pro = true;
            // Save the customer.
            CustomerAccessor.Save(customer);
        }
    }
}
