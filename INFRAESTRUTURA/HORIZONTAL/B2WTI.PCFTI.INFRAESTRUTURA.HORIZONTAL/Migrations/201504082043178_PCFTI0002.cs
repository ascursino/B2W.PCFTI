namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0002 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Regra", name: "ResponsavelId", newName: "Nome");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Regra", name: "Nome", newName: "ResponsavelId");
        }
    }
}
