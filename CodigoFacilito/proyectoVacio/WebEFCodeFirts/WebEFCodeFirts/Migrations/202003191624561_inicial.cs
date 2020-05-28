namespace WebEFCodeFirts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo_TipoClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.TipoClientes", t => t.Tipo_TipoClienteId)
                .Index(t => t.Tipo_TipoClienteId);
            
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        TipoClienteId = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoClienteId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "Tipo_TipoClienteId" });
            DropForeignKey("dbo.Clientes", "Tipo_TipoClienteId", "dbo.TipoClientes");
            DropTable("dbo.TipoClientes");
            DropTable("dbo.Clientes");
        }
    }
}
