namespace ProConsulta.Models;

public class Agendamento
{
    public  int Id { get; set; }
    public string? Observacao { get; set; }
    public TimeSpan HoraConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public Paciente Paciente { get; set; } = null!;
    public int PacienteId { get; set; }
    public Medico Medico { get; set; } = null!;
    public int MedicoId { get; set; }


}

