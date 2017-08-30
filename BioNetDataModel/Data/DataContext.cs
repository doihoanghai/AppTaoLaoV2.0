using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioNetModel.Data
{
    public class DataContext
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["BioNetModel"].ConnectionString;       
    }
    
}
