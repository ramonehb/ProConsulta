using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Agendamentos;

public class CreateAgendamentoPage : ComponentBase
{
    [Inject]
    private IAgendamentoRepository repository { get; set; } = null!;

    [Inject]
    private IMedicoRepository MedicoRepository { get; set; } = null!;

    [Inject]
    private IPacienteRepository PacienteRepository { get; set;} = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    public AgendamentoInputModel AgendamentoInputModel { get; set; } = new AgendamentoInputModel();

    public List<Medico> Medicos { get; set; } = new List<Medico>();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public TimeSpan? time = new TimeSpan(09, 00, 00);
    public DateTime? date {  get; set; } = DateTime.Now.Date;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }

    public async Task OnValidSubmitAsync(EditContext context) 
    {
        try
        {
            if (context.Model is AgendamentoInputModel model)
            {
                await repository.AddAsync(new Agendamento
                {
                    Observacao = model.Observacao,
                    PacienteId = model.PacienteId,
                    MedicoId = model.MedicoId,
                    HoraConsulta = time!.Value,
                    DataConsulta = date!.Value
                });

                Snackbar.Add("Agendamento cadastrado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Agendamentos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}
