using Pediatria.Application.DTOs.Profiles;
using Pediatria.Application.Interfaces;
using Pediatria.Domain.Interfaces;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public Task<PhysicianProfileDto> GetPhysicianProfileAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ReceptionistProfileDto> GetReceptionistProfileAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PhysicianProfileDto> RegisterPhysicianProfileAsync(PhysicianProfileDto request)
    {
        throw new NotImplementedException();
    }

    public Task<ReceptionistProfileDto> RegisterReceptionistProfileAsync(ReceptionistProfileDto request)
    {
        throw new NotImplementedException();
    }

    public Task<PhysicianProfileDto> UpdatePhysicianProfileAsync(Guid id, PhysicianProfileDto request)
    {
        throw new NotImplementedException();
    }

    public Task<ReceptionistProfileDto> UpdateReceptionistProfileAsync(Guid id, ReceptionistProfileDto request)
    {
        throw new NotImplementedException();
    }
}