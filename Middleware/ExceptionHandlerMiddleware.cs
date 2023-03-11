using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeAttendance.DTO;
using EmployeeAttendance.Exceptions;

namespace EmployeeAttendance.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,
                ex.Message,
                HttpStatusCode.NotFound, 
                ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,
                ex.Message,
                HttpStatusCode.InternalServerError,
                "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string exMsg,
            HttpStatusCode httpStatusCode,
            string message)
        {
            _logger.LogError(exMsg);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new ErrorDto()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);
            await response.WriteAsJsonAsync(result);
        }
    }
}