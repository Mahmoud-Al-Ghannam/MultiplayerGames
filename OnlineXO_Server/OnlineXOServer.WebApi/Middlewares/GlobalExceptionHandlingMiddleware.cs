using System;
using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using OnlineXO_Server.Application.Common.Exceptions;
using OnlineXO_Server.Domain.Common.Exceptions;
using OnlineXOServer.WebApi.Common;
using AppUnauthorizedAccessException = OnlineXO_Server.Application.Common.Exceptions.UnauthorizedAccessException;

namespace OnlineXOServer.WebApi.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _environment;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger,
        IWebHostEnvironment environment
    )
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {ExceptionType}", ex.GetType().Name);
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {
            BadRequestException => HttpStatusCode.BadRequest,
            DomainException => HttpStatusCode.BadRequest,
            NotFoundEntityException => HttpStatusCode.NotFound,
            AlreadyExistsEntityException => HttpStatusCode.Conflict,
            ForbiddenAccessException => HttpStatusCode.Forbidden,
            AppUnauthorizedAccessException => HttpStatusCode.Unauthorized,
            System.UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError,
        };

        if (
            exception is DbUpdateException dbUpdateException
            && statusCode == HttpStatusCode.BadRequest
        )
        {
            exception = new DbUpdateException(
                "Global.Error.Deletion.YouCannotDeleteThisEntityBecauseItIsReferencedByOtherEntities",
                dbUpdateException
            );
        }

        object response;

        // Only include stack trace in development
        if (_environment.IsDevelopment())
        {
            response = new FailedDevelopmentResponse()
            {
                Success = false,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                StatusCode = (int)statusCode,
            };
        }
        else
        {
            response = new FailedProductionResponse()
            {
                Success = false,
                Message = exception.Message,
                StatusCode = (int)statusCode,
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var payload = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(payload);
    }
}
