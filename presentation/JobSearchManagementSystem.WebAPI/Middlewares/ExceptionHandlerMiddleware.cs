using JobSearchManagementSystem.Application.Exception;
using System;
using System.Net;
using System.Text.Json;
using JobSearchManagementSystem.WebAPI;
namespace JobSearchManagementSystem.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleWare
    {
        private const string AppJsonContentType = "application/json";
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                List<string> messages = new List<string>();
                var httpStatusCode = HttpStatusCode.BadRequest;

                switch (e)
                {
                    case ArgumentException argumentException:
                        httpStatusCode = HttpStatusCode.InternalServerError;
                        messages.Add($"Bu middleware ile yazilan exception mesajdir {argumentException.Message}");
                        break;
                    case JobSearchValidationException validationException:
                        httpStatusCode = HttpStatusCode.BadRequest;
                        messages.AddRange(validationException.ValidationFailures.Select(x => $"{x.PropertyName} - {x.ErrorMessage}"));
                        break;
                    default:
                        messages.Add(e.Message);
                        break;
                }


                var responseModel = new ApiResponseModel<string>
                {
                    StatusCode = (int)httpStatusCode,
                    Messages = messages,
                    Result = null
                };

                var responseAsJson = JsonSerializer.Serialize(responseModel); // responseModel : {"statusCode":200 }

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = AppJsonContentType;
                await context.Response.WriteAsync(responseAsJson);
            }
        }
    }
}