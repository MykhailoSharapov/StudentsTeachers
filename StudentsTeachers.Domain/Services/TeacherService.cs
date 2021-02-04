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

        public TeacherService(ITeacherRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
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
                LastName = model.LastName
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
            //create query for some service which validate is teachers license number is correct and active
            var result = false;
            var rand = new Random();
            if (rand.Next(100) > 50)
                result = true;
            return result;
        }
    }
}
