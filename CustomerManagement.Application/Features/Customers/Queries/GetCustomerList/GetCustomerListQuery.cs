using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
