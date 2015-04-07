namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bloco", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Bloco", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Bloco", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.Bloco", "AlteradoEm", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bloco", "AlteradoEm");
            DropColumn("dbo.Bloco", "CriadoEm");
            DropColumn("dbo.Bloco", "AlteradoPor");
            DropColumn("dbo.Bloco", "CriadoPor");
        }
    }
}
