
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class UsuarioView
    {
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "A descrição do Bloco é requerida.")]
        [DisplayName("Login")]
        [MaxLength(100, ErrorMessage = "A descrição do bloco não pode ter mais de 250 caracteres.")]
        public string LoginWindows { get; set; }

        [Required(ErrorMessage = "A descrição do Bloco é requerida.")]
        [DisplayName("Nome")]
        [MaxLength(150, ErrorMessage = "A descrição do bloco não pode ter mais de 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do Bloco é requerida.")]
        [DisplayName("E-mail")]
        [MaxLength(100, ErrorMessage = "A descrição do bloco não pode ter mais de 250 caracteres.")]
        public string Email { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<RegraView> Regras { get; set; }       

    }
}