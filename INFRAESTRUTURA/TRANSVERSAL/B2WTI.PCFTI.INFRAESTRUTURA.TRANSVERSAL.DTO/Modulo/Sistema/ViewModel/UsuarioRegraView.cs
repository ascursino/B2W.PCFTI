
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class UsuarioRegraView
    {

        [Required()]
        public Guid UsuarioId { get; set; }
        
        public virtual UsuarioView Usuario { get; set; }

        [Required()]
        public Guid RegraId { get; set; }
        
        public virtual RegraView Regra { get; set; }

    }
}