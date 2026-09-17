using Pediatria.Domain.Entities.Users;

namespace Pediatria.Domain.Interfaces;

public interface IProfileRepository
{
    //Get User (USC-USR-005)
    Task<Physician?> GetPhysicianAsync(Guid id);
    
    //Get User (USC-USR-005)
    Task<Receptionist?> GetReceptionistAsync(Guid id);

    //Register User (USC-USR-007)
    Task<Physician> AddPhysicianAsync(Physician physician);
    
    //Register User (USC-USR-008)
    Task<Receptionist> AddReceptionistAsync(Receptionist receptionist);
    
    //Modify User (USC-USR-010)
    Task<Physician?> UpdatePhysicianAsync(Guid id, Physician physician);
    
    //Modify User (USC-USR-011)
    Task<Receptionist?> UpdateReceptionistAsync(Guid id, Receptionist receptionist);
}