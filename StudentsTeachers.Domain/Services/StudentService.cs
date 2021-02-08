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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentsRepository;
        private readonly ILicenseRepository _licensesRepository;

        public StudentService(IStudentRepository studentsRepository, ILicenseRepository licenseRepository)
        {
            _studentsRepository = studentsRepository;
            _licensesRepository = licenseRepository;
        }

        public StudentModel Create(StudentModel model)
        {
            if (!Validation(model))
            {
                throw new Exception("validation BL error");
            }
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                InsuranceNum = model.InsuranceNum                
            };

            _studentsRepository.Create(student);

            model.Id = student.Id;

            return model;
        }

        public IEnumerable<StudentModel> GetAll()
        {
            var students = _studentsRepository.GetAll();
            // Create BL instances from DAL instances
            var result = new List<StudentModel>();

            foreach (var student in students)
            {
                result.Add(new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });
            }

            return result;
        }

        private bool Validation(StudentModel model)
        {
            var licenses = _licensesRepository.GetAll();
            var license = licenses.Where(w => w.Number == model.InsuranceNum);
            return license.Any() ? true : false;
        }
    }
}
