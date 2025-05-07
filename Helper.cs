using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChePizza_
{
    public class Helper
    {
        //public static string ConnectionString =@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=ChePizza.accdb";
        public static string ConnectionString =@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Pizza1.mdb";
        public static OleDbConnection connection = null;
    }
}
