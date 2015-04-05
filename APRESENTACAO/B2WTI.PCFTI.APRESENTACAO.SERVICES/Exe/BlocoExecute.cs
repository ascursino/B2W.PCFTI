
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Map;

    public static class BlocoExecute
    {
        static Execute Executar = new Execute();

        public static List<BlocoView> ListarTodosOsBlocos()
        {
            List<BlocoView> blocos = Executar.Cadastro.Bloco.ListarBlocos().DeDominParaView();
            return blocos;
        }

        public static List<BlocoView> BuscarBlocos(string filtro)
        {
            List<BlocoView> blocos = Executar.Cadastro.Bloco.BuscarBlocos(filtro).DeDominParaView();
            return blocos;
        }

    }
}
