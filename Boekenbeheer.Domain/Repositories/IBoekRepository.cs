using Boekenbeheer.Domain.Entities;

namespace Boekenbeheer.Domain.Repositories;

public interface IBoekRepository
{
    Task<List<Boek>> GetAllAsync();
    Task<Boek> GetByIdAsync(Guid id);
    Task AddAsync(Boek boek);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}

