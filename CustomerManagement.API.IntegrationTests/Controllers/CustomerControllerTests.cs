using CustomerManagement.Api;
using CustomerManagement.API.IntegrationTests.Setup;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerList;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.API.IntegrationTests.Controllers
{
    public class CustomerControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public CustomerControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllCustomers()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/customer");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CustomerListVm>>(responseString);
            Assert.IsType<List<CustomerListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
