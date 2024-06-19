using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;

public class IndexPage : ComponentBase
{
    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public IDialogService dialog { get; set; } = null!;

    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager navigation { get; set; } = null!;

    public List<Paciente> pacientes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        pacientes = await repository.GetAllAsync();
    }

    public void GoPacienteUpdate(int idPaciente)
    {
        navigation.NavigateTo($"/pacientes/update/{idPaciente}");
    }

    public async Task DeletePaciente(Paciente paciente)
    {
        try
        {
            var resultado = await dialog.ShowMessageBox("Atenção", $"Deseja excluir o paciente {paciente.Nome}?", yesText: "SIM", cancelText: "NÃO") ?? false;

            if (resultado)
            {
                await repository.DeleteAsync(paciente.Id);

                snackbar.Add($"Paciente excluído com sucesso.", Severity.Success);
            }
        }
        catch (Exception ex)
        {
            snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

