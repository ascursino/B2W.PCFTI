namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Versao",
                c => new
                    {
                        VersaoId = c.Guid(nullable: false),
                        Momento = c.DateTime(nullable: false),
                        Promotor = c.String(maxLength: 150, unicode: false),
                        Entidade = c.String(maxLength: 100, unicode: false),
                        EnitdadeId = c.String(maxLength: 100, unicode: false),
                        Operacao = c.String(maxLength: 3, unicode: false),
                        Dados = c.String(maxLength: 4000, unicode: false),
                    })
                .PrimaryKey(t => t.VersaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Versao");
        }
    }
}
