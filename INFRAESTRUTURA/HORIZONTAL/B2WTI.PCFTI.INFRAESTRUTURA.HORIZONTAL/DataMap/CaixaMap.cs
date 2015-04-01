
using B2WTI.PCFTI.DOMINIO.Model.Orcamento;

namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CaixaMap : EntityTypeConfiguration<Caixa>
    {
        public CaixaMap()
        {
            this.ToTable("Caixa");

            //this.HasKey(t => t.);
            
            //this.Property(t => t.BlocoId)
            //    .HasColumnName("BlocoId");

            this.Property(t => t.PeriodoMes)
                .HasColumnName("PeriodoMes")
                .HasColumnType("int");

            this.Property(t => t.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal");

            this.Property(t => t.Ativo)
                .HasColumnName("Ativo");
        }

    }
}
