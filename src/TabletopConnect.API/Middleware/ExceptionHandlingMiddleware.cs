using System.Net;
using TabletopConnect.API.Controllers.Dtos.Common;
using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Domain.Exceptions;

namespace TabletopConnect.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string result;
        if (exception is DomainValidationException domainException)
        {
            statusCode = HttpStatusCode.BadRequest;
            result = System.Text.Json.JsonSerializer.Serialize(
            new ValidationErrorResponse(
                [new ValidationErrorDto(domainException.Message, domainException.FieldName)]));
        }
        else
        {
            var message = "An unexpected error occurred";
            statusCode = HttpStatusCode.InternalServerError;
            result = System.Text.Json.JsonSerializer.Serialize(new
            {
                error = message
            });

            _logger.LogError(exception, message);
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}