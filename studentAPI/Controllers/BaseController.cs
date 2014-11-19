using studentAPI.Models.factories;
using studentAPI.Models.repositories;
using studentAPI.Models.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace studentAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        //repository variable to be set by ninjected constructor instance
        IStudentApiRepo _repo;
        ModelFactory _modelFactory;
        IStudentValidation _validator;

        public BaseController(IStudentApiRepo repo, IStudentValidation validator)
        {
            _repo = repo;
            _validator = validator;
        }

        protected IStudentApiRepo TheStudentRepo
        {
            get
            {
                return _repo;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request);
                }

                return _modelFactory;
            }
        }


        protected IStudentValidation TheValidator
        {
            get
            {
                return _validator;
            }
        }
    }
}
