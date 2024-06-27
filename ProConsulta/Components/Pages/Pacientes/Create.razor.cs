using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;

public class CreatePacientePage : ComponentBase
{
    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public PacienteInputModel PacienteInputModel { get; set; } = new();

    public DateTime? DataNascimento { get; set; } = new DateTime(1990, 01, 01);

    public async Task OnValidSubmitAsync(EditContext editContextPaciente)
    {
        try
        {
            if (editContextPaciente.Model is PacienteInputModel model)
            {
                var pacientes = await repository.GetAllAsync();

                if (pacientes.Any(m => m.Documento.Contains(model.Documento.SomenteCarecteres(), StringComparison.OrdinalIgnoreCase)))
                {
                    Snackbar.Add("Já existe um paciente cadastrado com esse Documento (CPF)", Severity.Info);
                    return;
                }

                await repository.AddAsync(new Paciente
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCarecteres(),
                    Celular = model.Celular.SomenteCarecteres(),
                    Email = model.Email,
                    DataNasicmento = DataNascimento.Value
                });

                Snackbar.Add("Pacinete cadastrado com sucesso.", Severity.Success);
                Navigation.NavigateTo("/Pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro contate o administrador: {ex.Message}", Severity.Error);
        }
    }
}
