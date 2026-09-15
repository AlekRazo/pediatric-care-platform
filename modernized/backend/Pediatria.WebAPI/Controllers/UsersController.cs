using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pediatria.Application.DTOs.Common;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces;

namespace Pediatria.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,Receptionist")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    //# 4 - Search Users (USC-USR-004)
    [HttpGet("search")]
    public async Task<IActionResult> GetUsers([FromQuery] string keyword)
    {
        var users = await _usersService.GetUsers(keyword);
        return Ok(ApiResponse<List<UserResponseDto>>.SuccessResponse(users));
    }
    
    //# 5 - Get User (USC-USR-005)
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _usersService.GetUser(id);
        return Ok(ApiResponse<UserResponseDto>.SuccessResponse(user));
    }

    //# 6 - Register User (USC-USR-006, USC-USR-007, USC-USR-008)
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto request)
    {
        var result = await _usersService.RegisterUser(request);
        return Ok(ApiResponse<UserResponseDto>.SuccessResponse(result));
    }
    
    //# 7 - Modify User (USC-USR-009, USC-USR-010, USC-USR-011)
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto request)
    {
        var result = await _usersService.UpdateUser(id, request);
        return Ok(ApiResponse<UserResponseDto>.SuccessResponse(result));
    }
    
    //# 8 - Delete User
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        var result = await _usersService.DeleteUser(id);
        return Ok(ApiResponse<bool>.SuccessResponse(result));
    }
}