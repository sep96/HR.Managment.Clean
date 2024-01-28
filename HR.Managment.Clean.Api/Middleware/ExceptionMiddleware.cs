using HR.Managment.Application.Exceptions;
using System.Net;

namespace HR.Managment.Clean.Api.Middleware
{
    public class ExceptionMiddleware
    {
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

        private Task HanldeExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            dynamic problem;
            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException badRequestException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }
        }
    }
}
