using Microsoft.EntityFrameworkCore;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Domain.Entities.Users;
using Pediatria.Infrastructure.Persistence;

namespace Pediatria.Infrastructure.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _context;

    public ProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Physician?> GetPhysicianAsync(Guid id)
    {
        return _context.Physicians.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == id)!;
    }

    public Task<Receptionist?> GetReceptionistAsync(Guid id)
    {
        return _context.Receptionists.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == id)!;
    }

    public async Task<Physician> AddPhysicianAsync(Physician physician)
    {
        await _context.Physicians.AddAsync(physician);
        await _context.SaveChangesAsync();

        return await _context.Physicians.AsNoTracking().FirstAsync(p => p.UserId == physician.UserId)!;
    }

    public async Task<Receptionist> AddReceptionistAsync(Receptionist receptionist)
    {
        await _context.Receptionists.AddAsync(receptionist);
        await _context.SaveChangesAsync();

        return await _context.Receptionists.AsNoTracking().FirstAsync(p => p.UserId == receptionist.UserId)!;
    }

    public async Task<Physician?> UpdatePhysicianAsync(Guid id, Physician physician)
    {
        var result = await _context.Physicians.FirstOrDefaultAsync(p => p.UserId == id)!;

        if (result is null) return null;

        result.FullName = physician.FullName;
        result.BirthDate = physician.BirthDate;
        result.Gender = physician.Gender;
        result.ProfessionalLicenseNumber = physician.ProfessionalLicenseNumber;
        result.EducationalInstitution = physician.EducationalInstitution;
        result.Specialty = physician.Specialty;
        result.Signature = physician.Signature;

        await _context.SaveChangesAsync();

        return await _context.Physicians.FirstOrDefaultAsync(p => p.UserId == id)!;
    }

    public async Task<Receptionist?> UpdateReceptionistAsync(Guid id, Receptionist receptionist)
    {
        var result = await _context.Receptionists.FirstOrDefaultAsync(r => r.UserId == id)!;

        if (result is null) return null;

        result.FullName = receptionist.FullName;
        result.BirthDate = receptionist.BirthDate;
        result.Gender = receptionist.Gender;

        await _context.SaveChangesAsync();

        return await _context.Receptionists.FirstOrDefaultAsync(r => r.UserId == id)!;
    }
}