
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using System.Data.Entity.ModelConfiguration;

    public class RegraMap : EntityTypeConfiguration<Regra>
    {
        public RegraMap()
        {
            this.ToTable("Regra");

            this.HasKey(t => t.RegraId);

            this.Property(t => t.Nome)
                .HasColumnName("ResponsavelId")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);
                

            this.Property(t => t.RegraId)
                .HasColumnName("RegraId");
            
        }

    }
}
