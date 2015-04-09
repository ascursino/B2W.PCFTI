
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Sistema.Models
{
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;

    public class GestaoPrivilegio
    {
        public UsuarioView Usuario { get; set; }
        public List<RegraView> Regras { get; set; }
        public List<UsuarioRegraView> UsuarioRegras { get; set; }

    }
}