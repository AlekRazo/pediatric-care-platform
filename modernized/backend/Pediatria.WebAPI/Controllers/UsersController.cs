using Microsoft.AspNetCore.Mvc;
using Pediatria.Application.DTOs;
using Pediatria.Application.DTOs.Users;

namespace Pediatria.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController
{
    //Login (USC-USR-001)
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto request)
    {
        return Ok(ApiResponseDto<LoginUserResponseDto>.SuccessResponse())
    }

# 2 - Password Recovery (USC-USR-002)
Request: PasswordRecoveryRequestDto
Response: string

# 3 - Logout (USC-USR-003)
Request: Token in headers
Response: string

# 4 - Search Users (USC-USR-004)
Request: UsersRequestDto
Response: List<UserResponseDto>

# 5 - Get User (USC-USR-005)
Request: Guid
Response: UserResponseDto

# 6 - Register User (USC-USR-006, USC-USR-007, USC-USR-008)
Request: RegisterUserRequestDto
Response: RegisterUserResponseDto

# 7 - Modify User (USC-USR-009, USC-USR-010, USC-USR-011)
Request: UpdateUserRequestDto
Response: UpdateUserResponseDto

# 8 - Delete User
Request: Guid
Response: string
}