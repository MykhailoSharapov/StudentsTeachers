using StudentsTeachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Domain.Services.Interfaces
{
    interface ITeacherService
    {
        IEnumerable<TeacherModel> GetAll();
        TeacherModel Create(TeacherModel model);
    }
}
