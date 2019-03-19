namespace QuakeLogParser.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        TotalKills = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.Kills",
                c => new
                    {
                        KillID = c.Int(nullable: false, identity: true),
                        Kills = c.Int(nullable: false),
                        Player_PlayerID = c.Int(),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.KillID)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .Index(t => t.Player_PlayerID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.Worlds",
                c => new
                    {
                        WorldID = c.Int(nullable: false, identity: true),
                        Mean = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.WorldID)
                .ForeignKey("dbo.Games", t => t.Game_GameID)
                .Index(t => t.Game_GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worlds", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Players", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Kills", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Kills", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Worlds", new[] { "Game_GameID" });
            DropIndex("dbo.Players", new[] { "Game_GameID" });
            DropIndex("dbo.Kills", new[] { "Game_GameID" });
            DropIndex("dbo.Kills", new[] { "Player_PlayerID" });
            DropTable("dbo.Worlds");
            DropTable("dbo.Players");
            DropTable("dbo.Kills");
            DropTable("dbo.Games");
        }
    }
}
