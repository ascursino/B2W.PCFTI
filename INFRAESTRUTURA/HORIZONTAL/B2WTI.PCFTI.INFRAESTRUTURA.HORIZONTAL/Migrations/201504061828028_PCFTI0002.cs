namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fornecedor", "Conatato", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Fornecedor", "Telefone", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Fornecedor", "Email", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fornecedor", "Email");
            DropColumn("dbo.Fornecedor", "Telefone");
            DropColumn("dbo.Fornecedor", "Conatato");
        }
    }
}
