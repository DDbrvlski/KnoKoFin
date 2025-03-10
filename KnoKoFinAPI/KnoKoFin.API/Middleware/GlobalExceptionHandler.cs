using KnoKoFin.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Xunit.Sdk;

namespace KnoKoFin.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Dopasowanie wyjątków do odpowiednich kodów statusu i wiadomości
            (int statusCode, string errorMessage, object ? errors) = exception switch
            {
                ForbidException forbidException => (StatusCodes.Status403Forbidden, forbidException.Message, null),
                BadRequestException badRequestException => (StatusCodes.Status400BadRequest, badRequestException.Message, null),
                NotFoundException notFoundException => (StatusCodes.Status404NotFound, notFoundException.Message, null),
                UnauthorizedException unauthorizedException => (StatusCodes.Status401Unauthorized, unauthorizedException.Message, null),
                ValidationException validationEx => (StatusCodes.Status400BadRequest, validationEx.Message, validationEx.Failures), // Użycie Failures zamiast Errors
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.", null)
            };

            // Logowanie błędu
            _logger.LogError(exception, "Wystąpił błąd: {ErrorMessage}", exception.Message);

            // Przygotowanie odpowiedzi HTTP
            var response = new
            {
                StatusCode = statusCode,
                Message = errorMessage,
                Errors = errors
            };

            // Ustawienie kodu statusu i wysłanie odpowiedzi w formacie JSON
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }

    }
}
