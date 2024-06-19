using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            _context.Agendamentos
                .Add(agendamento);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agendamento = await GetByIdAsync(id);

            _context.Agendamentos
                .Remove(agendamento);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            var agendamentos = await _context.Agendamentos
                .Include(p => p.Paciente)
                .Include(p => p.Medico)
                .AsNoTracking()
                .ToListAsync();

            return agendamentos;
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            var agendamento = await _context.Agendamentos
                .SingleOrDefaultAsync(p => p.Id == id);

            return agendamento;
        }
    }
}
