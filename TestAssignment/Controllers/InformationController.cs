using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using TestAssignment.Models;
using TestAssignment.Service;
using TestAssignment.Business;

namespace TestAssignment.Controllers
{
    public class InformationController : ApiController
    {
        // default constructor for web service
        public InformationController()
        {
        }
        [HttpGet]
        [AcceptVerbs("GET")]
        public InformationModel GetNameAndAmount(string name, decimal amount)
        {
            // Dependecy Injection using UnityContainer
            try
            {
                //Intialization of container
                UnityContainer container = new UnityContainer();

                //Registring Interface and Business Class with Container
                container.RegisterType<IRepositoryDecimalToText, RepositoryDecimalToText>();

                //Resolving the classes and calling them using Loose Coupling
                Container _objIRepository = container.Resolve<Container>();
                return _objIRepository.displayText(name, amount);
            }
            catch
            {
                // In case of error Re-initializaing the object with Empty values
                InformationModel exception = new InformationModel();
                exception.MyName = name;
                exception.MyCurrentcyNumberText = "Number is out of range, Please re-enter";
                exception.MyOriginalNumber = string.Empty;
                return exception;
            }
        }

        [HttpPost]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
