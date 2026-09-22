namespace Pediatria.Application.Interfaces.Services;

public interface IClientInfoService
{
    string GetClientIpAddress();
    Guid? GetUserId();
    
}