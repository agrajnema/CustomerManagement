using AutoMapper;
using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using CustomerManagement.Domain.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerByName
{
    public class SearchCustomersByNameQueryHandler : IRequestHandler<SearchCustomersByNameQuery, List<CustomerListByNameVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public SearchCustomersByNameQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerListByNameVm>> Handle(SearchCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.SearchCustomerByName(request.Name);
            return _mapper.Map<List<CustomerListByNameVm>>(customers);
        }
    }
}
