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
            clsRegistration objregister= new clsRegistration();
            
           int i=dlobj.Register_Add(obj);
            if (i > 0)
            {              
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

        public clsRegstrResponse ListContacts_Get()
        { 
            clsRegstrResponse obj = new clsRegstrResponse();
            obj.objresponse = new clsResponse();
            try
            {
                DataTable dt = dlobj.ListContacts_Get();
                if (dt.Rows.Count > 0)
                {
                    obj.lstcontacts = dt.AsEnumerable().Select((drow) =>
                     {
                         return new clsContactlist
                         {
                             UserName = drow.Field<string>("UserName"),
                             ContactNo = drow.Field<string>("ContactNO"),
                         };
                     }).ToList();

                    obj.objresponse.ResponseCode = 1;
                    obj.objresponse.ResponseMessage = "Get contactlist Successfully";
                }
                else
                {
                    obj.objresponse.ResponseCode = 0;
                    obj.objresponse.ResponseMessage = "Error Occured";
                }
            }
            catch (Exception ex)
            {
                obj.objresponse.ResponseCode = -1;
                obj.objresponse.ResponseMessage = "Error Occured :" + ex.ToString();
            }
            return obj;
        }
        public clsResponse PasswordUpdate(forget updatepassword)
        {
                clsResponse res = new clsResponse();
            try
            {

                DataTable dt=dlobj.UpdatePassword(updatepassword);
                if (dt.Rows.Count > 0)
                {
                    res.ResponseCode = 1;
                    res.ResponseMessage = dt.Rows[0][0].ToString();
                }
                else
                {

                    res.ResponseCode = 0;
                    res.ResponseMessage = "DB Error Occured";
                }
            }
            catch (Exception ex)
            {
                res.ResponseCode = -1;
                res.ResponseMessage = "Error Occured";
            }
            return res;
        }
    }
}