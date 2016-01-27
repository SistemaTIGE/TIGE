namespace TIGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoDeEvento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventoes", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Eventoes", "Tipo");
        }
    }
}
