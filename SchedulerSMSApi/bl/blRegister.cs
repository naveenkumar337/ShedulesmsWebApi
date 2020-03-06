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
    
        public clsResponse Login_Add(string Email,string Password)
        {
            clsResponse response = new clsResponse();
            try
            {
                DataTable dt = dlobj.Login_Add(Email, Password);
                if (dt.Rows.Count > 0)
                {
                    response.ResponseCode = 1;
                    response.ResponseMessage = dt.Rows[0]["UserName"].ToString();
                }
                else
                {
                    response.ResponseCode = 0;
                    response.ResponseMessage = "Error Occured";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -1;
                response.ResponseMessage = "Error Occured :"+ex.ToString();
            }
            return response;
        }
    }
}