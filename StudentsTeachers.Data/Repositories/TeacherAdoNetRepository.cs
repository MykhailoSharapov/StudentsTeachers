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
    public class TeacherAdoNetRepository : ITeacherRepository
    {
        private const string CONNECTION_STRING = "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;";

        public Teacher Create(Teacher model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "INSERT INTO Teachers(FirstName,LastName,LessonId) OUTPUT INSERTED.id VALUES(@FirstName,@LastName,1)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                connection.Open();
                model.Id = Convert.ToInt32(command.ExecuteScalar());
                return model;
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            var result = new List<Teacher>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "SELECT * FROM Teachers";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Teacher
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    });
                }
                reader.Close();
                return result;
            }
        }
    }
}
