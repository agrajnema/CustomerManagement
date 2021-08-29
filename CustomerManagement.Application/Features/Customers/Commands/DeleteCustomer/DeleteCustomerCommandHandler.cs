using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Domain.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IGenericAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IGenericAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.CustomerId);

            if(customerToDelete == null)
            {
                // We can create a custom exception and throw the same
                throw new Exception($"Customer with Id: {request.CustomerId} not found");
            }
            await _customerRepository.DeleteAsync(customerToDelete);
            return Unit.Value;
        }
    }
}
