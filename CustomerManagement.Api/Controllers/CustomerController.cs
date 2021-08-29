using CustomerManagement.Application.Features.Customers.Commands.CreateCustomer;
using CustomerManagement.Application.Features.Customers.Commands.DeleteCustomer;
using CustomerManagement.Application.Features.Customers.Commands.UpdateCustomer;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerByName;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using CustomerManagement.Application.Features.Customers.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name="GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerListVm>>> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return Ok(customers);
        }

        [HttpGet("{id}", Name ="GetCustomerById")]
        public async Task<ActionResult<CustomerVm>> GetCustomerById(Guid id)
        {
            var getCustomerByIdQuery = new GetCustomerQuery() { Id = id };
            return Ok(await _mediator.Send(getCustomerByIdQuery));
        }

        [HttpGet("search/{name}", Name = "SearchCustomersByName")]
        public async Task<ActionResult<CustomerListByNameVm>> SearchCustomersByName(string name)
        {
            var searchCustomersByNameQuery = new SearchCustomersByNameQuery() { Name = name };
            var searchedCustomers = await _mediator.Send(searchCustomersByNameQuery);
            return Ok(searchedCustomers);
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerCommand createEventCommand)
        {
            var customerId = await _mediator.Send(createEventCommand);
            return Ok(customerId);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }

        [HttpDelete("{customerId}", Name ="DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid customerId)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { CustomerId = customerId };
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
    }
}
