using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class AgendamentoInputModel
    {
        [MaxLength(250, ErrorMessage = "o campo {0} deve conter no máximo {1} caracteres")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Paciente")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Selecione o {0}")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Médico")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Selecione o {0}")]
        public int MedicoId { get; set; }
    }
}
