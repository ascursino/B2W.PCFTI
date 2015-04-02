
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PropriedadeMap : EntityTypeConfiguration<Propriedade>
    {
        public PropriedadeMap()
        {
            this.ToTable("Propriedade");

            this.HasKey(t => t.Ano);
            
            this.Property(t => t.Ano)
                .HasColumnName("Ano")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            this.Property(t => t.Ativo)
            .HasColumnName("Ativo");
        }

    }
}
