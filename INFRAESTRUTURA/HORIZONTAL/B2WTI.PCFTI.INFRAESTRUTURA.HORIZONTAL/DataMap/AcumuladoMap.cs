


namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using System.ComponentModel.DataAnnotations.Schema;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AcumuladoMap : EntityTypeConfiguration<Acumulado>
    {
        public AcumuladoMap()
        {
            this.ToTable("Acumulado");

            this.Property(t => t.LancamentoId)
                .HasColumnOrder(0)
                .HasColumnName("LancamentoId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PeriodoMes)
                .HasColumnOrder(1)
                .HasColumnName("PeriodoMes")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PeriodoMes)
                .HasColumnName("PeriodoMes")
                .HasColumnType("int");

            this.Property(t => t.Valor)
                .HasColumnName("Valor")
                .HasColumnType("float");

            this.Property(t => t.Ativo)
                .HasColumnName("Ativo");

            this.HasKey(p => new { p.LancamentoId, p.PeriodoMes });
            this.HasRequired(t => t.Lancamento)
                .WithMany()
                .HasForeignKey(d => d.LancamentoId);
        }

    }
}
