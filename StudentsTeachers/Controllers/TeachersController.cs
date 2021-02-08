using StudentsTeachers.Domain.Models;
using StudentsTeachers.Domain.Services;
using StudentsTeachers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Controllers
{
    public class TeachersController
    {
        private readonly TeacherService _teachersService;

        public TeachersController(TeacherService teachersService)
        {
            _teachersService = teachersService;
        }

        public IEnumerable<TeacherViewModel> GetAll()
        {
            var teachers = _teachersService.GetAll();

            var result = new List<TeacherViewModel>();

            foreach (var teacher in teachers)
            {
                result.Add(new TeacherViewModel
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    LessonId = "Unknown"
                });
            }

            return result;
        }

        public TeacherViewModel Create(TeacherPostModel model)
        {
            if (model.FirstName.Contains(" "))
            {
                return new TeacherViewModel { FirstName = "validation PL error", LastName = "Errorovich" };
            }
            var teacherModel = new TeacherModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNum = model.LicenseNum
            };

            var createResult = _teachersService.Create(teacherModel);

            var result = new TeacherViewModel
            {
                Id = createResult.Id,
                FirstName = createResult.FirstName,
                LastName = createResult.LastName
            };

            return result;
        }
    }
}
