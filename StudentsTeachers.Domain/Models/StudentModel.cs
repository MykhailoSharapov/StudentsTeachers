using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Domain.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int InsuranceNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
