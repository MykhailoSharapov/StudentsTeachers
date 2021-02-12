using StudentsTeachers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Data
{
    public class LicenseContext : DbContext
    {
        public LicenseContext() : base("Default")
        {

        }
        public LicenseContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<License> Licenses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<License>().HasKey(x => x.Id);
            modelBuilder.Entity<License>().Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Student>().HasMany(x => x.Licenses).WithRequired(x => x.Student).HasForeignKey(x=>x.StudentId);
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<License>().HasRequired(x => x.Student).WithMany(x => x.Licenses);
        }
    }
}
