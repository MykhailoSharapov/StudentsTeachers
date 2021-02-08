using StudentsTeachers.Data.Models;
using StudentsTeachers.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Data.Repositories
{
    public class LicenseEFRepository : ILicenseRepository
    {
        public IEnumerable<License> GetAll()
        {
            using (var ctx = new LicenseContext("Default"))
            {
                return ctx.Licenses.ToList();
            };
        }
    }
}
