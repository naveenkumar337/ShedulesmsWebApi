using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchedulerSMSApi
{
    public class blRegister
    {
        dlRegister dlobj = new dlRegister();
        public  clsRegstrResponse Register_Add(clsRegistration obj)
        {
            clsRegstrResponse objrgstresponse = new clsRegstrResponse();
            DataTable dt=dlobj.Register_Add(obj);
            //var id = dt.Rows[0][0];
            if (dt.Columns.Count > 0)
            {
                objrgstresponse.UserName = (dt.Rows[0][0]).ToString();
                objrgstresponse.objresponse = new clsResponse()
                {
                    ResponseCode = 100,
                    ResponseMessage = "Authentication Success"
                };
            }
            else
            {
                objrgstresponse.objresponse = new clsResponse()
                {
                    ResponseCode = 101,
                    ResponseMessage = "Authentication Fail"
                };
            }
            return objrgstresponse;
        }
    
        public void Login_Add(string Email,int Password)
        {
            dlobj.Login_Add(Email, Password);
        }
    }
}