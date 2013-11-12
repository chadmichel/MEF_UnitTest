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
    public class CustomerManager_IntegrationTests
    {
        private CustomerManager SetupCustomerManager()
        {
            //var catalog = new TypeCatalog(typeof(CustomerAccessor));
            var catalog = new TypeCatalog(typeof(MockCustomerAccessor));
            var configuration = new CompositionContainer(catalog);

            var customerManager = new CustomerManager();
            configuration.ComposeParts(customerManager);
            return customerManager;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomerManager_Integration_Upgrade_NullCustomerId()
        {
            var customerManager = SetupCustomerManager();

            var customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Unit Test",
            };

            customerManager.CustomerAccessor.Save(customer);

            customerManager.Upgrade(customer.Id);

            Assert.IsTrue(customer.Pro);
        }
    }
}
