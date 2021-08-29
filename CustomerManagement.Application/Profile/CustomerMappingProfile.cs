using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagement.Application.Features.Customers.Commands.CreateCustomer;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerByName;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerList;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using CustomerManagement.Domain.Customer;
using CustomerManagement.Application.Features.Customers.Commands.UpdateCustomer;

namespace CustomerManagement.Application.Profile
{
    public class CustomerMappingProfile : AutoMapper.Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerVm>().ReverseMap();
            CreateMap<Customer, CustomerListVm>().ReverseMap();
            CreateMap<Customer, CustomerListByNameVm>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }
    }
}
