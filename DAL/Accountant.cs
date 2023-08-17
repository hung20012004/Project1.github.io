using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project1.DAL
{
    public class Accountant
    {
        public int ID;
        public string? Username;
        public int showroom_ID;
        public string? password;
        public string? department;
        public string? phone;
        public string? name;
        public bool CheckUsername(){
            int check=0;
            using (MySqlCommand cmd = DBHelper.UseStored("check_username"))
                {
                    cmd.Parameters.Add("rq_username", MySqlDbType.VarChar).Value=Username;
                    cmd.ExecuteNonQuery();
                    using( MySqlDataReader reader =cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                           check=reader.GetInt32("id");
                        }
                    }
                }
            if(check==0) return true;
            else return false;
        }
        public bool CheckPhone(){
            int check=0;
            using (MySqlCommand cmd = DBHelper.UseStored("check_phone"))
                {
                    cmd.Parameters.Add("rq_phone", MySqlDbType.VarChar).Value=phone;
                    cmd.ExecuteNonQuery();
                    using( MySqlDataReader reader =cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            check=reader.GetInt32("id");
                        }
                    }
                }
            if(check==0) return true;
            else return false;
        }
        public void Create(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_account"))
                {
                    cmd.Parameters.Add("rq_username", MySqlDbType.VarChar).Value=Username;
                    cmd.Parameters.Add("rq_password", MySqlDbType.VarChar).Value=password;
                    cmd.Parameters.Add("rq_phone", MySqlDbType.VarChar).Value=phone;
                    cmd.Parameters.Add("rq_name", MySqlDbType.VarChar).Value=name;
                    cmd.ExecuteNonQuery();

                }
        }
        public void ChangePassword(){
            using (MySqlCommand cmd = DBHelper.UseStored("change_password"))
                {
                    cmd.Parameters.Add("rq_id", MySqlDbType.Int32).Value=ID;
                    cmd.Parameters.Add("rq_password", MySqlDbType.VarChar).Value=password;
                    cmd.ExecuteNonQuery();

                }
        }
    }
}