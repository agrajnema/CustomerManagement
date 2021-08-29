using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Domain.Customer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.UnitTests.Mocks
{
    public class CustomerRepositoryMock
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customer1Id = Guid.Parse("{d021697d-fe1e-4ba1-8746-84a6dcdc6fd5}");
            var customer2Id = Guid.Parse("{7ddd876c-4d68-4cf0-b3ad-6c14fca2aa67}");

            var customer1 =
                new Customer
                {
                    CustomerId = customer1Id,
                    FirstName = "Agraj",
                    LastName = "Nema",
                    DateOfBirth = Convert.ToDateTime("01/01/1990")
                };

            var customer2 = new Customer
            {
                CustomerId = customer2Id,
                FirstName = "John",
                LastName = "Paul",
                DateOfBirth = Convert.ToDateTime("01/02/1990")
            };

            var customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            var filteredCustomerList = new List<Customer>();
            filteredCustomerList.Add(customer1);
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(c => c.GetAllAsync()).ReturnsAsync(customers);
            mockCustomerRepository.Setup(c => c.AddAsync(It.IsAny<Customer>())).ReturnsAsync(
                (Customer customer) =>
                {
                    customers.Add(customer);
                    return customer;
                });
            mockCustomerRepository.Setup(c => c.SearchCustomerByName("Agraj")).ReturnsAsync(filteredCustomerList);
                
            return mockCustomerRepository;
        }


    }
}
