namespace StudentsTeachers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentToLicenses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "LicenseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "LicenseId", c => c.Int(nullable: false));
        }
    }
}
