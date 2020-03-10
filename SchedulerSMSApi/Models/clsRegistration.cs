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
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public clsResponse objresponse { get; set; }
    }
    public class clsResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class clsRegstrResponse
    {
        public List<clsContactlist> lstcontacts;
        public clsResponse objresponse { get; set; }
    }
    public class clsContactlist
    {
        public string UserName { get; set; }
        public string ContactNo { get; set; }
    }
}