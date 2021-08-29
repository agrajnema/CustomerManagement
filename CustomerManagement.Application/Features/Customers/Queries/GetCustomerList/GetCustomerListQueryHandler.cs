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

namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListVm>>
    {
        private readonly IGenericAsyncRepository<Customer> _asyncRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IGenericAsyncRepository<Customer> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerListVm>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _asyncRepository.GetAllAsync();
            return _mapper.Map<List<CustomerListVm>>(customers);
        }
    }
}
