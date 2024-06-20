using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;

public class IndexPage : ComponentBase
{
    [Inject]
    public IPacienteRepository Repository { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public List<Paciente> Pacientes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Pacientes = await Repository.GetAllAsync();
    }

    public void GoPacienteUpdate(int idPaciente)
    {
        Navigation.NavigateTo($"/Pacientes/Update/{idPaciente}");
    }

    public async Task DeletePaciente(Paciente paciente)
    {
        try
        {
            var resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o paciente {paciente.Nome}?", yesText: "SIM", cancelText: "NÃO") ?? false;

            if (resultado)
            {
                await Repository.DeleteAsync(paciente.Id);

                Snackbar.Add($"Paciente excluído com sucesso.", Severity.Success);
                await OnInitializedAsync();

            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

