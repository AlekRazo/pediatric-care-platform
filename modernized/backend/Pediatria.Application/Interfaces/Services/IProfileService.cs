using Pediatria.Application.DTOs.Profiles;

namespace Pediatria.Application.Interfaces.Services;

public interface IProfileService
{
    //Get User (USC-USR-005)
    Task<PhysicianProfileDto> GetPhysicianProfileAsync(Guid id);
    //Get User (USC-USR-005)
    Task<ReceptionistProfileDto> GetReceptionistProfileAsync(Guid id);
    //Register User (USC-USR-007)
    Task<PhysicianProfileDto> RegisterPhysicianProfileAsync(PhysicianProfileDto request);
    //Register User (USC-USR-008)
    Task<ReceptionistProfileDto> RegisterReceptionistProfileAsync(ReceptionistProfileDto request);
    //Modify User (USC-USR-010)
    Task<PhysicianProfileDto> UpdatePhysicianProfileAsync(Guid id, PhysicianProfileDto request);
    //Modify User (USC-USR-011)
    Task<ReceptionistProfileDto> UpdateReceptionistProfileAsync(Guid id, ReceptionistProfileDto request);
}