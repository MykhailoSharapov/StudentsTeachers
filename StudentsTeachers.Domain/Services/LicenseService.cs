using StudentsTeachers.Data.Models;
using StudentsTeachers.Data.Repositories.Interfaces;
using StudentsTeachers.Domain.Models;
using StudentsTeachers.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Domain.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licensesRepository;

        public LicenseService(ILicenseRepository licensesRepository)
        {
            _licensesRepository = licensesRepository;
        }
        public IEnumerable<LicenseModel> GetAll()
        {
            var licenses = _licensesRepository.GetAll();
            // Create BL instances from DAL instances
            var result = new List<LicenseModel>();

            foreach (var license in licenses)
            {
                result.Add(new LicenseModel
                {
                    Id = license.Id,
                    Number = license.Number,
                });
            }

            return result;
        }
        public LicenseModel GetLicenseByNum(int num)
        {
            var license = _licensesRepository.GetLicenseByNum(num);
            var result = new LicenseModel { Id = license.Id, Number = license.Number };
            return result;
        }
    }
}
