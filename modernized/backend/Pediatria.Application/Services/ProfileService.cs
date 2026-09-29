using Pediatria.Application.DTOs.Profiles;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Application.Interfaces.Services;
using Pediatria.Domain.Entities.Users;
using Pediatria.Domain.Exceptions;

namespace Pediatria.Application.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<PhysicianProfileDto> GetPhysicianProfileAsync(Guid id)
    {
        var profile = await _profileRepository.GetPhysicianAsync(id);

        return profile is not null ? Map(profile) : throw new NotFoundException("No se econtró el perfil del usuairo.");
    }

    public async Task<ReceptionistProfileDto> GetReceptionistProfileAsync(Guid id)
    {
        var profile = await _profileRepository.GetReceptionistAsync(id);

        return profile is not null ? Map(profile) : throw new NotFoundException("No se econtró el perfil del usuairo.");
    }

    public async Task<PhysicianProfileDto> RegisterPhysicianProfileAsync(PhysicianProfileDto request)
    {
        List<string> errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("El ID de usuario es obligatorio.");
        
        if (string.IsNullOrEmpty(request.FullName))
            errors.Add("El nomnbre del médico es obligatorio.");
        
        if (request.BirthDate is null)
            errors.Add("La fecha de nacimiento es obligatoria.");
        
        if (string.IsNullOrEmpty(request.ProfessionalLicenseNumber))
            errors.Add("La cédula es obligatoria para los médicos");

        if (string.IsNullOrEmpty(request.Specialty))
            errors.Add("La especialidad es un campo obligatorio.");
        
        if (errors.Count > 0)
            throw new BusinessException("Se presentaron errores durante el registro.", errors);
        
        var profile = new Physician
        {
            UserId = request.Id,
            FullName = request.FullName,
            BirthDate = request.BirthDate.Value,
            Gender = request.Gender,
            ProfessionalLicenseNumber = request.ProfessionalLicenseNumber,
            EducationalInstitution = request.EducationalInstitution,
            Specialty = request.Specialty,
            Signature = request.Signature,
        };

        int result = await _profileRepository.AddPhysicianAsync(profile);

        if (result == 0)
            throw new Exception($"No se pudo registrar el perfil del usuario {request.Id}.");

        var newProfile = await _profileRepository.GetPhysicianAsync(request.Id);

        if (newProfile is null)
            throw new Exception($"El perfil del usuario {request.Id} se registró, pero no pudo recuperarse.");

        return Map(newProfile);
    }

    public async Task<ReceptionistProfileDto> RegisterReceptionistProfileAsync(ReceptionistProfileDto request)
    {
        List<string> errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("El ID de usuario es obligatorio.");
        
        if (string.IsNullOrEmpty(request.FullName))
            errors.Add("El nombre del médico es obligatorio.");

        if (request.BirthDate is null)
            errors.Add("La fecha de nacimiento es obligatoria.");

        if (errors.Count > 0)
            throw new BusinessException("Se presentaron errores durante el registro.", errors);
        
        var profile = new Receptionist
        {
            UserId = request.Id,
            FullName = request.FullName,
            BirthDate = request.BirthDate.Value,
            Gender = request.Gender
        };

        int result = await _profileRepository.AddReceptionistAsync(profile);

        if (result == 0)
            throw new Exception($"No se pudo registrar el perfil del usuario {request.Id}.");

        var newProfile = await _profileRepository.GetReceptionistAsync(request.Id);

        if (newProfile is null)
            throw new Exception($"El perfil del usuario {request.Id} se registró, pero no pudo recuperarse.");

        return Map(newProfile);
    }

    public async Task<PhysicianProfileDto> UpdatePhysicianProfileAsync(Guid id, PhysicianProfileDto request)
    {
        var profile = await _profileRepository.GetPhysicianAsync(id);

        if (profile is null)
            throw new NotFoundException($"No existe el perfil del usuario {id}");

        profile.FullName = !string.IsNullOrEmpty(request.FullName) ? request.FullName : profile.FullName;
        profile.BirthDate = request.BirthDate is not null ? request.BirthDate.Value : profile.BirthDate;
        profile.Gender = !string.IsNullOrEmpty(request.Gender) ? request.Gender : profile.Gender;
        profile.ProfessionalLicenseNumber = !string.IsNullOrEmpty(request.ProfessionalLicenseNumber) ? request.ProfessionalLicenseNumber : profile.ProfessionalLicenseNumber;
        profile.EducationalInstitution = !string.IsNullOrEmpty(request.EducationalInstitution) ? request.EducationalInstitution : profile.EducationalInstitution;
        profile.Specialty = !string.IsNullOrEmpty(request.Specialty) ? request.Specialty : profile.Specialty;
        profile.Signature = request.Signature is not null ? request.Signature : profile.Signature;

        await _profileRepository.SaveChangesAsync();

        return Map(profile);
    }

    public async Task<ReceptionistProfileDto> UpdateReceptionistProfileAsync(Guid id, ReceptionistProfileDto request)
    {
        var profile = await _profileRepository.GetReceptionistAsync(id);

        if (profile is null)
            throw new NotFoundException($"No existe el perfil del usuario {id}");

        profile.FullName = !string.IsNullOrEmpty(request.FullName) ? request.FullName : profile.FullName;
        profile.BirthDate = request.BirthDate is not null ? request.BirthDate.Value : profile.BirthDate;
        profile.Gender = !string.IsNullOrEmpty(request.Gender) ? request.Gender : profile.Gender;
        
        await _profileRepository.SaveChangesAsync();

        return Map(profile);
    }

    private PhysicianProfileDto Map(Physician physician)
    {
        return new PhysicianProfileDto
        {
            Id = physician.UserId,
            FullName = physician.FullName,
            BirthDate = physician.BirthDate,
            Gender = physician.Gender,
            ProfessionalLicenseNumber = physician.ProfessionalLicenseNumber,
            EducationalInstitution = physician.EducationalInstitution,
            Specialty = physician.Specialty,
            Signature = physician.Signature,
        };
    }

    private ReceptionistProfileDto Map(Receptionist receptionist)
    {
        return new ReceptionistProfileDto
        {
            Id = receptionist.UserId,
            FullName = receptionist.FullName,
            BirthDate = receptionist.BirthDate,
            Gender = receptionist.Gender
        };
    }
}