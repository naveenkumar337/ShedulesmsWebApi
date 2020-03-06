using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchedulerSMSApi.Controllers
{
    [RoutePrefix("api/Registraion")]
    public class RegistraionController : ApiController
    {
        blRegister objbl = new blRegister();

        [HttpPost]
        [Route("Registarion_ADD")]
        public clsRegstrResponse Registarion_ADD(clsRegistration obj)
        {

            clsRegstrResponse objresponse = objbl.Register_Add(obj);
            return objresponse;
        }
        [HttpPost]
        [Route("Login_ADD")]
        public void Login_ADD(string Email,int Password)
        {
            objbl.Login_Add(Email, Password);

        }
    }
}
