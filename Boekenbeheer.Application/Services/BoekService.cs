using Boekenbeheer.Domain.Entities;
using Boekenbeheer.Domain.Repositories;

namespace Boekenbeheer.Application.Services;

public class BoekService
{
    private readonly IBoekRepository _boekRepository;

    public BoekService(IBoekRepository boekRepository)
    {
        _boekRepository = boekRepository;
    }

    public async Task<List<Boek>> GetAllBoekenAsync()
    {
        return await _boekRepository.GetAllAsync();
    }

    public async Task<Boek> GetBoekByIdAsync(Guid id)
    {
        return await _boekRepository.GetByIdAsync(id);
    }

    public async Task AddBoekAsync(Boek boek)
    {
        await _boekRepository.AddAsync(boek);
        await _boekRepository.SaveChangesAsync();
    }

    public async Task DeleteBoekAsync(Guid id)
    {
        await _boekRepository.DeleteAsync(id);
        await _boekRepository.SaveChangesAsync();
    }
}