using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;
        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medico Medico)
        {
            _context.Medicos
                .Add(Medico);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);

            _context.Medicos
                .Remove(medico);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Medico>> GetAllAsync()
        {
            var medicos = await _context.Medicos
                .Include(p => p.Especialidade)
                .AsNoTracking()
                .ToListAsync();

            return  medicos;
        }

        public async Task<Medico?> GetByIdAsync(int id)
        {
            var medico = await _context.Medicos
                .SingleOrDefaultAsync(p => p.Id == id);

            return  medico;
        }

        public async Task UpdateAsync(Medico medico)
        {
            _context.Medicos.Update(medico);

            await _context.SaveChangesAsync();
        }
    }
}
