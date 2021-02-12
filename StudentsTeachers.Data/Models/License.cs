using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Data.Models
{
    public class License
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
