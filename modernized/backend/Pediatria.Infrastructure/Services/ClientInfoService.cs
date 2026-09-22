using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Pediatria.Application.Interfaces.Services;

namespace Pediatria.Infrastructure.Services;

public class ClientInfoService : IClientInfoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClientInfoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string getClientIpAddress()
    {
        var context = _httpContextAccessor.HttpContext;

        if (context is null)
            return "Unknown";

        var forwardedFor = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

        if (!string.IsNullOrEmpty(forwardedFor))
            return forwardedFor.Split(",")[0].Trim();

        return context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
    }

    public string GetClientIpAddress()
    {
        var context = _httpContextAccessor.HttpContext;

        if (context is null)
            return "Unknown";

        var forwardedFor = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

        if (!string.IsNullOrEmpty(forwardedFor))
            return forwardedFor.Split(",")[0].Trim();

        return context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
    }

    public Guid? GetUserId()
    {
        var idClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return idClaim is not null ? Guid.Parse(idClaim) : null;
    }
}