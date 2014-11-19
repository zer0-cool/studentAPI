using studentAPI.Models.dtos;
using System;
namespace studentAPI.Models.repositories
{
    //this repository will have basic CRUD operations on it and wants to be HATEOS compliant
    //Data access will be performed by Dapper, a micro-ORM

    public interface IStudentApiRepo
    {
        ReturnObjects.StudentReturn GetStudentByID(int id);

        int AddStudent(RequestObjects.NewStudent PostedStudent);
    }
}
