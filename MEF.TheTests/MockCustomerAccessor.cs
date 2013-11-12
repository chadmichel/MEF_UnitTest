using MEF.TheCode;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.TheTests
{
    [Export(typeof(ICustomerAccessor))]
    public class MockCustomerAccessor : ICustomerAccessor
    {
        List<Customer> customers = new List<Customer>();

        public Customer Find(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
                throw new ArgumentNullException("customerId");

            return customers.Where(c => c.Id == customerId).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            if (customers.Where(c => c.Id == customer.Id).Count() > 0)
            {
                customers.Remove(customers.Where(c => c.Id == customer.Id).First());
            }

            customers.Add(customer);
        }
    }

}
