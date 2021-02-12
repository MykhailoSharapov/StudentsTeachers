namespace StudentsTeachers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicenseToStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licenses", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "LicenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Licenses", "StudentId");
            AddForeignKey("dbo.Licenses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "StudentId", "dbo.Students");
            DropIndex("dbo.Licenses", new[] { "StudentId" });
            DropColumn("dbo.Students", "LicenseId");
            DropColumn("dbo.Licenses", "StudentId");
        }
    }
}
