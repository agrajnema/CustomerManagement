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

namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerVm>
    {
        private readonly IGenericAsyncRepository<Customer> _asyncRepository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IGenericAsyncRepository<Customer> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<CustomerVm> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _asyncRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerVm>(customer);
        }
    }
}
