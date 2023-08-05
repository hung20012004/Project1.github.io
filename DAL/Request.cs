using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project1.DAL
{
    public class Request
    {
        public int ID;
        public string? customerName;
        public string? phone;
        public string? address;
        public string? note;
        public string? requestTime;
        public int? carID;
        public int? showroomID;
        public void Delete(){}
        public void Create(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_request"))
            {
                cmd.Parameters.Add("rq_customer", MySqlDbType.VarChar).Value=customerName;
                cmd.Parameters.Add("rq_phone", MySqlDbType.VarChar).Value=phone;
                cmd.Parameters.Add("rq_address", MySqlDbType.VarChar).Value=address;
                cmd.Parameters.Add("rq_note", MySqlDbType.VarChar).Value=note;
                cmd.Parameters.Add("rq_request_time", MySqlDbType.VarChar).Value=requestTime;
                cmd.Parameters.Add("rq_car_id", MySqlDbType.Int32).Value=carID;
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=showroomID;
                cmd.ExecuteNonQuery();
            }
        }

    }
}