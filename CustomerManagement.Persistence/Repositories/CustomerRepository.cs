using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerManagementDbContext dbContext): base(dbContext)
        {

        }
        public async Task<List<Customer>> SearchCustomerByName(string name)
        {
            return await _dbContext.Customer.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name)).ToListAsync();
        }
    }
}
