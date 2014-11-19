using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using studentAPI.Models.dtos;
using studentAPI.Models.repositories;
using studentAPI.Models.factories;
using System.Configuration;
using studentAPI.Models.validation;

namespace studentAPI.Controllers
{
    public class StudentsController : BaseController
    {
        public StudentsController(IStudentApiRepo repo, IStudentValidation validator)
            : base(repo, validator)
        {

        }

        //Return a Student object when passed a valid ID
        //ex. -- /api/students/1
        //accept "GET" only
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            string errormessage = "";
            if (TheValidator.ValidateGet(id))
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(TheStudentRepo.GetStudentByID(id)));
                }
                catch (Exception ex)
                {
                    errormessage = ex.Message;
                }
            }
            else
            {
                errormessage = "id out of acceptable bounds.";
            }
            //if we arrive here, we know that the try has failed. Create an error response
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errormessage);
        }


        //Insert a Student object when passed a valid object
        [HttpPost]
        public HttpResponseMessage Post([FromUri]RequestObjects.NewStudent PostedStudent)
        {
            string errormessage = "";

            try
            {
                if (TheValidator.ValidateStudent(PostedStudent))
                {
                    
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    errormessage = "Invalid parameters";
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }

            //if we arrive here, we know that the try has failed. Create an error response
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errormessage);
        }
    }
}
