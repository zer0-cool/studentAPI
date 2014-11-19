using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using studentAPI.Models.dtos;
using studentAPI.Models.factories;
using Dapper;


namespace studentAPI.Models.repositories
{
    public class StudentApiRepo : IStudentApiRepo
    {
        private IdbConnFactory _dbConnectionFactory;

        
        public StudentApiRepo(IdbConnFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

           
        public ReturnObjects.StudentReturn GetStudentByID(int id)
        {
            string sql = "SELECT * FROM Students WHERE Id = @id";
            ReturnObjects.StudentReturn result;

            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                result = dbConnection.Query<ReturnObjects.StudentReturn>(sql,
                new { Id = id }).FirstOrDefault();
            }

            if (result == null)
            {
                return new ReturnObjects.StudentReturn();
            }
            else
            {
                return result;
            }
        }

        public int AddStudent(RequestObjects.NewStudent PostedStudent)
        {
            string sql = "      INSERT INTO students (FirstName, LastName, GradeLevel, School) ";
            sql += "   Values ('@firstname', '@lastname', @gradelevel, @school)";
            int result;

            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                result = dbConnection.Execute(sql,
                new
                {
                    @firstname = PostedStudent.firstName,
                    @lastname = PostedStudent.lastName,
                    @gradelevel = PostedStudent.GradeLevel,
                    @school = PostedStudent.School

                });
            }
            return result;
        }

        public ReturnObjects.StudentClassesReturn GetStudentClassesByID(int id)
        {
            string sql = "  SELECT Students.*, Classes.ClassName,Schools.SchoolName from Students ";
            sql += "    INNER JOIN StudentsClasses on Students.Id = StudentsClasses.StudentId ";
            sql += "    INNER JOIN Classes on StudentsClasses.ClassID = Classes.Id ";
            sql += "    INNER JOIN Schools on Schools.Id = Classes.School ";
            sql += "    WHERE Students.Id = @id ";

            ReturnObjects.StudentClassesReturn result;

            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                result = dbConnection.Query<ReturnObjects.StudentClassesReturn>(sql,
                new { Id = id }).FirstOrDefault();
            }
            return result;

        }


    }
}