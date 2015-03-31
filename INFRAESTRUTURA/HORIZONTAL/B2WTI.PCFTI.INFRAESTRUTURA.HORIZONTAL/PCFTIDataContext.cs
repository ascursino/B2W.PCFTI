
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class PCFTIDataContext : DataContext
    {
        const string ConnectionName = "Name=PCFTIDB";
        static PCFTIDataContext() 
        {
            Database.SetInitializer<PCFTIDataContext>(null);
        }

        public PCFTIDataContext()
            : base(ConnectionName)
        {
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            //modelBuilder.Configurations.Add(new FornecedorMap());
        }

    }
}
