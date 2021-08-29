using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Application.Features.Customers.Commands.CreateCustomer;
using CustomerManagement.Application.Profile;
using CustomerManagement.Application.UnitTests.Mocks;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Application.UnitTests.Customers.Commands
{
    public class CreateCustomerCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;

        public CreateCustomerCommandTests()
        {
            _mockCustomerRepository = CustomerRepositoryMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(m =>
            {
                m.AddProfile<CustomerMappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_Add_Customer()
        {
            var handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mapper);
            await handler.Handle(new CreateCustomerCommand() 
                { FirstName = "Test", LastName = "User", DateOfBirth = Convert.ToDateTime("01/01/1990") }, CancellationToken.None);

            var customers = await _mockCustomerRepository.Object.GetAllAsync();
            customers.Count.Should().Be(3);
        }
    }
}
