using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes;

public class PacienteRepository : IPacienteRepository
{
    private readonly ApplicationDbContext _context;
    public PacienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Paciente paciente)
    {
        try
        {
			_context.Pacientes
				.Add(paciente);

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
			var paciente = await GetByIdAsync(id);

			_context.Pacientes
				.Remove(paciente);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
		try
		{
			var pacientes = await _context.Pacientes
				.AsNoTracking()
				.ToListAsync();

			return pacientes;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
		try
		{
			var paciente = await _context.Pacientes
				.SingleOrDefaultAsync(p => p.Id == id);

			return paciente;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task UpdateAsync(Paciente paciente)
    {
		try
		{
			_context.Pacientes
				.Update(paciente);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }
}
