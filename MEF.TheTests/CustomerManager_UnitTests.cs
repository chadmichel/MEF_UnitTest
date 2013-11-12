using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEF.TheCode;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace MEF.TheTests
{
    [TestClass]
    public class CustomerManager_UnitTests
    {
        private CustomerManager SetupCustomerManager()
        {
            // For unit tests we configure a mock customer accessor.
            // We will not actually hit the database for our mock customer
            // tests.
            var catalog = new TypeCatalog(typeof(MockCustomerAccessor));
            var configuration = new CompositionContainer(catalog);

            // Return a customer manager with the property CustomerAccessor set.
            var customerManager = new CustomerManager();
            configuration.ComposeParts(customerManager);
            return customerManager;
        }        

        [TestMethod]        
        public void CustomerManager_Unit_Upgrade()
        {
            var customerManager = SetupCustomerManager();
            
            var customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Unit Test",
            };

            customerManager.CustomerAccessor.Save(customer);

            Assert.IsFalse(customer.Pro);

            customerManager.Upgrade(customer.Id);

            Assert.IsTrue(customer.Pro);
        }
    }
}
