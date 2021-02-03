﻿using StudentsTeachers.Controllers;
using StudentsTeachers.Data.Repositories;
using StudentsTeachers.Domain.Services;
using StudentsTeachers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentsTest();
            TeachersTest();
        }
        public static void StudentsTest()
        {
            var repository = new StudentDapperRepository();
            var service = new StudentService(repository);
            var controller = new StudentsController(service);

            var studentPostModel = new StudentPostModel { FirstName = "Puzo", LastName = "Moe" };

            controller.Create(studentPostModel);

            var students = controller.GetAll();
        }
        public static void TeachersTest()
        {
            var repository = new TeacherAdoNetRepository();
            var service = new TeacherService(repository);
            var controller = new TeachersController(service);

            var teacherPostModel = new TeacherPostModel { FirstName = "Puzo", LastName = "Moe" };

            controller.Create(teacherPostModel);

            var teachers = controller.GetAll();
        }
    }
}