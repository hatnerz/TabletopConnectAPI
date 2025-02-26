using System.Net;
using TabletopConnect.API.Controllers.Dtos.Common;
using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Domain.Exceptions;

namespace TabletopConnect.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
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
            statusCode = HttpStatusCode.InternalServerError;
            result = System.Text.Json.JsonSerializer.Serialize(new
            {
                error = "An unexpected error occurred: "
            });

            // TODO: Add logging
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}