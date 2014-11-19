using studentAPI.Models.dtos;
using System;
namespace studentAPI.Models.validation
{
    //extract business logic out of controllers.
    //provide a way to filter bad requests without cluttering controllers
    public interface IStudentValidation
    {
        bool ValidateGet(int id);
        bool ValidateStudent(RequestObjects.NewStudent postedStudent);
    }
}
