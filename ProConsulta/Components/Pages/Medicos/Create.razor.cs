using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos;

public class CreateMedicoPage : ComponentBase
{
    [Inject]
    public IMedicoRepository Repository { get; set; } = null!;

    [Inject]
    public IEspecialidadeRepository EspecialidadeRepository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public MedicoInputModel MedicoInputModel { get; set; } = new();

    public List<Especialidade> Especialidades { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Especialidades = await EspecialidadeRepository.GetAllAsync();
    }

    public async Task OnValidSubmitAsync(EditContext context)
    {
        try
        {
            if (context.Model is MedicoInputModel model)
            {
                await Repository.AddAsync(new Medico
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCarecteres(),
                    CRM = model.CRM.SomenteCarecteres(),
                    Celular = model.Celular.SomenteCarecteres(),
                    DataCadastro = model.DataCadastro,
                    EspecialidadeId = model.EspecialidadeId
                });

                Snackbar.Add("Medico gravado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Medicos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

