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
}