using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos;

public class IndexPage : ComponentBase
{
    [Inject]
    public IMedicoRepository Repository { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public List<Medico> Medicos { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Medicos = await Repository.GetAllAsync();
    }

    public void GoMedicoUpdate(int idMedico)
    {
        Navigation.NavigateTo($"/Medico/Update/{idMedico}");
    }

    public async Task DeleteMedico(Medico medico)
    {
        try
        {
            var resultado = await Dialog.ShowMessageBox("Atenção", $"Deseja excluir o médico {medico.Nome}?", yesText: "SIM", cancelText: "NÃO") ?? false;

            if (resultado)
            {
                await Repository.DeleteAsync(medico.Id);

                Snackbar.Add($"Médico excluído com sucesso.", Severity.Success);
                await OnInitializedAsync();

            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }

}

