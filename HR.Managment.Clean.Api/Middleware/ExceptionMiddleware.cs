using HR.Managment.Application.Exceptions;
using HR.Managment.Clean.Api.Models;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace HR.Managment.Clean.Api.Middleware
{
    public class ExceptionMiddleware
    {
        // represent next action in pipline .
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
                await HanldeExceptionAsync(httpContext , ex);
            }

        }

        private async Task HanldeExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            CutomValidationProblemDetail problem = new();
            switch (ex)
            {
                case Application.Exceptions.BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CutomValidationProblemDetail
                    {
                        Title = badRequestException.Message ,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(Application.Exceptions.BadRequestException)
                    };
                    break;
                case Application.Exceptions.NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CutomValidationProblemDetail
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Detail = notFoundException.InnerException?.Message,
                        Type = nameof(Application.Exceptions.NotFoundException)
                    };
                    break;
                default:
                    problem = new CutomValidationProblemDetail
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.InnerException?.Message,
                        Type = nameof(HttpStatusCode.InternalServerError)
                    };
                    break;
            }
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
