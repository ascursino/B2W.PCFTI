namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorId = c.Guid(nullable: false),
                        CNPJ = c.String(maxLength: 20, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        NomeFantasia = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fornecedor");
        }
    }
}
