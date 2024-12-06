namespace NotificationService.Model;

public class Agendamento
{
    public int Id { get; set; }
    public string? Observacao { get; set; }
    public TimeSpan HoraConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
}
