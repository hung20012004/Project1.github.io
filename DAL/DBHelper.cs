using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Project1
{
    public class DBHelper
    {
        private static MySqlConnection connection;
        public static MySqlConnection GetConnection(){
            if (connection == null){
                connection = new MySqlConnection {
                    ConnectionString = @"server=localhost;userid=root;password=hung20012004;port=3306;database=project1;"
                };
            }
            return connection;
            }
        public static MySqlDataReader ExecQuery(string query) {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
        public static MySqlCommand UseStored(string proceduce) {
            MySqlCommand command = new MySqlCommand();
            command.CommandText=proceduce;
            command.CommandType=System.Data.CommandType.StoredProcedure;
            command.Connection=connection;
            return command;
        }
        public static MySqlConnection OpenConnection(){
            if (connection == null){
                GetConnection();
            }   
            connection.Open();
            return connection;
        }
        public static void CloseConnection() {
            if (connection != null) connection.Close();
        }
    }
}