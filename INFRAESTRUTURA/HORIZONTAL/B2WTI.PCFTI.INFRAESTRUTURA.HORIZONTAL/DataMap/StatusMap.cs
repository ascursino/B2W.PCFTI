
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            this.ToTable("Status");

            this.HasKey(t => t.StatusId);

            this.Property(t => t.StatusId)
                .HasColumnName("StatusId");

            this.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(250);
               
            this.Property(t => t.Ativo)
                .HasColumnName("Ativo");
        }

    }
}
