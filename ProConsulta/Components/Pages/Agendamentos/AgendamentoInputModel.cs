using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class AgendamentoInputModel
    {
        [MaxLength(250, ErrorMessage = "o campo {0} deve conter no máximo {1} caracteres")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Hora da Consulta")]
        public TimeSpan HoraConsulta { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Data da Consulta")]
        public DateTime DataConsulta { get; set; }
    }
}
