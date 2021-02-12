namespace StudentsTeachers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddlicensesToTeachers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licenses", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Licenses", "TeacherId");
            AddForeignKey("dbo.Licenses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Licenses", new[] { "TeacherId" });
            DropColumn("dbo.Licenses", "TeacherId");
        }
    }
}
