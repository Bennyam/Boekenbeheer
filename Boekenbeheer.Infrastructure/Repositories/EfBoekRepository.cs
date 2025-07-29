using Boekenbeheer.Domain.Entities;
using Boekenbeheer.Domain.Repositories;
using Boekenbeheer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Boekenbeheer.Infrastructure.Repositories;

public class EfBoekRepository : IBoekRepository
{
    private readonly AppDbContext _context;

    public EfBoekRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Boek boek)
    {
        await _context.Boeken.AddAsync(boek);
    }

    public async Task<List<Boek>> GetAllAsync()
    {
        return await _context.Boeken.ToListAsync();
    }

    public async Task<Boek> GetByIdAsync(Guid id)
    {
        return await _context.Boeken.FindAsync(id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var boek = await GetByIdAsync(id);
        if (boek != null)
        {
            _context.Boeken.Remove(boek);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}