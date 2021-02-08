using StudentsTeachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Domain.Services.Interfaces
{
    public interface ILicenseService
    {
        IEnumerable<LicenseModel> GetAll();
    }
}
