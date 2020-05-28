namespace plantillaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Emails", "Cliente_ClienteId");
            AddForeignKey("dbo.Emails", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Emails", new[] { "Cliente_ClienteId" });
            DropColumn("dbo.Emails", "Cliente_ClienteId");
        }
    }
}
