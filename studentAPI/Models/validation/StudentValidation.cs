using studentAPI.Models.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace studentAPI.Models.validation
{
    public class StudentValidation : studentAPI.Models.validation.IStudentValidation
    {
        public bool ValidateGet(int id)
        {
            if (id > 0 && id < int.MaxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateStudent(RequestObjects.NewStudent postedStudent)
        {
            const int DbMaxNameFieldLength = 500;

            if (!StringEx(postedStudent.firstName, DbMaxNameFieldLength) || !StringEx(postedStudent.lastName, DbMaxNameFieldLength))
            {
                return false;
            }

            if (!GradeCheck(postedStudent.GradeLevel))
            {
                return false;
            }

            //implement SQL select to check if school ID exists here...
            return true;
        }

        private bool GradeCheck(int gradelevel)
        {
            if(gradelevel > 0 &&  gradelevel < 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool StringEx(string StringToCheck, int DbFieldLength)
        {
            if ((!Regex.Match(StringToCheck, "^[A-Z][a-zA-Z]*$").Success)|| (StringToCheck.Length > DbFieldLength))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}