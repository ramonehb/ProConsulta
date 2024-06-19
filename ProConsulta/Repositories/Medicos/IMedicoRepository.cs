using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos;

public interface IMedicoRepository
{
    Task AddAsync(Medico medico);

    Task DeleteAsync(int id);

    Task UpdateAsync(Medico medico);

    Task<List<Medico>> GetAllAsync();

    Task<Medico?> GetByIdAsync(int id);
}

