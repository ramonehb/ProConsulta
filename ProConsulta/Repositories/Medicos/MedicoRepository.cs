using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos;

public class MedicoRepository : IMedicoRepository
{
    private readonly ApplicationDbContext _context;
    public MedicoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Medico Medico)
    {
		try
		{
			_context.Medicos
				.Add(Medico);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task DeleteAsync(int id)
    {
		try
		{
			var medico = await GetByIdAsync(id);

			_context.Medicos
				.Remove(medico);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<List<Medico>> GetAllAsync()
    {
		try
		{
			var medicos = await _context.Medicos
				.Include(p => p.Especialidade)
				.AsNoTracking()
				.ToListAsync();

			return medicos;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
		try
		{
			var medico = await _context.Medicos
				.SingleOrDefaultAsync(p => p.Id == id);

			return medico;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task UpdateAsync(Medico medico)
    {
		try
		{
			_context.Medicos
				.Update(medico);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }
}

