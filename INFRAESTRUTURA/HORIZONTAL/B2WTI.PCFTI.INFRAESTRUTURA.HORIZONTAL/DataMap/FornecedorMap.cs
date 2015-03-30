
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            this.ToTable("Fornecedor");

            this.HasKey(t => t.FornecedorId);
            
            this.Property(t => t.FornecedorId)
                .HasColumnName("FornecedorId");

            this.Property(t => t.CNPJ)
                .HasColumnName("CNPJ")
                .HasColumnType("varchar")
                .HasMaxLength(20);
            
            this.Property(t => t.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .HasMaxLength(250);

            this.Property(t => t.Ativo)
            .HasColumnName("Ativo");
        }

    }
}
