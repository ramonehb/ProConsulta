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

    public List<Paciente> Filtrados { get; set; }

    public string TextoProcurado { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Pacientes = await Repository.GetAllAsync();

            Filtrados = new List<Paciente>(Pacientes);
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
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
    public void FiltrarPacientes()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(TextoProcurado))
            {
                Filtrados = new List<Paciente>(Pacientes);
            }
            else
            {
                Filtrados = Pacientes
                    .Where(m => m.Nome.Contains(TextoProcurado, StringComparison.OrdinalIgnoreCase) ||
                                m.Documento.Contains(TextoProcurado, StringComparison.OrdinalIgnoreCase) ||
                                m.Celular.Contains(TextoProcurado, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

