namespace TIGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Sexo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Sexo");
        }
    }
}
