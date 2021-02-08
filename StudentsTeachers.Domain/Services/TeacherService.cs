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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teachersRepository;
        private readonly ILicenseRepository _licensesRepository;

        public TeacherService(ITeacherRepository teachersRepository, ILicenseRepository licenseRepository)
        {
            _teachersRepository = teachersRepository;
            _licensesRepository = licenseRepository;
        }
        public TeacherModel Create(TeacherModel model)
        {
            if (!Validation(model))
            {
                throw new Exception("validation BL error");
            }
            var teacher = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNum = model.LicenseNum
            };

            _teachersRepository.Create(teacher);

            model.Id = teacher.Id;

            return model;
        }

        public IEnumerable<TeacherModel> GetAll()
        {
            var teachers = _teachersRepository.GetAll();
            // Create BL instances from DAL instances
            var result = new List<TeacherModel>();

            foreach (var teacher in teachers)
            {
                result.Add(new TeacherModel
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName
                });
            }

            return result;
        }

        private bool Validation(TeacherModel model)
        {
            var licenses = _licensesRepository.GetAll();
            var license = licenses.Where(w => w.Number == model.LicenseNum);
            return license.Any() ? true : false;
        }
    }
}
