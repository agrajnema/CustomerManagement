using CustomerManagement.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericAsyncRepository<Customer>
    {
        Task<List<Customer>> SearchCustomerByName(string name);
    }
}
