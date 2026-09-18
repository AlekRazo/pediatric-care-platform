using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pediatria.Application.DTOs.Common;
using Pediatria.Application.DTOs.Profiles;
using Pediatria.Application.Interfaces.Services;

namespace Pediatria.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    //# 5 - Get User (USC-USR-005)
    [HttpGet("physician/{id:guid}")]
    public async Task<IActionResult> GetPhysicianProfile([FromRoute] Guid id)
    {
        var profile = await _profileService.GetPhysicianProfileAsync(id);
        return Ok(ApiResponse<PhysicianProfileDto>.SuccessResponse(profile));
    }

    //# 5 - Get User (USC-USR-005)
    [HttpGet("receptionist/{id:guid}")]
    public async Task<IActionResult> GetReceptionistProfile([FromRoute] Guid id)
    {
        var profile = await _profileService.GetReceptionistProfileAsync(id);
        return Ok(ApiResponse<ReceptionistProfileDto>.SuccessResponse(profile));
    }

    //# 6 - Register User (USC-USR-007)
    [HttpPost("physician")]
    public async Task<IActionResult> RegisterPhysicianProfile([FromBody] PhysicianProfileDto request)
    {
        var profile = await _profileService.RegisterPhysicianProfileAsync(request);
        return Ok(ApiResponse<PhysicianProfileDto>.SuccessResponse(profile));
    }

    //# 6 - Register User (USC-USR-008)
    [HttpPost("receptionist")]
    public async Task<IActionResult> RegisterReceptionistProfile([FromBody] ReceptionistProfileDto request)
    {
        var profile = await _profileService.RegisterReceptionistProfileAsync(request);
        return Ok(ApiResponse<ReceptionistProfileDto>.SuccessResponse(profile));
    }

    //# 7 - Modify User (USC-USR-010)
    [HttpPut("physician/{id:guid}")]
    public async Task<IActionResult> UpdatePhysicianProfile([FromRoute] Guid id, [FromBody] PhysicianProfileDto request)
    {
        var profile = await _profileService.UpdatePhysicianProfileAsync(id, request);
        return Ok(ApiResponse<PhysicianProfileDto>.SuccessResponse(profile));
    }

    //# 7 - Modify User (USC-USR-011)
    [HttpPut("receptionist/{id:guid}")]
    public async Task<IActionResult> UpdateReceptionistProfile([FromRoute] Guid id, [FromBody] ReceptionistProfileDto request)
    {
        var profile = await _profileService.UpdateReceptionistProfileAsync(id, request);
        return Ok(ApiResponse<ReceptionistProfileDto>.SuccessResponse(profile));
    }
}