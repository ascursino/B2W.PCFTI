namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.PCFTIDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.PCFTIDataContext context)
        {

        }
    }
}
