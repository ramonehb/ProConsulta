using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;
        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Paciente paciente)
        {
            _context.Pacientes
                .Add(paciente);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await GetByIdAsync(id);

            _context.Pacientes
                .Remove(paciente);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            var pacientes = await _context.Pacientes
                .AsNoTracking()
                .ToListAsync();

            return pacientes;
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            var paciente = await _context.Pacientes
                .SingleOrDefaultAsync(p => p.Id == id);

            return  paciente;
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);

            await _context.SaveChangesAsync();
        }
    }
}
