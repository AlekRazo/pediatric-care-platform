using Microsoft.AspNetCore.Mvc;
using Pediatria.Application.DTOs.Common;
using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Pediatria.Application.Interfaces.Services;

namespace Pediatria.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    //# 1 - Login (USC-USR-001)
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequestDto request)
    {
        var result = await _authService.Login(request);
        return Ok(ApiResponse<AuthResponseDto>.SuccessResponse(result));
    }
    
    //# 2 - Password Recovery (USC-USR-002)
    [HttpPost("recover-password")]
    public async Task<IActionResult> RecoverPassword([FromBody] PasswordRecoveryRequestDto request)
    {
        var result = await _authService.RecoverPassword(request);
        return Ok(ApiResponse<bool>.SuccessResponse(result));
    }
    
    //# 3 - Logout (USC-USR-003)
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var result = await _authService.Logout();
        return Ok(ApiResponse<bool>.SuccessResponse(result));
    }
}