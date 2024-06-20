using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Pacientes;

public class PacienteInputModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    public string Documento { get; set; }
    
    [Required(ErrorMessage = "Informe o {0}")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe o {0}")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do nome deve ser entre {2} e {1}")]
    public string Celular { get; set; }

    [Required(ErrorMessage = "Informe a {0}")]
    public DateTime DataNasicmento { get; set; } = DateTime.Today;
}

