using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos;

public class UpdateMedicoPage : ComponentBase
{
    [Parameter]
    public int MedicoId { get; set; }

    [Inject]
    public IMedicoRepository repository { get; set; } = null!;

    [Inject]
    public IEspecialidadeRepository EspecialidadeRepository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public MedicoInputModel MedicoInputModel { get; set; } = new();

    public Medico? MedicoAtual { get; set; }

    public List<Especialidade> Especialidades { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            MedicoAtual = await repository.GetByIdAsync(MedicoId);
            Especialidades = await EspecialidadeRepository.GetAllAsync();

            if (MedicoAtual == null) return;

            MedicoInputModel = new MedicoInputModel
            {
                Id = MedicoAtual.Id,
                Nome = MedicoAtual.Nome,
                Documento = MedicoAtual.Documento,
                CRM = MedicoAtual.CRM,
                Celular = MedicoAtual.Celular,
                EspecialidadeId = MedicoAtual.EspecialidadeId
            };
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }

    public async Task OnValidSubmitAsync(EditContext form)
    {
        try
        {
            if (MedicoAtual is null) return;

            if (form.Model is MedicoInputModel model)
            {
                var medicos = await repository.GetAllAsync();

                if (medicos.Any(m => m.Documento.Contains(model.Documento.SomenteCarecteres(), StringComparison.OrdinalIgnoreCase) && m.Id != model.Id))
                {
                    Snackbar.Add("Já existe um médico(a) cadastrado com esse Documento (CPF)", Severity.Info);
                    return;
                }

                MedicoAtual.Nome = model.Nome;
                MedicoAtual.Documento = model.Documento.SomenteCarecteres();
                MedicoAtual.CRM = model.CRM.SomenteCarecteres();
                MedicoAtual.Celular = model.Celular.SomenteCarecteres();
                MedicoAtual.EspecialidadeId = model.EspecialidadeId;

                await repository.UpdateAsync(MedicoAtual);

                Snackbar.Add($"Médico(a) {MedicoAtual.Nome} atualizado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Medicos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

