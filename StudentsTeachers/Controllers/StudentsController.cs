using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsTeachers.Domain;
using StudentsTeachers.Domain.Models;
using StudentsTeachers.Domain.Services;
using StudentsTeachers.Models;

namespace StudentsTeachers.Controllers
{
    public class StudentsController
    {
        private readonly StudentService _studentsService;

        public StudentsController(StudentService studentsService)
        {
            _studentsService = studentsService;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            var students = _studentsService.GetAll();

            var result = new List<StudentViewModel>();

            foreach (var student in students)
            {
                result.Add(new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });
            }

            return result;
        }

        public StudentViewModel Create(StudentPostModel model)
        {
            if (model.FirstName.Contains(" "))
            {
                return new StudentViewModel{ FirstName = "validation PL error", LastName = "Errorovich" };
            }
            var studentModel = new StudentModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                InsuranceNum = model.LicenseNum
            };

            var createResult = _studentsService.Create(studentModel);

            var result = new StudentViewModel
            {
                Id = createResult.Id,
                FirstName = createResult.FirstName,
                LastName = createResult.LastName
            };

            return result;
        }
    }
}
