using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Application.Exceptions;
using CustomerManagement.Domain.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IGenericAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IGenericAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerId);
            if(customerToUpdate == null)
            {
                // We can create a custom exception and throw the same
                throw new Exception($"Customer with Id: {request.CustomerId} not found");
            }

            var customerValidator = new UpdateCustomerCommandValidator();
            var validationResult = await customerValidator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            await _customerRepository.UpdateAsync(customerToUpdate);

            return Unit.Value;
        }

    }
}
