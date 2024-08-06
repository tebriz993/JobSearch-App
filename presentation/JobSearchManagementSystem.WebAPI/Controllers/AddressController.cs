using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Features.Queries;
using JobSearchManagementSystem.WebAPI;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AddressController : ApiControllerBase
    {
        public AddressController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ActionName("addresses")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<AddressViewDto>>>> GetAddressAsync()
        {
            var addresses = await _mediator.Send(new GetAllAddressQuery());
            return await SuccessResult("Address data is retrieved", addresses);
        }

        [HttpPost]
        [ActionName("addresses")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddAddress(AddAddressCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Address added successfully");
        }

        
    }
}
