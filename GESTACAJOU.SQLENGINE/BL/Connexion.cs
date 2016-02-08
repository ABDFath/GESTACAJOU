using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Business
{
    public class Connexion
    {
        public static string Cnx= ConfigurationManager.ConnectionStrings["CnxString"].ConnectionString;

    }
}
