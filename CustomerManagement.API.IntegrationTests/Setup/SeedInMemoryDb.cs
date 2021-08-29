using CustomerManagement.Domain.Customer;
using CustomerManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.API.IntegrationTests.Setup
{
    public static class SeedInMemoryDb
    {
        public static void InitializeTestDb(CustomerManagementDbContext context)
        {
            var customer1Id = Guid.Parse("{5e8b6eb6-f831-4508-8547-ecbb3153d617}");
            var customer2Id = Guid.Parse("{b151edb6-7323-4129-83f4-6f1f48832bd0}");

            context.Customer.Add(new Customer
            {
                CustomerId = customer1Id,
                FirstName = "Agraj",
                LastName = "Nema",
                DateOfBirth = Convert.ToDateTime("01/01/1990")
            });

            context.Customer.Add(new Customer
            {
                CustomerId = customer2Id,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = Convert.ToDateTime("10/01/2000")
            });
            context.SaveChanges();

        }
    }
}
