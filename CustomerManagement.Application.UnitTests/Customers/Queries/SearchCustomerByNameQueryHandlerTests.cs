using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerByName;
using CustomerManagement.Application.Profile;
using CustomerManagement.Application.UnitTests.Mocks;
using CustomerManagement.Domain.Customer;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Application.UnitTests.Customers.Queries
{
    public class SearchCustomerByNameQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        public SearchCustomerByNameQueryHandlerTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task SearchCustomersByNameTest()
        {
            var handler = new SearchCustomersByNameQueryHandler(_mapper, _mockCustomerRepository.Object);
            var result = await handler.Handle(new SearchCustomersByNameQuery() { Name = "Agraj"}, CancellationToken.None);

            result.Should().BeOfType<List<CustomerListByNameVm>>();
            result.Count.Should().Be(1);
        }

    }
}
