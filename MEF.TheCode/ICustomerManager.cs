using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.TheCode
{
    public interface ICustomerManager
    {        
        /// <summary>
        /// Upgrade customer to a pro customer.
        /// </summary>        
        void Upgrade(string customerId);

    }
}
