
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RegraView
    {

        public Guid RegraId { get; set; }

        [Required(ErrorMessage = "O nome da regra é requerida.")]
        [DisplayName("Descrição")]
        [MaxLength(150, ErrorMessage="O nome da regra não pode ter mais de 150 caracteres.")]
        public string Nome { get; set; }

        public virtual ICollection<UsuarioView> Usuarios { get; set; }

    }
}