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
        public LicenseContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<License> Licenses { get; set; }
    }
}
