using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerByName
{
    public class SearchCustomersByNameQuery : IRequest<List<CustomerListByNameVm>>
    {
        public string Name { get; set; }

    }
}
