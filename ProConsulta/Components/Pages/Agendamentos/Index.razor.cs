using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;

namespace ProConsulta.Components.Pages.Agendamentos;

public class IndexAgendamentoPage : ComponentBase
{
    [Inject]
    private IAgendamentoRepository repository { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    protected override async Task OnInitializedAsync()
    {
        Agendamentos = await repository.GetAllAsync();
    }

    public async Task DeleteAgendamento(Agendamento agendamento)
    {
        try
        {
            var resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o agendamento {agendamento.Observacao}?", yesText: "SIM", cancelText: "NÃO") ?? false;

            if (resultado)
            {
                await repository.DeleteAsync(agendamento.Id);

                Snackbar.Add($"Agendamento excluído com sucesso.", Severity.Success);
                await OnInitializedAsync();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}