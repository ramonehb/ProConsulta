namespace ProConsulta.Models;

public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Documento { get; set; } = null!;
    public string CRM { get; set; } = null!;
    public string Celular { get; set; } = null!;
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public Especialidade Especialidade { get; set; } = null!;
    public int EspecialidadeId { get; set; }
    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}

