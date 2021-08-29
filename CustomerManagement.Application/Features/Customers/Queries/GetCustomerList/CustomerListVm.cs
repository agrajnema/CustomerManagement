using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerList
{
    //Created a View Model for the client application as we might not want to show all the entity properties,
    //in this case this is the same as entity, returing all the properties of Customer
    public class CustomerListVm
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
