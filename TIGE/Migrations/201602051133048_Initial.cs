namespace TIGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        AtividadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        EventoID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        AreaID = c.Int(nullable: false),
                        CargaHoraria = c.String(),
                    })
                .PrimaryKey(t => t.AtividadeID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Eventoes", t => t.EventoID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.EventoID)
                .Index(t => t.UserID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        DocumentoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        URL = c.String(),
                        AtividadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoID)
                .ForeignKey("dbo.Atividades", t => t.AtividadeID, cascadeDelete: true)
                .Index(t => t.AtividadeID);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        EventoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        LogoURL = c.String(),
                        Inscritivel = c.Boolean(nullable: false),
                        Tipo = c.Int(nullable: false),
                        InstituicaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventoID)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: true)
                .Index(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.Inscricaos",
                c => new
                    {
                        InscricaoID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        EventoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InscricaoID)
                .ForeignKey("dbo.Eventoes", t => t.EventoID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.EventoID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CPF = c.String(),
                        NomeCompleto = c.String(),
                        Sexo = c.Int(nullable: false),
                        InstituicaoID = c.Int(nullable: false),
                        Endereco = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: true)
                .Index(t => t.InstituicaoID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InscricaoAtividades",
                c => new
                    {
                        InscricaoAtividadeID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        AtividadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InscricaoAtividadeID)
                .ForeignKey("dbo.Atividades", t => t.AtividadeID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AtividadeID);
            
            CreateTable(
                "dbo.Instituicaos",
                c => new
                    {
                        InstituicaoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Atividades", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.Eventoes", "InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.InscricaoAtividades", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.InscricaoAtividades", "AtividadeID", "dbo.Atividades");
            DropForeignKey("dbo.Inscricaos", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inscricaos", "EventoID", "dbo.Eventoes");
            DropForeignKey("dbo.Atividades", "EventoID", "dbo.Eventoes");
            DropForeignKey("dbo.Documentoes", "AtividadeID", "dbo.Atividades");
            DropForeignKey("dbo.Atividades", "AreaID", "dbo.Areas");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.InscricaoAtividades", new[] { "AtividadeID" });
            DropIndex("dbo.InscricaoAtividades", new[] { "UserID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "InstituicaoID" });
            DropIndex("dbo.Inscricaos", new[] { "EventoID" });
            DropIndex("dbo.Inscricaos", new[] { "UserID" });
            DropIndex("dbo.Eventoes", new[] { "InstituicaoID" });
            DropIndex("dbo.Documentoes", new[] { "AtividadeID" });
            DropIndex("dbo.Atividades", new[] { "AreaID" });
            DropIndex("dbo.Atividades", new[] { "UserID" });
            DropIndex("dbo.Atividades", new[] { "EventoID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Instituicaos");
            DropTable("dbo.InscricaoAtividades");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Inscricaos");
            DropTable("dbo.Eventoes");
            DropTable("dbo.Documentoes");
            DropTable("dbo.Atividades");
            DropTable("dbo.Areas");
        }
    }
}
