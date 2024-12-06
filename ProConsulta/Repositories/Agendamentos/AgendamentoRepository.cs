using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Service;

namespace ProConsulta.Repositories.Agendamentos;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IBusService _busService;

	const string routingKeyAgendamento = "agendamento-created";

    public AgendamentoRepository(ApplicationDbContext context, IBusService busService)
    {
        _context = context;
        _busService = busService;
    }

    public async Task AddAsync(Agendamento agendamento)
    {
		try
		{
			_context.Agendamentos
				.Add(agendamento);

			await _context.SaveChangesAsync();

			_busService.Publish(routingKeyAgendamento, agendamento);
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
			var agendamento = await GetByIdAsync(id);

			_context.Agendamentos
				.Remove(agendamento);

			await _context.SaveChangesAsync();
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<List<Agendamento>> GetAllAsync()
    {
		try
		{
			var agendamentos = await _context.Agendamentos
				.Include(p => p.Paciente)
				.Include(p => p.Medico)
				.AsNoTracking()
				.ToListAsync();

			return agendamentos;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }

    public async Task<Agendamento?> GetByIdAsync(int id)
    {
		try
		{
			var agendamento = await _context.Agendamentos
				.SingleOrDefaultAsync(p => p.Id == id);

			return agendamento;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }
}

