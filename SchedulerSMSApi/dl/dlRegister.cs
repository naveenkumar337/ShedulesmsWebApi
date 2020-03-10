using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchedulerSMSApi
{
    public class dlRegister
    {
        public int Register_Add(clsRegistration objregister)
        {
            int val = 0;
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(clsCommon.ConnectionString))
                {
                        using (SqlCommand Command = new SqlCommand("SP_ScheduledSMS_Register_ADD", SqlCon))
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Parameters.AddWithValue("@UserName", objregister.UserName);
                            Command.Parameters.AddWithValue("@Email", objregister.Email);
                            Command.Parameters.AddWithValue("@ContactNo", objregister.ContactNo);
                            Command.Parameters.AddWithValue("@Password", objregister.Password);
                            Command.Parameters.AddWithValue("@ConfirmPassword", objregister.ConfirmPassword);
                            SqlCon.Open();
                            val=Command.ExecuteNonQuery();
                            SqlCon.Close();
                        }
                    }
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return val;
        }

        public DataTable Login_Add(string Email,string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(clsCommon.ConnectionString))
                {
                    if (SqlCon != null)
                    {
                        using (SqlCommand Command = new SqlCommand("SP_ScheduledSMS_Login_ADD", SqlCon))
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Parameters.AddWithValue("@Email", Email);
                            Command.Parameters.AddWithValue("@Password", Password);
                            SqlCon.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(Command))
                            {
                                da.Fill(dt);
                            }
                           SqlCon.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        public DataTable ListContacts_Get()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(clsCommon.ConnectionString))
                {
                    if (SqlCon != null)
                    {
                        using (SqlCommand Command = new SqlCommand("SP_ScheduledSMS_ListContacts_Get", SqlCon))
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            SqlCon.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(Command))
                            {
                                da.Fill(dt);
                            }
                            SqlCon.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }
    }
}