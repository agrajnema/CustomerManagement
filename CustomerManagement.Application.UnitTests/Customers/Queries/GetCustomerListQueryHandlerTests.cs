using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerList;
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
    public class GetCustomerListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;

        public GetCustomerListQueryHandlerTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCustomerListTest()
        {
            var handler = new GetCustomerListQueryHandler(_mockCustomerRepository.Object, _mapper);
            var result = await handler.Handle(new GetCustomerListQuery(), CancellationToken.None);
            result.Should().BeOfType<List<CustomerListVm>>();
            result.Count.Should().Be(2);
        }
    }
}
