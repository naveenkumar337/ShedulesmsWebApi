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
        public DataTable Register_Add(clsRegistration objregister)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(clsCommon.ConnectionString))
                {
                    if (SqlCon != null)
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
                            int val=Command.ExecuteNonQuery();

                            //SqlDataAdapter da = new SqlDataAdapter(Command);
                            //= da.Fill(dt);
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

        public void Login_Add(string Email, int Password)
        {
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
                            Command.ExecuteNonQuery();
                            SqlCon.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}