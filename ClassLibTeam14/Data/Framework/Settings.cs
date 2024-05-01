using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam14.Data.Framework
{
    static class Settings
    {
        public static string GetConnectionString()
        {//string connectionString = "Trusted_Connection=True;";
         string connectionString = "user id = sa;";
         connectionString += "Password = pxl;";
         connectionString += $@"Server=YOREN-BOOK-3-UL\SQLEXPRESS;";
         connectionString += $"Database=db_Yoren_VanVlierden";
         return connectionString;}
        }
}
