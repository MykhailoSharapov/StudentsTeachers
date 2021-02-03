using Dapper;
using StudentsTeachers.Data.Models;
using StudentsTeachers.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Data.Repositories
{
    public class StudentDapperRepository : IStudentRepository
    {
        private const string CONNECTION_STRING = "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
        public Student Create(Student model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = $"INSERT INTO Students(FirstName,LastName) OUTPUT INSERTED.id VALUES(\'{model.FirstName}\',\'{model.LastName}\')";
                var insertedId = connection.ExecuteScalar(queryString);
                var insertedIdInt = Convert.ToInt32(insertedId);
                model.Id = insertedIdInt;
                return model;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.Query<Student>("SELECT * FROM Students");
            }
        }
    }
}
