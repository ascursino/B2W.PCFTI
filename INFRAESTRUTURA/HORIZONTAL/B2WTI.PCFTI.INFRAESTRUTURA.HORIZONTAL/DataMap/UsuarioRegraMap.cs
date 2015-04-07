
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using System.Data.Entity.ModelConfiguration;

    public class UsuarioRegraMap : EntityTypeConfiguration<UsuarioRegra>
    {
        public UsuarioRegraMap()
        {
            this.ToTable("UsuarioRegra");

            this.HasKey(t => new { t.UsuarioId, t.RegraId });

            this.HasRequired(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId);

            this.HasRequired(t => t.Regra)
                .WithMany()
                .HasForeignKey(t => t.RegraId);

        }

    }
}
