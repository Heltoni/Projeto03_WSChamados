using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto03_WSChamados.Models
{
    public class Chamado
    {
        [Required]
        [Display(Name = "Id do Chamado")]
        [Key]
        public int ChamadoID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Data do Chamado")]
        public DateTime DataChamado { get; set; }

        [Required(ErrorMessage = "O campo Cnpj é obrigatório")]
        [Display(Name = "Cnpj do Cliente")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O Cnpj deve ter 14 dígitos")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório")]
        [Display(Name = "Assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [Display(Name = "Descrição do Chamado")]
        public string Descricao { get; set; }
                
        [Display(Name = "Resposta do Chamado")]
        public string Resposta { get; set; }
    }
}