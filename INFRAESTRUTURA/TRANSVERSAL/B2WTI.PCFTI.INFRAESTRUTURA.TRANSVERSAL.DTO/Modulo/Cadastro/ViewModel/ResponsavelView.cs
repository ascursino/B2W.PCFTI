
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ResponsavelView
    {

        public Guid ResponsavelId { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Ativo { get; set; }

    }
}