using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SchedulerSMSApi
{
    public class clsCommon
    { 
        public static string ConnectionString= System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
    }
}