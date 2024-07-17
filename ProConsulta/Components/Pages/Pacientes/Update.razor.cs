using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;
public class UpdatePacientePage : ComponentBase
{
    [Parameter]
    public int PacienteId { get; set; }

    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public PacienteInputModel PacienteInputModel { get; set; } = new ();

    public Paciente? PacienteAtual { get; set; }
    public DateTime? DataNascimento { get; set; } = new DateTime(1990, 01, 01);

    protected override async Task OnInitializedAsync()
    {
        try
        {
            PacienteAtual = await repository.GetByIdAsync(PacienteId);

            if (PacienteAtual == null) return;

            PacienteInputModel = new PacienteInputModel
            {
                Id = PacienteAtual.Id,
                Nome = PacienteAtual.Nome,
                Documento = PacienteAtual.Documento,
                Celular = PacienteAtual.Celular,
                Email = PacienteAtual.Email,
                DataNasicmento = PacienteAtual.DataNasicmento
            };

            DataNascimento = PacienteAtual.DataNasicmento;
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
            if (form.Model is PacienteInputModel model)
            {
                var pacientes = await repository.GetAllAsync();

                if (pacientes.Any(m => m.Documento.Contains(model.Documento.SomenteCarecteres(), StringComparison.OrdinalIgnoreCase) && m.Id != model.Id))
                {
                    Snackbar.Add("Já existe um paciente cadastrado com esse Documento (CPF)", Severity.Info);
                    return;
                }

                PacienteAtual.Nome = model.Nome;
                PacienteAtual.Documento = model.Documento.SomenteCarecteres();
                PacienteAtual.Celular = model.Celular.SomenteCarecteres();
                PacienteAtual.Email = model.Email;
                PacienteAtual.DataNasicmento = DataNascimento.Value;
                
                await repository.UpdateAsync(PacienteAtual);

                Snackbar.Add($"Paciente {PacienteAtual.Nome} atualizado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}

