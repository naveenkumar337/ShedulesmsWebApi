using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerSMSApi
{
    public class clsRegistration
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public int Password { get; set; }
        public int ConfirmPassword { get; set; }
        public clsResponse objresponse { get; set; }
    }
    public class clsResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class clsRegstrResponse
    {
        public string UserName { get; set; }
        public clsResponse objresponse { get; set; }
    }
}