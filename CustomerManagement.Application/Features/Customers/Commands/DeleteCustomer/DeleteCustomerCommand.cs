using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
