
using System.Security;

namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Orcamento
{
    using System;

    public class LancamentoDTO
    {
        public Guid LancamentoId { get; set; }

        #region 1º Trimestre
        public decimal orcadojaneiro { get; set; }
        public decimal backlogjaneiro { get; set; }
        public decimal caixajaneiro { get; set; }
        public decimal realjaneiro { get; set; }
        public decimal acumjaneiro { get; set; }
        public decimal orcadofevereiro { get; set; }
        public decimal backlogfevereiro { get; set; }
        public decimal caixafevereiro { get; set; }
        public decimal realfevereiro { get; set; }
        public decimal acumfevereiro { get; set; }
        public decimal orcadomarco { get; set; }
        public decimal backlogmarco { get; set; }
        public decimal caixamarco { get; set; }
        public decimal realmarco { get; set; }
        public decimal acummarco { get; set; }
        public decimal orcado1trimestre { get; set; }
        public decimal backlog1trimestre { get; set; }
        public decimal caixa1trimestre { get; set; }
        public decimal real1trimestre { get; set; }
        public decimal acum1tri { get; set; }

        #endregion

        #region 2º Trimestre
        public decimal orcadoabril { get; set; }
        public decimal backlogabril { get; set; }
        public decimal caixaabril { get; set; }
        public decimal realabril { get; set; }
        public decimal acumabril { get; set; }
        public decimal orcadomaio { get; set; }
        public decimal backlogmaio { get; set; }
        public decimal caixamaio { get; set; }
        public decimal realmaio { get; set; }
        public decimal acummaio { get; set; }
        public decimal orcadojunho { get; set; }
        public decimal backlogjunho { get; set; }
        public decimal caixajunho { get; set; }
        public decimal realjunho { get; set; }
        public decimal acumjunho { get; set; }
        public decimal orcado2trimestre { get; set; }
        public decimal backlog2trimestre { get; set; }
        public decimal caixa2trimestre { get; set; }
        public decimal real2trimestre { get; set; }
        public decimal acum2tri { get; set; }
        #endregion

        #region 3º Trimestre
        public decimal orcadojulho { get; set; }
        public decimal backlogjulho { get; set; }
        public decimal caixajulho { get; set; }
        public decimal realjulho { get; set; }
        public decimal acumjulho { get; set; }
        public decimal orcadoagosto { get; set; }
        public decimal backlogagosto { get; set; }
        public decimal caixaagosto { get; set; }
        public decimal realagosto { get; set; }
        public decimal acumagosto { get; set; }
        public decimal orcadosetembro { get; set; }
        public decimal backlogsetembro { get; set; }
        public decimal caixasetembro { get; set; }
        public decimal realsetembro { get; set; }
        public decimal acumsetembro { get; set; }
        public decimal orcado3trimestre { get; set; }
        public decimal backlog3trimestre { get; set; }
        public decimal caixa3trimestre { get; set; }
        public decimal real3trimestre { get; set; }
        public decimal acum3tri { get; set; }
        #endregion

        #region 4º Trimestre
        public decimal orcadooutubro { get; set; }
        public decimal backlogoutubro { get; set; }
        public decimal caixaoutubro { get; set; }
        public decimal realoutubro { get; set; }
        public decimal acumoutubro { get; set; }
        public decimal orcadonovembro { get; set; }
        public decimal backlognovembro { get; set; }
        public decimal caixanovembro { get; set; }
        public decimal realnovembro { get; set; }
        public decimal acumnovembro { get; set; }
        public decimal orcadodezembro { get; set; }
        public decimal backlogdezembro { get; set; }
        public decimal caixadezembro { get; set; }
        public decimal realdezembro { get; set; }
        public decimal acumdezembro { get; set; }
        public decimal orcado4trimestre { get; set; }
        public decimal backlog4trimestre { get; set; }
        public decimal caixa4trimestre { get; set; }
        public decimal real4trimestre { get; set; }
        public decimal acum4tri { get; set; }
        #endregion

        #region Total Trimestres
        public decimal orcadototal { get; set; }
        public decimal backlogtotal { get; set; }
        public decimal caixatotal { get; set; }
        public decimal realtotal { get; set; }
        public decimal acumtotal { get; set; }
        #endregion{get;set;}


    }
}
