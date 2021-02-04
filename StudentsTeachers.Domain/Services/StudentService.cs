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

        public StudentService(IStudentRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
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
                LastName = model.LastName
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
            //create query for some service which validate is students insurance number is correct and active
            var result = false;
            var rand = new Random();
            if (rand.Next(100) > 50)
                result = true;
            return result;
        }
    }
}
