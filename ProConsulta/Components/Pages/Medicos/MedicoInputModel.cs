using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Medicos;

public class MedicoInputModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    public string Documento { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    public string CRM { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    public string Celular { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Especialidade")]
    [Required(ErrorMessage = "Informe a {0}")]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado inválido")]
    public int EspecialidadeId { get; set; }
}
