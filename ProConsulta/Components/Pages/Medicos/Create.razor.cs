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
    public IMedicoRepository repository { get; set; } = null!;

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
        try
        {
            Especialidades = await EspecialidadeRepository.GetAllAsync();
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
            if (context.Model is MedicoInputModel model)
            {
                var medicos = await repository.GetAllAsync();

                if (medicos.Any(m => m.Documento.Contains(model.Documento.SomenteCarecteres(), StringComparison.OrdinalIgnoreCase)))
                {
                    Snackbar.Add("Já existe um médico(a) cadastrado com esse Documento (CPF)", Severity.Info);
                    return;
                }

                await repository.AddAsync(new Medico
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCarecteres(),
                    CRM = model.CRM.SomenteCarecteres(),
                    Celular = model.Celular.SomenteCarecteres(),
                    DataCadastro = model.DataCadastro,
                    EspecialidadeId = model.EspecialidadeId
                });

                Snackbar.Add("Médico(a) gravado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Medicos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

