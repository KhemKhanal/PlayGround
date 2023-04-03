using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using DatabaseAccessClass.Models;
using System.Configuration;


namespace DatabaseAccessClass.DataAccess
{
    public class SQLDataAccess
    {

      private static readonly string Con = "Data Source=LENOVOBOOK\\SQLEXPRESS;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public static string GetConnectionString()
        {
            return Con;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql, data);
            }
        }
    }
}
