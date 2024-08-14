using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JobSearchManagementSystem.Application.Exception;
using JobSearchManagementSystem.WebAPI;

namespace JobSearchManagementSystem.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private const string AppJsonContentType = "application/json";
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Unhandled exception");

                List<string> messages = new List<string>();
                var httpStatusCode = HttpStatusCode.InternalServerError; // Default to 500

                switch (ex)
                {
                    case JobSearchValidationException validationException:
                        httpStatusCode = HttpStatusCode.BadRequest;
                        messages.AddRange(validationException.ValidationFailures
                            .Select(x => $"{x.PropertyName} - {x.ErrorMessage}"));
                        break;
                    default:
                        messages.Add(ex.Message);
                        break;
                }

                var responseModel = new ApiResponseModel<string>
                {
                    StatusCode = (int)httpStatusCode,
                    Messages = messages,
                    Result = null
                };

                var responseAsJson = JsonSerializer.Serialize(responseModel);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = AppJsonContentType;
                await context.Response.WriteAsync(responseAsJson);
            }
        }
    }
}
