using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using JobSearchManagementSystem.WebAPI;

namespace JobSearchManagementSystem.WebApi.Controllers
{

    public class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }



        protected async Task<ActionResult<ApiResponseModel<T>>> SuccessResult<T>()
        {
            return await AsActionResultAsync<T>(HttpStatusCode.OK, "Completed operation", default);
        }
        protected async Task<ActionResult<ApiResponseModel<T>>> SuccessResult<T>(string message)
        {
            return await AsActionResultAsync<T>(HttpStatusCode.OK, message, default);
        }
        protected async Task<ActionResult<ApiResponseModel<T>>> SuccessResult<T>(string message, T Result)
        {
            return await AsActionResultAsync<T>(HttpStatusCode.OK, message, Result);
        }
        private async Task<ActionResult<ApiResponseModel<T>>> AsActionResultAsync<T>(
                              HttpStatusCode statusCode,
                              string errorMessage,
                             T? result)
        {
            string? message = null;
            if (errorMessage is not null)
            {
                message = errorMessage;
            }


            var statusCodeAsInt = (int)statusCode;
            var responseModel = new ApiResponseModel<T>
            {
                Result = result,
                StatusCode = statusCodeAsInt,
                Messages = message is not null ? new[] { message } : Array.Empty<string>()
            };

            return StatusCode(statusCodeAsInt, responseModel);
        }
    }
}