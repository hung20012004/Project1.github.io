using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project1.DAL
{
    public class Order
    {
        public int salesmanID;
        public int requestID;
        public long totalBill;
        public string? processedTime;
        public void Create(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_order"))
            {
                cmd.Parameters.Add("rq_salesman_id", MySqlDbType.Int32).Value=salesmanID;
                cmd.Parameters.Add("rq_request_id", MySqlDbType.Int32).Value=requestID;
                cmd.Parameters.Add("total_bill", MySqlDbType.Int64).Value=totalBill;
                cmd.ExecuteNonQuery();
            }
        }
    }
}