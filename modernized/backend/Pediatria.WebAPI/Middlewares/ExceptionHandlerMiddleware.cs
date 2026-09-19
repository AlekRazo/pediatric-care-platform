using Pediatria.Application.DTOs.Common;
using Pediatria.Domain.Exceptions;

namespace Pediatria.Middlewares;

/*
En el middleware se manejan los errores que pudieran presentarse en tiempo de ejecución:
- 400
- 404
- 500

Estos errores son retornados en la respuesta estándar (ApiResponse<T>).
*/
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
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Error de validación en {Path}", httpContext.Request.Path);
            await HandleException(httpContext, StatusCodes.Status400BadRequest, ex.Message, ex.Errors is null ? new List<string>() : ex.Errors.ToList());
        }
        catch (UnauthorizedException ex)
        {
            _logger.LogWarning(ex, "Acceso no autorizado en {Path}", httpContext.Request.Path);
            await HandleException(httpContext, StatusCodes.Status401Unauthorized, "No autorizado", ex.Message);
        }
        catch (BusinessException ex)
        {
            _logger.LogWarning(ex, "Error de negocio en {Path}", httpContext.Request.Path);
            await HandleException(httpContext, StatusCodes.Status400BadRequest, ex.Message, ex.Errors is null ? new List<string>() : ex.Errors.ToList());
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex, "Recurso no encontrado en {Path}", httpContext.Request.Path);
            await HandleException (httpContext, StatusCodes.Status404NotFound, "Recurso no encontrado.", ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error de inesperado procesando {Path}", httpContext.Request.Path);
            await HandleException(httpContext, StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado. Intente más tarde.", ex.Message);
        }
    }

    private static async Task HandleException(HttpContext context, int statusCode, string message, List<string> details)
    {
        var response = ApiResponse<string>.ErrorResponse(details, message, (int) statusCode);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response);
    }

    private static async Task HandleException(HttpContext context, int statusCode, string message, string detail)
    {
        var response = ApiResponse<string>.ErrorResponse(new List<string> {detail}, message, (int) statusCode);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}