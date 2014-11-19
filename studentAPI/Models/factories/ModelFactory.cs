using studentAPI.Models.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace studentAPI.Models.factories
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
      
        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);

        }
        public ReturnObjects.StudentReturn Create(ReturnObjects.StudentReturn passedStudent)
        {
            return new ReturnObjects.StudentReturn
            {
                url = _urlHelper.Link("Students", new { id = passedStudent.id }),
                id = passedStudent.id,
                firstName = passedStudent.firstName,
                lastName = passedStudent.lastName
            };
        }

    }
}