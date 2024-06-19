using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos;

public interface IAgendamentoRepository
{
    Task AddAsync(Agendamento agendamento);

    Task DeleteAsync(int id);

    Task<List<Agendamento>> GetAllAsync();

    Task<Agendamento?> GetByIdAsync(int id);
}

